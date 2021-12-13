using Banco.Domain.Model;
using System.Threading.Tasks;

namespace Banco.Domain.Repositories
{
    public interface IPessoaRepository : IBaseRepository<Pessoa>
    {
        Task<Pessoa> ObterPessoa(long id);
        Task<bool> ExistePessoa(string cpf);
        Task<Pessoa> ObterPessoaPorCpf(string cpf);
    }
}
