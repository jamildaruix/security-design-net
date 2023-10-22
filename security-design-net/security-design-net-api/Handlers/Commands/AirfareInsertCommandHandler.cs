using MediatR;
using Security.Design.Net.Api.DTOs.AirfareDTO;
using Security.Design.Net.Api.Events;
using Security.Design.Net.Api.Models;
using Security.Design.Net.Api.Repositories;

namespace Security.Design.Net.Api.Handlers.Commands
{
    public class AirfareInsertCommandHandler(IAirfareRepository _airfareRepository, IEventStore eventStore) : IRequestHandler<AirfareCreateDTO, bool>
    {
        public async Task<bool> Handle(AirfareCreateDTO request, CancellationToken cancellationToken )
        {
            AirfareModel model = new(0, request.Origem, request.Destino, request.Valor, request.Validade, true);

            model = await _airfareRepository.InsertAsync(model, cancellationToken);

            eventStore.AdicionarEvento(new BuyTicketAirfaceVersionOneEvent(model.Id, model.Destino, model.Valor));


            return model.Id > 0;
        }
    }
}
