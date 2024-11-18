using NEZWalksAPI.Data;
using NEZWalksAPI.Models.Domain;

namespace NEZWalksAPI.Repositories
{
    public class LocalImageRepository : IImageRepository
    {
        private readonly IWebHostEnvironment webHostEnvironment;
        
        private readonly NZWalksDbContext dbContext;
        private readonly IHttpContextAccessor httpContextAccessor;

        public LocalImageRepository(IWebHostEnvironment webHostEnvironment,IHttpContextAccessor httpContextAccessor,NZWalksDbContext dbContext)
        {
            this.webHostEnvironment = webHostEnvironment;
            this.dbContext = dbContext;
            this.httpContextAccessor = httpContextAccessor;
        }
        public async Task<Image> Upload(Image image)
        {
            var localFilePath = Path.Combine(webHostEnvironment.ContentRootPath, "Images",$"{image.FileName}" );

            //Upload image to Local Path
            using var stream = new FileStream(localFilePath, FileMode.Create);

            await image.File.CopyToAsync(stream);

            //https//localhost:1234/images/image.jpg

            var urlFilePath = $"{httpContextAccessor.HttpContext.Request.Scheme}://{httpContextAccessor.HttpContext.Request.Host}{httpContextAccessor.HttpContext.Request.PathBase}/Images/{image.FileName}";

            image.FilePath = urlFilePath;

            //Add Image to the Image Table
            await dbContext.AddAsync(image);
            await dbContext.SaveChangesAsync();

            return image;
        }
    }
}
