using FluentValidation;

namespace Banco.Application.Logins.Autenticar
{
    public class AutenticarValidator : AbstractValidator<AutenticarRequest>
    {
        public AutenticarValidator()
        {
            RuleFor(a => a.Email)
               .NotEmpty()
               .WithMessage("Email não pode ser vazio")
               .EmailAddress()
               .WithMessage("O campo deve ser um endereço de email");

            RuleFor(a => a.Senha)
                .NotEmpty()
                .WithMessage("Senha nao pode ser vazia");
        }
    }
}
