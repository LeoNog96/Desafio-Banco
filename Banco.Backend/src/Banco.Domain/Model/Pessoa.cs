using System;
using System.Collections.Generic;

namespace Banco.Domain.Model
{
    public class Pessoa
    {
        public Pessoa()
        {
            Contas = new HashSet<Conta>();
        }

        public long Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public DateTime DataNascimento { get; set; }

        public virtual ICollection<Conta> Contas { get; set; }
        public virtual Login Login { get; set; }
    }
}
