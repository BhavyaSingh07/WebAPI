using System.ComponentModel.DataAnnotations;

namespace NZWalksAPI.Models.DTO
{
    public class UpdateRegionRequest
    {
        [Required]
        [MaxLength(3, ErrorMessage = "Code cannot be more than 3 characters")]
        public string Code { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        public string? RegionImageUrl { get; set; }
    }
}
