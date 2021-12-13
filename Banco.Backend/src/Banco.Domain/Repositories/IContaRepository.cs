using Banco.Domain.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Banco.Domain.Repositories
{
    public interface IContaRepository : IBaseRepository<Conta>
    {
        Task<Conta> Obter(long id);
        Task<List<Conta>> Listar(long? idPessoa);
    }
}
