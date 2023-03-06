namespace ActivityApp.Contracts
{
    public class HikingTrailRequest
    {
        public HikingTrailRequest(
            string name,
            double latitude,
            double longitude,
            double length
            )
        {
            Name = name;
            Latitude = latitude;
            Longitude = longitude;
            Length = length;
        }

        public string Name { get; } = null!;
        public double Latitude { get; }
        public double Longitude { get; }
        public double Length { get; }
    }
}
