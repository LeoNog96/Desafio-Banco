using MediatR;

namespace Banco.Application.Contas.ObterSaldo
{
    public class ObterSaldoRequest : IRequest<ObterSaldoResponse>
    {
        public long IdConta { get; set; }
    }
}
