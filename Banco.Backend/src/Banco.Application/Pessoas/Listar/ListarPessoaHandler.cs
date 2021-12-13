using Banco.Application.Base;
using Banco.Application.Notificacoes;
using Banco.Domain.Repositories;
using Mapster;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Banco.Application.Pessoas.Listar
{
    public class ListarPessoaHandler : IRequestHandler<ListarPessoaRequest, ListarPessoaResponse>
    {
        private readonly IPessoaRepository _pessoaRepository;
        private readonly NotificacaoContext _notificacaoContext;

        public ListarPessoaHandler(IPessoaRepository pessoaRepository, NotificacaoContext notificacaoContext)
        {
            _pessoaRepository = pessoaRepository;
            _notificacaoContext = notificacaoContext;
        }

        public async Task<ListarPessoaResponse> Handle(ListarPessoaRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var pessoas = await _pessoaRepository.Listar();

                return new ListarPessoaResponse(pessoas.Adapt<List<PessoaBase>>());
            }catch(Exception)
            {
                _notificacaoContext.AddNotificacoes("Erro ao Listar", "Falha ao listar Pessoas");
                return null;
            }
        }
    }
}
