using Security.Design.Net.Api.Models;

namespace Security.Design.Net.Api.Repositories
{
    public interface IAirfareRepository
    {
        public Task<AirfareModel> InsertAsync(AirfareModel model, CancellationToken cancellation);
        public Task<AirfareModel> UpdateAsync(AirfareModel model, CancellationToken cancellation);
    }
}
