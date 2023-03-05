namespace ActivityApp.Contracts
{
    public class HikingTrailResponse
    {
        public HikingTrailResponse(
            Guid hikingTrailId,
            string name,
            Guid coordinatesId,
            double latitude,
            double longitude
            )
        {
            HikingTrailId = hikingTrailId;
            Name = name;            
            CoordinatesId = coordinatesId;
            Latitude = latitude;
            Longitude = longitude;
        }

        public Guid HikingTrailId { get; }
        public string Name { get; } = null!;

        public Guid CoordinatesId { get; }
        public double Latitude { get; }
        public double Longitude { get; }
    }
}
