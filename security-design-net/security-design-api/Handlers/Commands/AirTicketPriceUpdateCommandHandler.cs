using FluentValidation;
using MediatR;
using Security.Design.Api.DTOs.AirfareDTO;
using Security.Design.Api.Repositories;
using System.ComponentModel.DataAnnotations;

namespace Security.Design.Api.Handlers.Commands
{
    public class AirTicketPriceUpdateCommandHandler(IValidator<AirTicketPriceUpdateDTO> validatorUpdatePrice, IAirfareRepository _airfareRepository) : IRequestHandler<AirTicketPriceUpdateDTO, AirFareUpdateResponse>
    {
        public async Task<AirFareUpdateResponse> Handle(AirTicketPriceUpdateDTO request, CancellationToken cancellationToken)
        {
            var result = await validatorUpdatePrice.ValidateAsync(request, cancellationToken);

            if (!result.IsValid)
            {
                var errors = result.Errors.Select(error => new Errors(error.PropertyName, error.ErrorMessage)).ToList();
                return new AirFareUpdateResponse(false, errors);
            }

            var model = await _airfareRepository.GetByIdAsync(request.Id, cancellationToken);

            //model.Valor = request.Valor;

            model = await _airfareRepository.UpdateAsync(model!, cancellationToken);

            return new AirFareUpdateResponse(true, default!);
        }
    }
}
