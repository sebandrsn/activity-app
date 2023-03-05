namespace ActivityApp.Api.Models
{
    public class ResortModel
    {
        public Guid? Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; } = null!;
        public AddressModel Address { get; set; } = null!;
    }
}
