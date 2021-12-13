using Banco.Application.Notificacoes;
using Microsoft.Extensions.DependencyInjection;
using System;
using MediatR;
using Banco.Data.Repositories;
using Banco.Domain.Repositories;
using Banco.Commons.Jwt;
using Microsoft.AspNetCore.Http;

namespace Banco.WebApi.Configurations
{
    public static class DependenciasExtensions
    {
        public static void ConfigurarDependencias(this IServiceCollection services)
        {
            services.AddScoped<NotificacaoContext>();
            services.AddScoped<JwtHandler>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        }

        public static void ConfigurarDependenciasRepository(this IServiceCollection services)
        {
            services.AddScoped<ITransacaoRepository, TransacaoRepository>();
            services.AddScoped<IPessoaRepository, PessoaRepository>();
            services.AddScoped<IContaRepository, ContaRepository>();
            services.AddScoped<ILoginRepository, LoginRepository>();
        }

        public static void ConfigurarMediador(this IServiceCollection services)
        {
            var assembly = AppDomain.CurrentDomain.Load("Banco.Application");
            services.AddMediatR(assembly);
        }
    }
}
