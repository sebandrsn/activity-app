using ActivityApp.Domain.Entities;

namespace ActivityApp.Domain.Interfaces
{
    public interface ITrail
    {
        public double? Length { get; set; }
        public Coordinates Coordinates { get; set; }
    }
}
