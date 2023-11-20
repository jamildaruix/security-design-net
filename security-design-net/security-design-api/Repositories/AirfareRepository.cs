using Microsoft.EntityFrameworkCore;
using Security.Design.Api.Context;
using Security.Design.Api.Models;

namespace Security.Design.Api.Repositories
{
    public record AirfareRepository(ExampleDbContext exampleDbContext) : IAirfareRepository
    {
        public Task<bool> AnyAsync(int id, CancellationToken cancellation)
        {
            return exampleDbContext.AirfareModels.AnyAsync(af => af.Id == id, cancellation);
        }

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
