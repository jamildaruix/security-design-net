using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Security.Design.Api.DTOs.AirfareDTO;

namespace Security.Design.Api.Validators
{
    public class AirfareCreateDTOValidator : AbstractValidator<AirfareCreateDTO>
    {
        public AirfareCreateDTOValidator()
        {
            RuleFor(p => p.HeadersApp).NotNull();
            RuleFor(dto => dto.Origem).NotEmpty().WithMessage("O campo Origem é obrigatório.");
            RuleFor(dto => dto.Destino).NotEmpty().WithMessage("O campo Destino é obrigatório.");
            RuleFor(dto => dto.Valor).GreaterThan(0).WithMessage("O Valor deve ser maior que zero.");
            RuleFor(dto => dto.Validade).Must(BeAValidDate).WithMessage("Data de Validade inválida.");
        }
        private static bool BeAValidDate(DateTime date) => date < DateTime.Now;

    }
}
