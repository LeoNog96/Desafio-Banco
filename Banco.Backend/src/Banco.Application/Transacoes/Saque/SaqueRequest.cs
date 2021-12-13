using MediatR;

namespace Banco.Application.Transacoes.Saque
{
    public class SaqueRequest : IRequest<SaqueResponse>
    {
        public long IdConta { get; set; }
        public decimal ValorSaque { get; set; }
    }
}
