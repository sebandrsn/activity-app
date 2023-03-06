namespace ActivityApp.Contracts
{
    public class HikingTrailRequest
    {
        public string? Name { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
        public double? Length { get; set; }
    }
}
