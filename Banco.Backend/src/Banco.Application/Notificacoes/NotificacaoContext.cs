using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;

namespace Banco.Application.Notificacoes
{
    public class NotificacaoContext
    {
        private readonly List<Notificacao> _notificacoes;
        private int _codigoStatus;
        public IReadOnlyCollection<Notificacao> Notificacoes => _notificacoes;
        public bool ExisteNotificacoes => _notificacoes.Any();
        public int CodigoStatus => _codigoStatus;

        public NotificacaoContext()
        {
            _notificacoes = new List<Notificacao>();
            _codigoStatus = 400;
        }

        public void SetarCodigoStatus(int codigoStatus)
        {
            _codigoStatus = codigoStatus;
        }

        public void AddNotificacoes(string chave, string mensagem)
        {
            _notificacoes.Add(new Notificacao(chave, mensagem));
        }

        public void AddNotificacoes(Notificacao notficacao)
        {
            _notificacoes.Add(notficacao);
        }

        public void AddNotificacoes(IEnumerable<Notificacao> notificacoes)
        {
            _notificacoes.AddRange(notificacoes);
        }

        public void AddNotificacoes(IReadOnlyCollection<Notificacao> notificacoes)
        {
            _notificacoes.AddRange(notificacoes);
        }

        public void AddNotificacoes(IList<Notificacao> notificacoes)
        {
            _notificacoes.AddRange(notificacoes);
        }

        public void AddNotificacoes(ICollection<Notificacao> notificacoes)
        {
            _notificacoes.AddRange(notificacoes);
        }

        public void AddNotificacoes(ValidationResult validationResult)
        {
            foreach (var error in validationResult.Errors)
            {
                AddNotificacoes(error.ErrorCode, error.ErrorMessage);
            }
        }
    }
}
