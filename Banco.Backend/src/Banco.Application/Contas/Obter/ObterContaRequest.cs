using MediatR;

namespace Banco.Application.Contas.Obter
{
    public class ObterContaRequest : IRequest<ObterContaResponse>
    {
        public long Id { get; set; }
    }
}
