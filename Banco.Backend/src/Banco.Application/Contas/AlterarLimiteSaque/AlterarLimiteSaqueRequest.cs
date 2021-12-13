using Banco.Application.Base;
using MediatR;

namespace Banco.Application.Contas.AlterarLimiteSaque
{
    public class AlterarLimiteSaqueRequest : ValidadorBase, IRequest<AlterarLimiteSaqueResponse>
    {
        public long IdConta { get; set; }
        public decimal NovoLimite { get; set; }
        
        public void Validar()
        {
            Valida(this, new AlterarLimiteSaqueValidator());
        }
    }
}
