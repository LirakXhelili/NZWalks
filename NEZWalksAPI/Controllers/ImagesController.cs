using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NEZWalksAPI.Models.Domain;
using NEZWalksAPI.Models.DTO;
using NEZWalksAPI.Repositories;

namespace NEZWalksAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        private readonly IImageRepository imageRepository;

        public ImagesController(IImageRepository imageRepository)
        {
            this.imageRepository = imageRepository;
        }
        //POST: /api/Images/Upload
        [HttpPost]
        [Route("Upload")]
        public async Task<IActionResult> Upload([FromForm] ImageUploadRequestDto request)
        {
            ValidateFileUpload(request);

            if (ModelState.IsValid)
            {
                //Convert DTO to Domain Model
                var imageDomainModel = new Image
                {
                    File = request.File,
                    FileExtention = Path.GetExtension(request.File.FileName),
                    FileSizeInBytes = request.File.Length,
                    FileName = request.FileName,
                    FileDescription = request.FileDescription

                };


                //Use repository to upload image
                await imageRepository.Upload(imageDomainModel);

                return Ok(imageDomainModel);
            }
            return BadRequest(ModelState);
        }

        private void ValidateFileUpload(ImageUploadRequestDto request)
        {
            var allowedExtention = new string[] { ".jpg", ".jpeg", ".png" };

            if (!allowedExtention.Contains(Path.GetExtension(request.File.FileName)))
            {
                ModelState.AddModelError("file", "Unsupported file extention");
            }
            if(request.File.Length > 1048560)
            {
                ModelState.AddModelError("file", "File size more than 10MB! Please upload a smaller file");
            }
        }
    }
}
