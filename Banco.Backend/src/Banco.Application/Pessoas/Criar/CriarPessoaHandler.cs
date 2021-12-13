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

namespace Banco.Application.Pessoas.Criar
{
    public class CriarPessoaHandler : IRequestHandler<CriarPessoaRequest, CriarPessoaResponse>
    {
        private readonly IPessoaRepository _pessoaRepository;
        private readonly NotificacaoContext _notificacaoContext;
        private readonly TokenConfigurations _tokenConfigurations;

        public CriarPessoaHandler(IPessoaRepository pessoaRepository, NotificacaoContext notificacaoContext, TokenConfigurations tokenConfigurations)
        {
            _pessoaRepository = pessoaRepository;
            _notificacaoContext = notificacaoContext;
            _tokenConfigurations = tokenConfigurations;
        }

        public async Task<CriarPessoaResponse> Handle(CriarPessoaRequest request, CancellationToken cancellationToken)
        {
            if (request.Invalido)
            {
                _notificacaoContext.AddNotificacoes(request.ValidationResult);

                return null;
            }

            if (await _pessoaRepository.ExistePessoa(request.Cpf))
            {
                _notificacaoContext.AddNotificacoes("Falha ao criar Pessoa", "Cpf já cadastrado");

                return null;
            }
            
            var novaPessoa = request.Adapt<Pessoa>();
            novaPessoa.Login = new Login(request.Email, BCrypt.Net.BCrypt.HashPassword(request.Senha));

            var pessoa = await _pessoaRepository.Salvar(novaPessoa);
            var pessoaResponse = pessoa.Adapt<CriarPessoaResponse>();

            pessoaResponse.Token = LoginDomainService.GerarToken(_tokenConfigurations, pessoa.Id).Token;

            return pessoaResponse;
        }
    }
}
