using Banco.Domain.Enums;
using System;
using System.Collections.Generic;

namespace Banco.Domain.Model
{
    public class Conta
    {
        public Conta()
        {
            Transacoes = new HashSet<Transacao>();
        }

        public long Id { get; set; }
        public long IdPessoa { get; set; }
        public decimal Saldo { get; set; }
        public decimal LimiteSaqueDiario { get; set; }
        public bool FlagAtivo { get; set; }
        public EtipoConta TipoConta { get; set; }
        public DateTime DataCriacao { get; set; }

        public virtual Pessoa Pessoa { get; set; }
        public virtual ICollection<Transacao> Transacoes { get; set; }
    }
}
