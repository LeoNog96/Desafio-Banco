using FluentValidation;
using System.Text.RegularExpressions;

namespace Banco.Application.Pessoas.Criar
{
    public class CriarPessoaValidator : AbstractValidator<CriarPessoaRequest>
    {
        public CriarPessoaValidator()
        {
            RuleFor(a => a.Email)
               .NotEmpty()
               .WithMessage("Email não pode ser vazio")
               .EmailAddress()
               .WithMessage("O campo deve ser um endereço de email");

            RuleFor(a => a.Nome)
                .NotEmpty()
                .WithMessage("Nome não pode ser vazio");

            RuleFor(a => a.Cpf)
                .Matches(new Regex(@"^\d{3}\.\d{3}\.\d{3}-\d{2}$"))
                .WithMessage("Cpf precisa ser válido");

            RuleFor(a => a.DataNascimento)
                .NotEmpty()
                .WithMessage("Data de nascimento nao pode ser vazia");

            RuleFor(a => a.Senha)
                .NotEmpty()
                .WithMessage("Senha nao pode ser vazia");
        }
    }
}
