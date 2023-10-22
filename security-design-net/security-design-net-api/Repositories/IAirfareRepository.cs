using Security.Design.Net.Api.Context;
using Security.Design.Net.Api.Models;

namespace Security.Design.Net.Api.Repositories
{
    public interface IAirfareRepository
    {
        public Task<AirfareModel> InsertAsync(AirfareModel model, CancellationToken cancellation);
    }

    public record PassagemRepository(ExampleDbContext exampleDbContext) : IAirfareRepository
    {
        public async Task<AirfareModel> InsertAsync(AirfareModel model, CancellationToken cancellation)
        {
            exampleDbContext.AirfareModels.Add(model);
            await exampleDbContext.SaveChangesAsync(cancellation);
            return model;
        }
    }
}
