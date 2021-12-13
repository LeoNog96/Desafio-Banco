using Banco.Application.Base;
using System.Collections.Generic;

namespace Banco.Application.Pessoas.Obter
{
    public class ObterPessoaResponse : PessoaBase
    {
        public IEnumerable<ContaBase> Contas { get; set; }
    }
}
