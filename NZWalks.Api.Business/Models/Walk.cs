namespace NZWalks.Api.Business.Models
{
    public class Walk
    {
        public int Id { get; set; }
        public double LengthInKm { get; set; }
        public double LengthInMile => Math.Round(LengthInKm * 0.6213, 4);
        public string Name { get; set; }
        public int Altitude { get; set; }
        public string Description { get; set; }
        public string PictureUrl { get; set; }
        public Region Region { get; set; }
        public int RegionId { get; set; }

        public int Score { get; set; }
        public int ClimateScore { get; set; }
        public int TotaalScore { get; set; }
    }
}