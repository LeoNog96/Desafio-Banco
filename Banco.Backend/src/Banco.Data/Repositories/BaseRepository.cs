using Banco.Data.Context;
using Banco.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Banco.Data.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected readonly BancoContext _db;
        protected string[] _incluir;

        public BaseRepository(BancoContext db)
        {
            _db = db;
        }

        public Task<List<T>> Listar()
        {
            IQueryable<T> query = _db.Set<T>();
            
            if (_incluir != null)
            {
                foreach (var item in _incluir)
                {
                    query = query.Include(item);
                }
            }
            
            return query.AsNoTracking().ToListAsync();
        }

        public async Task<T> Obter(long id)
        {
            var entity = await _db.Set<T>().FindAsync(id);

            if (entity == null)
                return entity;

            _db.Entry(entity).State = EntityState.Detached;

            return entity;
        }

        public async Task<T> Salvar(T entity)
        {
            await _db.Set<T>().AddAsync(entity);

            await _db.SaveChangesAsync();

            return entity;
        }

        public async Task<List<T>> SalvarMuitos(List<T> entity)
        {
            await _db.Set<T>().AddRangeAsync(entity);

            await _db.SaveChangesAsync();

            return entity;
        }

        public Task Atualizar(T entity)
        {
            _db.Set<T>().Update(entity);

            return _db.SaveChangesAsync();
        }

        public Task AtualizarMuitos(List<T> entity)
        {
            _db.Set<T>().UpdateRange(entity);

            return _db.SaveChangesAsync();
        }

        public async Task Remover(long id)
        {
            var entity = await Obter(id);

            _db.Set<T>().Remove(entity);

            await _db.SaveChangesAsync();
        }

        public Task RemoverMuitos(List<T> entity)
        {
            _db.Set<T>().RemoveRange(entity);

            return _db.SaveChangesAsync();
        }
    }
}
