using Security.Design.Api.Models;

namespace Security.Design.Api.Repositories
{
    public interface IAirfareRepository
    {
        public Task<AirfareModel> InsertAsync(AirfareModel model, CancellationToken cancellation);
        public Task<AirfareModel> UpdateAsync(AirfareModel model, CancellationToken cancellation);
        public ValueTask<AirfareModel?> GetByIdAsync(int id, CancellationToken cancellation);
        public Task<bool> AnyAsync(int id, CancellationToken cancellation);
    }
}
