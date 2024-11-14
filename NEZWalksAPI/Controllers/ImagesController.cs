using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NEZWalksAPI.Models.DTO;

namespace NEZWalksAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        //POST: /api/Images/Upload
        [HttpPost]
        [Route("Upload")]
        public async Task<IActionResult> Upload([FromForm] ImageUploadRequestDto request)
        {
            ValidateFileUpload(request);

            if (ModelState.IsValid)
            {
                //Use repository to upload image
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
