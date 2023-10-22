using Security.Design.Net.Api.Context;
using Security.Design.Net.Api.Models;

namespace Security.Design.Net.Api.Repositories
{
    public record AirfareRepository(ExampleDbContext exampleDbContext) : IAirfareRepository
    {
        public async Task<AirfareModel> InsertAsync(AirfareModel model, CancellationToken cancellation)
        {
            exampleDbContext.Add(model);
            await exampleDbContext.SaveChangesAsync(cancellation);
            return model;
        }

        public async Task<AirfareModel> UpdateAsync(AirfareModel model, CancellationToken cancellation)
        {
            exampleDbContext.Update(model);
            await exampleDbContext.SaveChangesAsync(cancellation);
            return model;
        }
    }
}
