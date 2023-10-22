using MediatR;
using Security.Design.Net.Api.DTOs.PassagemDTO;
using Security.Design.Net.Api.Models;
using Security.Design.Net.Api.Repositories;

namespace Security.Design.Net.Api.Handlers.Commands
{
    public class PassagemInserirCommandHandler(IPassagemRepository _passagemRepository) : IRequestHandler<PassagemCreateDTO, bool>
    {
        public async Task<bool> Handle(PassagemCreateDTO request, CancellationToken cancellationToken )
        {
            PassagemModel model = new(0, request.origem, request.destino, request.valor, request.validade, true);
            model = await _passagemRepository.InsertAsync(model, cancellationToken);

            return model.Id > 0;
        }
    }
}
