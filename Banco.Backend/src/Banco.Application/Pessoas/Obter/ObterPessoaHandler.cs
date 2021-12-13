using Banco.Application.Notificacoes;
using Banco.Domain.Repositories;
using Mapster;
using MediatR;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace Banco.Application.Pessoas.Obter
{
    public class ObterPessoaHandler : IRequestHandler<ObterPessoaRequest, ObterPessoaResponse>
    {
        private readonly IPessoaRepository _pessoaRepository;
        private readonly NotificacaoContext _notificacaoContext;

        public ObterPessoaHandler(IPessoaRepository pessoaRepository, NotificacaoContext notificacaoContext)
        {
            _pessoaRepository = pessoaRepository;
            _notificacaoContext = notificacaoContext;
        }

        public async Task<ObterPessoaResponse> Handle(ObterPessoaRequest request, CancellationToken cancellationToken)
        {
            var pessoa = await _pessoaRepository.ObterPessoa(request.Id);

            if (pessoa == null)
            {
                _notificacaoContext.AddNotificacoes("Falha ao Buscar Pessoa", "Pessoa não Existe!");
                _notificacaoContext.SetarCodigoStatus((int)HttpStatusCode.NotFound);

                return null;
            }

            return pessoa.Adapt<ObterPessoaResponse>();
        }
    }
}
