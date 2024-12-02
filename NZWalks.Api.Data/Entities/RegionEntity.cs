namespace NZWalks.Api.Data.Entities
{
    public class RegionEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Climate { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime LastUpdatedOn { get; set; }

        public List<WalkEntity> Walks { get; set; }
    }
}