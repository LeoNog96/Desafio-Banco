using System.Collections.Generic;

namespace Banco.Application.Notificacoes
{
    public class NotificacaoResponse
    {
        public string Titulo { get; private set; }
        public IEnumerable<Notificacao> Notificacoes { get; private set; }

        public NotificacaoResponse(string titulo, IEnumerable<Notificacao> notificacoes)
        {
            Titulo = titulo;
            Notificacoes = notificacoes;
        }
    }
}
