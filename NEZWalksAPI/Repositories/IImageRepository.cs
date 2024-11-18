using NEZWalksAPI.Models.Domain;

namespace NEZWalksAPI.Repositories
{
    public interface IImageRepository
    {
        Task<Image> Upload(Image image);
    }
}
