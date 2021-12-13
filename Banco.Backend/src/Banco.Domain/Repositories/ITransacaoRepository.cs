using Banco.Domain.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Banco.Domain.Repositories
{
    public interface ITransacaoRepository : IBaseRepository<Transacao>
    {
        Task<List<Transacao>> ListarPorPeriodo(long idConta, DateTime? dataInicial, DateTime? dataFinal);
        Task<decimal> ObterSaquesDiario(long idConta);
    }
}
