using Banco.Domain.Model;
using System.Threading.Tasks;

namespace Banco.Domain.Repositories
{
    public interface ILoginRepository : IBaseRepository<Login>
    {
        Task<Login> ObterLoginPorEmail(string email);
    }
}
