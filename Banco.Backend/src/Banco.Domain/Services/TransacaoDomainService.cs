using Banco.Domain.Model;
using Banco.Domain.Repositories;
using System.Threading.Tasks;

namespace Banco.Domain.Services
{
    public static class TransacaoDomainService
    {
        public static async Task<Transacao> CriarTransacao(
            ITransacaoRepository transacaoRepository, 
            IContaRepository contaRepository, Transacao transacao, Conta conta)
        {
            transacao = await transacaoRepository.Salvar(transacao);
            conta.Saldo += transacao.Valor;

            await contaRepository.Atualizar(conta);

            return transacao;
        }
    }
}
