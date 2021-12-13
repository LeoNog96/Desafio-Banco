using Banco.Application.Base;
using System.Collections.Generic;

namespace Banco.Application.Transacoes.Extrato
{
    public class ExtratoResponse
    {
        public ExtratoResponse(IEnumerable<TransacaoBase> data)
        {
            Data = data;
        }
        public IEnumerable<TransacaoBase> Data { get; }
    }
}
