using Banco.Data.Context;
using Banco.Domain.Model;
using Banco.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Banco.Data.Repositories
{
    public class LoginRepository : BaseRepository<Login>, ILoginRepository
    {
        public LoginRepository(BancoContext db)
            : base(db)
        {

        }

        public Task<Login> ObterLoginPorEmail(string email)
        {
            return _db.Logins.Where(x => x.Email == email).FirstOrDefaultAsync();
        }
    }
}
