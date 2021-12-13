using FluentValidation;

namespace Banco.Application.Contas.AlterarLimiteSaque
{
    public class AlterarLimiteSaqueValidator : AbstractValidator<AlterarLimiteSaqueRequest>
    {
        public AlterarLimiteSaqueValidator()
        {
            RuleFor(a => a.NovoLimite)
                   .NotEmpty()
                   .WithMessage("Novo limite nao pode ser nulo")
                   .GreaterThan(0)
                   .WithMessage("Novo limite deve ser maior que 0");
        }
    }
}
