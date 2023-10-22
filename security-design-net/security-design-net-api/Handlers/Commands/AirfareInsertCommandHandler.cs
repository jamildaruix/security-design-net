using MediatR;
using Security.Design.Net.Api.DTOs.AirfareDTO;
using Security.Design.Net.Api.Models;
using Security.Design.Net.Api.Repositories;

namespace Security.Design.Net.Api.Handlers.Commands
{
    public class AirfareInsertCommandHandler(IAirfareRepository _airfareRepository) : IRequestHandler<AirfareCreateDTO, bool>
    {
        public async Task<bool> Handle(AirfareCreateDTO request, CancellationToken cancellationToken )
        {
            AirfareModel model = new(0, request.Origem, request.Destino, request.Valor, request.Validade, true);

            model = await _airfareRepository.InsertAsync(model, cancellationToken);

            return model.Id > 0;
        }
    }
}
