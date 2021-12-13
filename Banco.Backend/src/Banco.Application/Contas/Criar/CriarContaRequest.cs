using Banco.Application.Base;
using Banco.Domain.Enums;
using MediatR;
using System;

namespace Banco.Application.Contas.Criar
{
    public class CriarContaRequest : ValidadorBase, IRequest<CriarContaResponse>
    {
        public long IdPessoa { get; set; }
        public double Saldo { get; set; }
        public double LimiteSaqueDiario { get; set; }
        public bool FlagAtivo { get; set; }
        public EtipoConta TipoConta { get; set; }
        
        public void Validar()
        {
            Valida(this, new CriaContaValidator());
        }
    }
}
