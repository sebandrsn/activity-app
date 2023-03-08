namespace ActivityApp.Application.Feature.HikingTrails.Queries.GetHikingTrailDetail
{
    public class CoordinatesDto
    {
        public Guid Id { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
    }
}
