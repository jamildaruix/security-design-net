using Security.Design.Net.Api.Context;
using Security.Design.Net.Api.Models;

namespace Security.Design.Net.Api.Repositories
{
    public interface IPassagemRepository
    {
        public Task<PassagemModel> InsertAsync(PassagemModel model, CancellationToken cancellation);
    }

    public record PassagemRepository(ExampleDbContext exampleDbContext) : IPassagemRepository
    {
        public async Task<PassagemModel> InsertAsync(PassagemModel model, CancellationToken cancellation)
        {
            exampleDbContext.PassagemModels.Add(model);
            await exampleDbContext.SaveChangesAsync(cancellation);
            return model;
        }
    }
}
