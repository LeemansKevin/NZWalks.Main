using System.ComponentModel.DataAnnotations;

namespace NZWalks.api.DTO
{
    public class AddRegionDTO
    {
        [Required]
        [MinLength(3, ErrorMessage = "Naam moet minstens 3 characters lang zijn.")]
        public string Name { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Climaat mag niet negatief zijn.")]
        public int Climate { get; set; }
    }
}