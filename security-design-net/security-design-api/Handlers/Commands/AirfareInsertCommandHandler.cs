using FluentValidation;
using FluentValidation.Results;
using MediatR;
using Security.Design.Api.DTOs.AirfareDTO;
using Security.Design.Api.Events;
using Security.Design.Api.Events.AirfaceEvents;
using Security.Design.Api.Models;
using Security.Design.Api.Repositories;

namespace Security.Design.Api.Handlers.Commands
{
    public class AirfareInsertCommandHandler(IValidator<AirfareCreateDTO> validatorCreate, IAirfareRepository _airfareRepository, IEventStore eventStore) : IRequestHandler<AirfareCreateDTO, AirFareCreateResponse>
    {
        public async Task<AirFareCreateResponse> Handle(AirfareCreateDTO request, CancellationToken cancellationToken)
        {
            ValidationResult result = validatorCreate.Validate(request);

            if (!result.IsValid)
            {
                var errors = result.Errors.Select(error => new Errors(error.PropertyName, error.ErrorMessage)).ToList();
                return new AirFareCreateResponse(false, errors);
            }


            AirfareModel model = new(0, request.Origem, request.Destino, request.Valor, request.Validade, true);

            model = await _airfareRepository.InsertAsync(model, cancellationToken);

            eventStore.AdicionarEvento(new BuyTicketAirfaceVersionOneEvent(model.Id, model.Destino, model.Valor, request.HeadersApp.CorrelationID!.Value));

            return new AirFareCreateResponse(model.Id > 0, default!);
        }
    }
}
