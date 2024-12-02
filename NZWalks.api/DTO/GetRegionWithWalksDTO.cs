namespace NZWalks.api.DTO
{
    public class GetRegionWithWalksDTO
    {
        public string RegionName { get; set; }
        public string Climate { get; set; }
        public List<GetWalkDTO> Walks { get; set; }
    }
}