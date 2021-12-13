using Banco.Application.Base;
using MediatR;

namespace Banco.Application.Logins.Autenticar
{
    public class AutenticarRequest : ValidadorBase, IRequest<AutenticarResponse>
    {
        public string Email { get; set; }
        public string Senha { get; set; }

        public void Validar()
        {
            Valida(this, new AutenticarValidator());
        }
    }
}
