using Security.Design.Net.Api.Context;
using Security.Design.Net.Api.DTOs.PassagemDTO;
using Security.Design.Net.Api.Models;

namespace Security.Design.Net.Api.Routes
{
    public record PassagensRoute(ExampleDbContext exampleDbContext) : IPassagensRoute
    {

        public async Task<IResult> InserirAsync(PassagemCreateDTO dto, CancellationToken cancellationToken)
        {
            Console.WriteLine("AGUARDANDO ...");


            //await Task.Delay(int.MaxValue, cancellationToken);

            //cancellationToken.ThrowIfCancellationRequested();


            exampleDbContext.PassagemModels.Add(new PassagemModel(0, "teste origem", "teste destino", 1.9M, DateTime.Now, true));
            await exampleDbContext.SaveChangesAsync();

            return TypedResults.Ok();
        }
    }
}
