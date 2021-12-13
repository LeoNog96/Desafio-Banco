using FluentValidation;
using FluentValidation.Results;
using System.Text.Json.Serialization;

namespace Banco.Application.Base
{
    public class ValidadorBase
    {
        [JsonIgnore]
        public bool Valido { get; private set; }

        [JsonIgnore]
        public bool Invalido => !Valido;

        [JsonIgnore]
        public ValidationResult ValidationResult { get; private set; }

        public bool Valida<TModel>(TModel model, AbstractValidator<TModel> validator)
        {
            ValidationResult = validator.Validate(model);

            return Valido = ValidationResult.IsValid;
        }
    }
}
