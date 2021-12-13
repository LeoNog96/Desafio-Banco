using Banco.Application.Base;
using Banco.Application.Notificacoes;
using Banco.Domain.Repositories;
using Mapster;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Banco.Application.Contas.Listar
{
    public class ListarContaHandler : IRequestHandler<ListarContaRequest, ListarContaResponse>
    {
        private readonly IContaRepository _contaRepository;
        private readonly NotificacaoContext _notificacaoContext;

        public ListarContaHandler(IContaRepository contaRepository, NotificacaoContext notificacaoContext)
        {
            _contaRepository = contaRepository;
            _notificacaoContext = notificacaoContext;
        }

        public async Task<ListarContaResponse> Handle(ListarContaRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var contas = await _contaRepository.Listar(request.IdPessoa);

                return new ListarContaResponse(contas.Adapt<List<ContaBase>>());
            }
            catch (Exception)
            {
                _notificacaoContext.AddNotificacoes("Erro ao Listar", "Falha ao listar Conta");
                return null;
            }
        }
    }
}
