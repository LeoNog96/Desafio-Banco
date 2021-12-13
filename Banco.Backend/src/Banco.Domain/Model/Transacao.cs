using System;

namespace Banco.Domain.Model
{
    public class Transacao
    {
        public long Id { get; set; }
        public long IdConta { get; set; }
        public decimal Valor { get; set; }
        public DateTime DataTransacao { get; set; }

        public virtual Conta Conta { get; set; }
    }
}
