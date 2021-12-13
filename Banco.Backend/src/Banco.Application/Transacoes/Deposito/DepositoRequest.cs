using MediatR;

namespace Banco.Application.Transacoes.Deposito
{
    public class DepositoRequest : IRequest<DepositoResponse>
    {
        public long IdConta { get; set; }
        public decimal ValorDeposito { get; set; }
    }
}
