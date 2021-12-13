using MediatR;

namespace Banco.Application.Contas.Listar
{
    public class ListarContaRequest : IRequest<ListarContaResponse>
    {
        public long? IdPessoa { get; set; }
    }
}
