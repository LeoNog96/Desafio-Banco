using System;

namespace Banco.Domain.Dto
{
    public class SessaoDto
    {
        public SessaoDto(string token, DateTime dataExpiracacao, long idPessoa)
        {
            Token = token;
            DataExpiracao = dataExpiracacao;
            IdPessoa = idPessoa;
        }

        public string Token { get; }
        public DateTime DataExpiracao { get; }
        public long IdPessoa { get; }
    }
}
