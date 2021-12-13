namespace Banco.Application.Contas.ObterSaldo
{
    public class ObterSaldoResponse
    {
        public ObterSaldoResponse(decimal saldo)
        {
            Saldo = saldo;
        }

        public decimal Saldo { get; set; }
    }
}
