namespace ActivityApp.Domain
{
    public class Address
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Street { get; set; } = null!;
        public string City { get; set; } = null!;
        public string PostalCode { get; set; } = null!;
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}
