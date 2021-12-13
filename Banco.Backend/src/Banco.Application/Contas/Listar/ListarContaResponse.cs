using Banco.Application.Base;
using System.Collections.Generic;

namespace Banco.Application.Contas.Listar
{
    public class ListarContaResponse
    {
        public ListarContaResponse(IEnumerable<ContaBase> data)
        {
            Data = data;
        }

        public IEnumerable<ContaBase> Data { get;}
    }
}
