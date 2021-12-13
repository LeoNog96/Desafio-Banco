using FluentValidation;

namespace Banco.Application.Contas.Criar
{
    public class CriaContaValidator : AbstractValidator<CriarContaRequest>
    {
        public CriaContaValidator()
        {
            RuleFor(a => a.IdPessoa)
               .NotEmpty()
               .WithMessage("Pessoa não pode ser vazia");

            RuleFor(a => a.TipoConta)
               .NotEmpty()
               .WithMessage("Tipo de Conta não pode ser vazia");
        }
    }
}
