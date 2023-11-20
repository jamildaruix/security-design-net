using FluentValidation;
using Security.Design.Api.DTOs.AirfareDTO;
using Security.Design.Api.Repositories;

namespace Security.Design.Api.Validators
{
    public class AirTicketPriceUpdateDTOValidator : AbstractValidator<AirTicketPriceUpdateDTO>
    {
        private readonly IAirfareRepository airfareRepository;


        public AirTicketPriceUpdateDTOValidator(IAirfareRepository airfareRepository)
        {
            RuleFor(p => p.HeadersApp).NotNull();
            RuleFor(x => x.Id)
                              .GreaterThan(0).WithMessage("ID inválido")
                              .MustAsync(Exists)
                              .WithMessage("ID não encontrado");

            RuleFor(x => x.Valor).GreaterThan(0).WithMessage("Valor inválido");

        }

        private async Task<bool> Exists(int id, CancellationToken cancellation)
        {
            return await airfareRepository.AnyAsync(id, cancellation);
        }
    }
}
