using System;

namespace Banco.Application.Logins.Autenticar
{
    public class AutenticarResponse
    {
        public string Token { get; set; }
        public DateTime DataExpiracao { get; set; }
    }
}
