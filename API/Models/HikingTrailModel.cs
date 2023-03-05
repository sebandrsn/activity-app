using ActivityApp.Domain.Entities;

namespace ActivityApp.Api.Models
{
    public class HikingTrailModel
    {
        public Guid? Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; } = null!;
        public Coordinates Coordinates { get; set; } = null!;
    }
}
