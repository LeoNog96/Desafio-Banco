using Banco.Application.Notificacoes;
using Banco.Commons.Jwt;
using Banco.Domain.Model;
using Banco.Domain.Repositories;
using Banco.Domain.Services;
using Mapster;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Banco.Application.Contas.Criar
{
    public class CriarContaHandler : IRequestHandler<CriarContaRequest, CriarContaResponse>
    {
        private readonly IContaRepository _contaRepository;
        private readonly NotificacaoContext _notificacaoContext;

        public CriarContaHandler(IContaRepository contaRepository, NotificacaoContext notificacaoContext)
        {
            _contaRepository = contaRepository;
            _notificacaoContext = notificacaoContext;
        }

        public async Task<CriarContaResponse> Handle(CriarContaRequest request, CancellationToken cancellationToken)
        {
            if (request.Invalido)
            {
                _notificacaoContext.AddNotificacoes(request.ValidationResult);

                return null;
            }

            try
            {
                var novaConta = request.Adapt<Conta>();
                

                var conta = await _contaRepository.Salvar(novaConta);

                return conta.Adapt<CriarContaResponse>();
            }
            catch(Exception)
            {
                _notificacaoContext.AddNotificacoes("Erro", "Falha ao salvar conta");

                return null;
            }
        }
    }
}
