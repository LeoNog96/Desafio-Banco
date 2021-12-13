using Banco.Data.Context;
using Banco.Domain.Model;
using Banco.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Banco.Data.Repositories
{
    public class TransacaoRepository : BaseRepository<Transacao>, ITransacaoRepository
    {
        public TransacaoRepository(BancoContext db)
            :base(db)
        {

        }

        public Task<List<Transacao>> ListarPorPeriodo(long idConta, DateTime? dataInicial, DateTime? dataFinal)
        {
            return _db.Transacoes.Where(x => x.IdConta == idConta && 
                (!dataInicial.HasValue || x.DataTransacao >= dataInicial) &&
                (!dataFinal.HasValue || x.DataTransacao <= dataFinal)
            ).AsNoTracking()
                .ToListAsync();
        }

        public async Task<decimal> ObterSaquesDiario(long idConta)
        {
            var diaAtual = DateTime.UtcNow.Date;
            var saquesDiarios = await _db.Transacoes.Where(x => x.IdConta == idConta &&
                                                            x.Valor < 0 &&
                                                            x.DataTransacao >= diaAtual && 
                                                            x.DataTransacao < diaAtual.AddDays(1)).AsNoTracking().ToListAsync();

            decimal valor = 0;

            foreach (var item in saquesDiarios)
            {
                valor += item.Valor;
            }

            return valor;
        }
    }
}
