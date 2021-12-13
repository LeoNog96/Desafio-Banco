using Microsoft.IdentityModel.Tokens;
using System.Security.Cryptography;

namespace Banco.Commons.Jwt
{
    public class SigningConfigurations
    {
        public SecurityKey Chave { get; }
        public SigningCredentials Credenciais { get; }

        public SigningConfigurations()
        {
            using (var provider = new RSACryptoServiceProvider(2048))
            {
                Chave = new RsaSecurityKey(provider.ExportParameters(true));
            }

            Credenciais = new SigningCredentials(
                Chave, SecurityAlgorithms.RsaSha256Signature);
        }
    }
}
