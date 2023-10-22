using MediatR;
using Security.Design.Net.Api.DTOs.AirfareDTO;
using Security.Design.Net.Api.Repositories;

namespace Security.Design.Net.Api.Handlers.Commands
{
    public class AirTicketPriceUpdateCommandHandler(IAirfareRepository _airfareRepository) : IRequestHandler<AirTicketPriceUpdateDTO, bool>
    {
        public async Task<bool> Handle(AirTicketPriceUpdateDTO request, CancellationToken cancellationToken)
        {
            var model = await _airfareRepository.GetByIdAsync(request.Id, cancellationToken);

            //model.Valor = request.Valor;

            model = await _airfareRepository.UpdateAsync(model!, cancellationToken);

            return true;
        }
    }
}
