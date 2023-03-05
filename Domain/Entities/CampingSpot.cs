namespace ActivityApp.Domain.Entities
{
    public class CampingSpot
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public Coordinates Coordinates { get; set; } = null!;
    }
}
