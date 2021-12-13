using Banco.Application.Notificacoes;
using Banco.Domain.Repositories;
using Mapster;
using MediatR;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace Banco.Application.Contas.Obter
{
    public class ObterContaHandler : IRequestHandler<ObterContaRequest, ObterContaResponse>
    {
        private readonly IContaRepository _contaRepository;
        private readonly NotificacaoContext _notificacaoContext;

        public ObterContaHandler(IContaRepository contaRepository, NotificacaoContext notificacaoContext)
        {
            _contaRepository = contaRepository;
            _notificacaoContext = notificacaoContext;
        }

        public async Task<ObterContaResponse> Handle(ObterContaRequest request, CancellationToken cancellationToken)
        {
            var conta = await _contaRepository.Obter(request.Id);

            if (conta == null)
            {
                _notificacaoContext.AddNotificacoes("Falha ao Buscar Conta", "Conta não Existe!");
                _notificacaoContext.SetarCodigoStatus((int)HttpStatusCode.NotFound);

                return null;
            }

            return conta.Adapt<ObterContaResponse>();
        }
    }
}
