using FluentValidation;
using MediatR;
using Security.Design.Api.DTOs.AirfareDTO;
using Security.Design.Api.Events.AirfaceEvents;
using Security.Design.Api.Events;
using Security.Design.Api.Repositories;

namespace Security.Design.Api.Handlers.Commands
{
    public class AirTicketPriceUpdateCommandHandler(IValidator<AirTicketPriceUpdateDTO> validatorUpdatePrice, IAirfareRepository _airfareRepository, IEventStore eventStore) : IRequestHandler<AirTicketPriceUpdateDTO, AirFareUpdateResponse>
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

            model!.AlterarDados(request.Valor);
            model = await _airfareRepository.UpdateAsync(model!, cancellationToken);

            var eventTwo = eventStore.ObterEventoPorIdModel<BuyTicketAirfaceVersionTwoEvent>(model.Id);

            if (eventTwo == null)
            {
                var eventOne = eventStore.ObterEventoPorIdModel<BuyTicketAirfaceVersionOneEvent>(model.Id);

            }

            eventStore.AdicionarEvento(new BuyTicketAirfaceVersionTwoEvent(model.Id, model.Origem, model.Destino, model.Valor, model.Validade, request.HeadersApp.CorrelationID!.Value));

            return new AirFareUpdateResponse(true, default!);
        }
    }
}
