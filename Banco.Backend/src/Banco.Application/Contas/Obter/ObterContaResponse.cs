using Banco.Application.Base;
using Banco.Domain.Enums;
using System;

namespace Banco.Application.Contas.Obter
{
    public class ObterContaResponse
    {
        public long Id { get; set; }
        public long IdPessoa { get; set; }
        public double LimiteSaqueDiario { get; set; }
        public bool FlagAtivo { get; set; }
        public EtipoConta TipoConta { get; set; }
        public DateTime DataCriacao { get; set; }
    }
}
