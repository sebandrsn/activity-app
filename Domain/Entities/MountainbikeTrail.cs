namespace ActivityApp.Domain.Entities
{
    public class MountainbikeTrail
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public Coordinates Coordinates { get; set; } = null!;
    }
}
