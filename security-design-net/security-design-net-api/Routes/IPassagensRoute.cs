using Security.Design.Net.Api.DTOs.PassagemDTO;

namespace Security.Design.Net.Api.Routes
{
    public interface IPassagensRoute
    {
        public Task<IResult> InserirAsync(PassagemCreateDTO dto, CancellationToken token);
    }
}
