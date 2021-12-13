using Banco.Application.Base;
using System.Collections.Generic;

namespace Banco.Application.Pessoas.Listar
{
    public class ListarPessoaResponse
    {
        public ListarPessoaResponse(IEnumerable<PessoaBase> data)
        {
            Data = data;
        }

        public IEnumerable<PessoaBase> Data { get; }
    }
}
