using NEZWalksAPI.Models.Domain;

namespace NEZWalksAPI.Repositories
{
    public interface IRegionRepository
    {
        Task<List<Region>>GetAllAsync();
    }
}
