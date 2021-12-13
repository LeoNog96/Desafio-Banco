using System;

namespace Banco.Application.Base
{
    public class TransacaoBase
    {
        public long Id { get; set; }
        public long IdConta { get; set; }
        public decimal Valor { get; set; }
        public DateTime DataTransacao { get; set; }
    }
}
