namespace ActivityApp.Contracts
{
    public class HikingTrailRequest
    {
        public HikingTrailRequest(
            string name,
            double latitude,
            double longitude
            )
        {
            Name = name;
            Latitude = latitude;
            Longitude = longitude;
        }

        public string Name { get; } = null!;
        public double Latitude { get; }
        public double Longitude { get; }
    }
}
