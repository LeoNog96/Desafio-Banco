namespace Banco.Application.Notificacoes
{
    public class Notificacao
    {
        public string Chave { get; }
        public string Mensagem { get; }

        public Notificacao(string chave, string mensagem)
        {
            Chave = chave;
            Mensagem = mensagem;
        }
    }
}
