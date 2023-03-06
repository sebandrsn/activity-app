namespace ActivityApp.Contracts
{
    public class HikingTrailResponse
    {
        public Guid HikingTrailId { get; set; }
        public string Name { get; set; } = null!;

        public Guid CoordinatesId { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
        public double? Length { get; set; }
    }
}
