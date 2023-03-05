namespace ActivityApp.Application.DTOs
{
    public class HikingTrailDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public CoordinatesDTO Coordinates { get; set; } = null!;
        public double? Length { get; set; }
    }
}