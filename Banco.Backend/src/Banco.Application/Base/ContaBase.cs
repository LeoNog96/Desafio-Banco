using Banco.Domain.Enums;
using System;

namespace Banco.Application.Base
{
    public class ContaBase
    {
        public long Id { get; set; }
        public long IdPessoa { get; set; }
        public double LimiteSaqueDiario { get; set; }
        public bool FlagAtivo { get; set; }
        public EtipoConta TipoConta { get; set; }
        public DateTime DataCriacao { get; set; }
    }
}
