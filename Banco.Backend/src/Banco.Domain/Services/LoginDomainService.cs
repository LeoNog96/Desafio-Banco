using Banco.Commons.Jwt;
using Banco.Domain.Dto;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Banco.Domain.Services
{
    public static class LoginDomainService
    {
        public static SessaoDto GerarToken(TokenConfigurations tokenConfigurations, long idPessoa)
        {
            var now = DateTime.UtcNow;
            var claims = new Claim[]
            {
                new Claim("idPessoa", idPessoa.ToString()),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            };

            var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenConfigurations.ChaveSecreta));
            var expires = now.AddDays(tokenConfigurations.Dias);
            var jwt = new JwtSecurityToken(
                issuer: tokenConfigurations.Emitente,
                audience: tokenConfigurations.App,
                claims: claims,
                notBefore: now,
                expires: expires,
                signingCredentials: new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256)
            );
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            return new SessaoDto(encodedJwt, expires, idPessoa);
        }
    }
}
