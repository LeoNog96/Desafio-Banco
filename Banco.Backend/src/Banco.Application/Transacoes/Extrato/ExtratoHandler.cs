using Banco.Application.Base;
using Banco.Application.Notificacoes;
using Banco.Domain.Repositories;
using Mapster;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Banco.Application.Transacoes.Extrato
{
    public class ExtratoHandler : IRequestHandler<ExtratoRequest, ExtratoResponse>
    {
        private readonly ITransacaoRepository _transacaoRepository;
        private readonly NotificacaoContext _notificacaoContext;

        public ExtratoHandler(ITransacaoRepository transacaoRepository, NotificacaoContext notificacaoContext)
        {
            _transacaoRepository = transacaoRepository;
            _notificacaoContext = notificacaoContext;
        }

        public async Task<ExtratoResponse> Handle(ExtratoRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var extrato = await _transacaoRepository.ListarPorPeriodo(request.IdConta, request.DataInicial, request.DataFinal);

                return new ExtratoResponse(extrato.Adapt<IEnumerable<TransacaoBase>>());
            }
            catch (Exception)
            {
                _notificacaoContext.AddNotificacoes("Erro", "Falha ao buscar extrato");
                return null;
            }
        }
    }
}
