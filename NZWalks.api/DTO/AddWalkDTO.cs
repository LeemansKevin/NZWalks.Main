using System.ComponentModel.DataAnnotations;

namespace NZWalks.api.DTO
{
    public class AddWalkDTO
    {
        [Required]
        [MinLength(3, ErrorMessage = "Naam moet minstens 3 characters lang zijn.")]
        public string Name { get; set; }

        public string Description { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Een wandeling van 0km is geen wandeling makker")]
        public double LengthInKm { get; set; }

        [Range(0, 8000, ErrorMessage = "Niet te hoog van stapel lopen vriend of gaat ge vrijwillig onder de grond ?")]
        public int Altitude { get; set; }

        public string PictureUrl { get; set; }
        public int RegionId { get; set; }
    }
}