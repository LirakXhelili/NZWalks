using System.ComponentModel.DataAnnotations;

namespace NEZWalksAPI.Models.DTO
{
    public class AddRegionRequestDto
    {
        [Required]
        [MinLength(2,ErrorMessage ="Code has to be a min of 2 characters")]
        [MaxLength(3,ErrorMessage = "Code has to be a max of 3 characters")]
        public string Code { get; set; }

        [Required]
        [MaxLength(100, ErrorMessage = "Name has to be a max of 100 characters")]
        public string Name { get; set; }

        public string? RegionImageUrl { get; set; }
    }
}

