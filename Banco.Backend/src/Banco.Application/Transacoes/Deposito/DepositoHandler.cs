using Banco.Application.Notificacoes;
using Banco.Domain.Model;
using Banco.Domain.Repositories;
using Banco.Domain.Services;
using Mapster;
using MediatR;
using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace Banco.Application.Transacoes.Deposito
{
    public class DepositoHandler : IRequestHandler<DepositoRequest, DepositoResponse>
    {
        private readonly ITransacaoRepository _transacaoRepository;
        private readonly IContaRepository _contaRepository;
        private readonly NotificacaoContext _notificacaoContext;

        public DepositoHandler(ITransacaoRepository transacaoRepository, IContaRepository contaRepository, NotificacaoContext notificacaoContext)
        {
            _contaRepository = contaRepository;
            _transacaoRepository = transacaoRepository;
            _notificacaoContext = notificacaoContext;
        }

        public async Task<DepositoResponse> Handle(DepositoRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var conta = await _contaRepository.Obter(request.IdConta);

                if (conta == null)
                {
                    _notificacaoContext.AddNotificacoes("Falha ao Buscar Conta", "Conta não Existe!");
                    _notificacaoContext.SetarCodigoStatus((int)HttpStatusCode.NotFound);

                    return null;
                }

                var transacao = new Transacao
                {
                    Valor = request.ValorDeposito,
                    IdConta = request.IdConta
                };
                
                transacao = await TransacaoDomainService.CriarTransacao(_transacaoRepository, _contaRepository, transacao, conta);
                return transacao.Adapt<DepositoResponse>();
            }
            catch (Exception)
            {
                _notificacaoContext.AddNotificacoes("Falha ao Realizar Transação", "Impossivel realizar Transação");

                return null;
            }           
        }
    }
}
