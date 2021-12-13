using Banco.Application.Notificacoes;
using Banco.Domain.Repositories;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Banco.Application.Contas.AlterarLimiteSaque
{
    public class AlterarLimiteSaqueHandler : IRequestHandler<AlterarLimiteSaqueRequest, AlterarLimiteSaqueResponse>
    {
        private readonly IContaRepository _contaRepository;
        private readonly NotificacaoContext _notificacaoContext;

        public AlterarLimiteSaqueHandler(IContaRepository contaRepository, NotificacaoContext notificacaoContext)
        {
            _contaRepository = contaRepository;
            _notificacaoContext = notificacaoContext;
        }

        public async Task<AlterarLimiteSaqueResponse> Handle(AlterarLimiteSaqueRequest request, CancellationToken cancellationToken)
        {
            if (request.Invalido)
            {
                _notificacaoContext.AddNotificacoes(request.ValidationResult);

                return null;
            }
            
            var conta = await _contaRepository.Obter(request.IdConta);
            conta.LimiteSaqueDiario = request.NovoLimite;

            await _contaRepository.Atualizar(conta);

            return new AlterarLimiteSaqueResponse();
        }
    }
}
