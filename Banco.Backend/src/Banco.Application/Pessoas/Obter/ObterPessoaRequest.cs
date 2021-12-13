using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Banco.Application.Pessoas.Obter
{
    public class ObterPessoaRequest : IRequest<ObterPessoaResponse>
    {
        [Required]
        public long Id { get; set; }
    }
}
