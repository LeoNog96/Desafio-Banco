using Banco.Data.Context;
using Banco.Domain.Model;
using Banco.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Banco.Data.Repositories
{
    public class PessoaRepository : BaseRepository<Pessoa>, IPessoaRepository
    {
        public PessoaRepository(BancoContext db)
            : base(db)
        {
            _incluir = new string[] { "Login" };
        }

        public Task<bool> ExistePessoa(string cpf)
        {
            return _db.Pessoas.Where(x => x.Cpf == cpf).AnyAsync();
        }

        public Task<Pessoa> ObterPessoa(long id)
        {
            return _db.Pessoas.Include(x => x.Contas).Include(x => x.Login).Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public Task<Pessoa> ObterPessoaPorCpf(string cpf)
        {
            return _db.Pessoas.Where(x => x.Cpf == cpf).FirstOrDefaultAsync();
        }
    }
}
