using Security.Design.Net.Api.Context;
using Security.Design.Net.Api.Models;

namespace Security.Design.Net.Api.Repositories
{
    public record AirfareRepository(ExampleDbContext exampleDbContext) : IAirfareRepository
    {
        public ValueTask<AirfareModel?> GetByIdAsync(int id, CancellationToken cancellation) => exampleDbContext.AirfareModels.FindAsync(id, cancellation);

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
