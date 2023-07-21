namespace ActivityApp.Application.Feature.HikingTrails.Queries.GetHikingTrailsList
{
    public class HikingTrailListVm
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
    }
}
