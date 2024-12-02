using System.ComponentModel.DataAnnotations;

namespace NZWalks.Api.Data.Entities
{
    public class WalkEntity //in steen gebeiteld. 1 op 1 gelijk met een database tabel
    {
        public int Id { get; set; }
        public double LengthInKm { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        public int Altidude { get; set; }

        [MaxLength(500)]
        public string Description { get; set; }

        [MaxLength(500)]
        public string PictureUrl { get; set; }

        public DateTime CreatedOn { get; set; }
        public DateTime LastUpdatedOn { get; set; }

        //Navigation properties
        public int RegionId { get; set; }

        public RegionEntity Region { get; set; }

        public int Score { get; set; }
    }
}