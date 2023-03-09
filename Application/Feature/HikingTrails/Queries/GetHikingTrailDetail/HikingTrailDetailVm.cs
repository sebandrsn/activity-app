namespace ActivityApp.Application.Feature.HikingTrails.Queries.GetHikingTrailDetail
{
    public class HikingTrailDetailVm
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public CoordinatesDto Coordinates { get; set; } = null!;
        public double? Length { get; set; }
    }
}
