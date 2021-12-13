using Banco.Application.Base;
using Banco.Application.Contas.Criar;
using Banco.Application.Contas.Obter;
using Banco.Application.Logins.Autenticar;
using Banco.Application.Pessoas.Criar;
using Banco.Application.Pessoas.Obter;
using Banco.Application.Transacoes.Deposito;
using Banco.Application.Transacoes.Saque;
using Banco.Domain.Dto;
using Banco.Domain.Model;
using Mapster;

namespace Banco.WebApi.Mapper
{
    public static class MapperConfig
    {
        public static void Configurar()
        {
            TypeAdapterConfig<Pessoa, PessoaBase>.NewConfig()
                .Map(dest => dest.Email, src => src.Login.Email);
            TypeAdapterConfig<Pessoa, ObterPessoaResponse>.NewConfig()
                .Map(dest => dest.Email, src => src.Login.Email);
            TypeAdapterConfig<CriarPessoaRequest, Pessoa>.NewConfig();
            TypeAdapterConfig<Pessoa, CriarPessoaResponse>.NewConfig()
                .Map(dest => dest.Email, src => src.Login.Email);

            TypeAdapterConfig<Conta, ContaBase>.NewConfig();
            TypeAdapterConfig<Conta, CriarContaResponse>.NewConfig();
            TypeAdapterConfig<Conta, ObterContaResponse>.NewConfig();
            TypeAdapterConfig<CriarContaRequest, Conta>.NewConfig();

            TypeAdapterConfig<Transacao, DepositoResponse>.NewConfig();
            TypeAdapterConfig<Transacao, SaqueResponse>.NewConfig();
            TypeAdapterConfig<Transacao, TransacaoBase>.NewConfig();

            TypeAdapterConfig<SessaoDto, AutenticarResponse>.NewConfig();
            
        }
    }
}
