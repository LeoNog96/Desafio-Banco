using Banco.Data.Context;
using Banco.Domain.Model;
using Banco.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Banco.Data.Repositories
{
    public class ContaRepository : BaseRepository<Conta>, IContaRepository
    {
        public ContaRepository(BancoContext db)
            : base(db)
        {

        }

        public Task<List<Conta>> Listar(long? idPessoa)
        {
            return _db.Contas.Where(x => x.FlagAtivo && 
                (!idPessoa.HasValue || x.IdPessoa == idPessoa)).AsNoTracking().ToListAsync();
        }

        public Task<Conta> Obter(long id)
        {
            return _db.Contas.Where(x => x.FlagAtivo && x.Id == id).AsNoTracking().FirstOrDefaultAsync();
        }
    }
}
