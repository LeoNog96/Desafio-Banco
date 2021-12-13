using Banco.Commons.Jwt;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Text;

namespace Banco.WebApi.Extensions
{
    public static class AuthenticationExtensions
    {
        public static void ConfigurarAutenticacao(this IServiceCollection services, IConfiguration config)
        {
            var signingConfigurations = new SigningConfigurations();

            services.AddSingleton(signingConfigurations);

            var tokenConfigurations = new TokenConfigurations();

            new ConfigureFromConfigurationOptions<TokenConfigurations>(
                    config.GetSection("TokenConfigurations"))
                .Configure(tokenConfigurations);

            services.AddSingleton(tokenConfigurations);

            var chaveAcesso = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenConfigurations.ChaveSecreta));

            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = chaveAcesso,
                ValidateIssuer = true,
                ValidIssuer = tokenConfigurations.Emitente,
                ValidateAudience = true,
                ValidAudience = tokenConfigurations.App,
                ValidateLifetime = true,
                ClockSkew = TimeSpan.Zero,
                RequireExpirationTime = true
            };

            services.AddAuthentication(authOptions =>
            {
                authOptions.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                authOptions.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(bearerOptions =>
                bearerOptions.TokenValidationParameters = tokenValidationParameters
            );

            services.AddAuthorization(auth =>
            {
                auth.AddPolicy("Bearer", new AuthorizationPolicyBuilder()
                    .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme‌​)
                    .RequireAuthenticatedUser().Build());
            });
        }
    }
}
