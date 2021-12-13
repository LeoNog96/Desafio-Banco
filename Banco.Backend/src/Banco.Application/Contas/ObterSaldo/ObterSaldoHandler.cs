using Banco.Application.Notificacoes;
using Banco.Domain.Repositories;
using MediatR;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace Banco.Application.Contas.ObterSaldo
{
    public class ObterSaldoHandler : IRequestHandler<ObterSaldoRequest, ObterSaldoResponse>
    {
        private readonly IContaRepository _contaRepository;
        private readonly NotificacaoContext _notificacaoContext;

        public ObterSaldoHandler(IContaRepository contaRepository, NotificacaoContext notificacaoContext)
        {
            _contaRepository = contaRepository;
            _notificacaoContext = notificacaoContext;
        }

        public async Task<ObterSaldoResponse> Handle(ObterSaldoRequest request, CancellationToken cancellationToken)
        {
            var conta = await _contaRepository.Obter(request.IdConta);

            if (conta == null)
            {
                _notificacaoContext.AddNotificacoes("Falha ao Buscar Saldo", "Conta não Existe!");
                _notificacaoContext.SetarCodigoStatus((int)HttpStatusCode.NotFound);

                return null;
            }

            return new ObterSaldoResponse(conta.Saldo);
        }
    }
}
