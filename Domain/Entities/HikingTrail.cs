using ActivityApp.Domain.Interfaces;

namespace ActivityApp.Domain.Entities
{
    public class HikingTrail : ITrail
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public Coordinates Coordinates { get; set; } = null!;
        public double? Length { get; set; }
    }
}
