using MediatR;
using System;
using System.ComponentModel.DataAnnotations;

namespace Banco.Application.Transacoes.Extrato
{
    public class ExtratoRequest : IRequest<ExtratoResponse>
    {
        [Required]
        public long IdConta { get; set; }

        public DateTime? DataInicial { get; set; }
        public DateTime? DataFinal { get; set; }
    }
}