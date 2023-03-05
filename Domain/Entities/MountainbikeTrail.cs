using ActivityApp.Domain.Interfaces;

namespace ActivityApp.Domain.Entities
{
    public class MountainbikeTrail : ITrail
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public Coordinates Coordinates { get; set; } = null!;
        public double? Length { get; set; }
    }
}
