namespace ActivityApp.Domain.Entities
{
    public class Address
    {
        public Guid Id { get; set; }
        public string Street { get; set; } = null!;
        public string City { get; set; } = null!;
        public string PostalCode { get; set; } = null!;
    }
}
