using Banco.Application.Notificacoes;
using Banco.Commons.Jwt;
using Banco.Domain.Repositories;
using Banco.Domain.Services;
using Mapster;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Banco.Application.Logins.Autenticar
{
    public class AutenticarHandler : IRequestHandler<AutenticarRequest, AutenticarResponse>
    {
        private readonly ILoginRepository _loginRepository;
        private readonly NotificacaoContext _notificacaoContext;
        private readonly TokenConfigurations _tokenConfigurations;

        public AutenticarHandler(ILoginRepository loginRepository, NotificacaoContext notificacaoContext, TokenConfigurations tokenConfigurations)
        {
            _loginRepository = loginRepository;
            _notificacaoContext = notificacaoContext;
            _tokenConfigurations = tokenConfigurations;
        }

        public async Task<AutenticarResponse> Handle(AutenticarRequest request, CancellationToken cancellationToken)
        {
            if (request.Invalido)
            {
                _notificacaoContext.AddNotificacoes(request.ValidationResult);

                return null;
            }

            try
            {
                const string erroLogin = "Email ou senha inválidos";
                var login = await _loginRepository.ObterLoginPorEmail(request.Email);

                if (login != null && BCrypt.Net.BCrypt.Verify(request.Senha, login?.Senha))
                {
                    return LoginDomainService.GerarToken(_tokenConfigurations, login.IdPessoa).Adapt<AutenticarResponse>();
                }

                _notificacaoContext.AddNotificacoes("Erro No Login", erroLogin);
                
                return null;
            }
            catch(Exception)
            {
                _notificacaoContext.AddNotificacoes("Erro No Login", "Falha ao realizar o login");
                
                return null;
            }
        }
    }
}
