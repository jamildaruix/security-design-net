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
            this.airfareRepository = airfareRepository;

            RuleFor(p => p.HeadersApp).NotNull();
            RuleFor(p => p.Id).GreaterThan(0).WithMessage("ID inválido").WithMessage("ID não encontrado");
            RuleFor(x => x.Valor).GreaterThan(0).WithMessage("Valor inválido");

            RuleFor(x => x.Id)
                .MustAsync(async (id, cancellationToken) =>
                {
                    return (await Exists(id, cancellationToken));
                })
                .WithMessage("Registro não localizado");
        }

        private async Task<bool> Exists(int id, CancellationToken cancellation) => await airfareRepository.AnyAsync(id, cancellation);
    }
}
