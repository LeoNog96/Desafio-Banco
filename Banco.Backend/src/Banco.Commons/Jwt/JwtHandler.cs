using Microsoft.AspNetCore.Http;

namespace Banco.Commons.Jwt
{
    public class JwtHandler
    {
        private readonly IHttpContextAccessor _accessor;

        public JwtHandler(IHttpContextAccessor accessor)
        {
            _accessor = accessor;
        }

        public long IdPessoa
        {
            get
            {
                return long.Parse(_accessor.HttpContext.User.FindFirst("idPessoa").Value);
            }
        }
    }
}
