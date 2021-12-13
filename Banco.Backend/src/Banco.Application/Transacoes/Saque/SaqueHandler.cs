using Banco.Application.Notificacoes;
using Banco.Domain.Model;
using Banco.Domain.Repositories;
using Banco.Domain.Services;
using Mapster;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Banco.Application.Transacoes.Saque
{
    public class SaqueHandler : IRequestHandler<SaqueRequest, SaqueResponse>
    {
        private readonly ITransacaoRepository _transacaoRepository;
        private readonly IContaRepository _contaRepository;
        private readonly NotificacaoContext _notificacaoContext;

        public SaqueHandler(ITransacaoRepository transacaoRepository, IContaRepository contaRepository, NotificacaoContext notificacaoContext)
        {
            _contaRepository = contaRepository;
            _transacaoRepository = transacaoRepository;
            _notificacaoContext = notificacaoContext;
        }

        public async Task<SaqueResponse> Handle(SaqueRequest request, CancellationToken cancellationToken)
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
                
                var saque = request.ValorSaque * -1;
                var valorSaqueDiario = await _transacaoRepository.ObterSaquesDiario(request.IdConta);

                if ((conta.LimiteSaqueDiario + (valorSaqueDiario + saque)) < 0)
                {
                    _notificacaoContext.AddNotificacoes("Falha ao Realizar Saque", "Limite diário de saque foi ultrapassado!");
                    return null;
                }

                var transacao = new Transacao
                {
                    Valor = saque,
                    IdConta = request.IdConta
                };

                transacao = await TransacaoDomainService.CriarTransacao(_transacaoRepository, _contaRepository, transacao, conta);
                
                return transacao.Adapt<SaqueResponse>();
            }
            catch (Exception)
            {
                _notificacaoContext.AddNotificacoes("Falha ao Realizar Transação", "Impossivel realizar Transação");

                return null;
            }
            
        }
    }
}
