namespace NZWalks.api.DTO
{
    public class GetWalkDTO
    {
        public int Id { get; set; }
        public string WalkName { get; set; }
        public string Description { get; set; }
        public string Climate { get; set; }
        public int Altitude { get; set; }
        public string PictureURL { get; set; }
        public int LengthInKm { get; set; }
        public string Region { get; set; }

        
    }
}