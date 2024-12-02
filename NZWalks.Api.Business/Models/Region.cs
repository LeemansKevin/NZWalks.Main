namespace NZWalks.Api.Business.Models
{
    public class Region
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Climate Climate { get; set; }

        public List<Walk> Walks { get; set; } = new List<Walk>();
    }
}