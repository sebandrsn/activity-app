namespace ActivityApp.Domain
{
    public class Resort
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public Address Address { get; set; } = null!;
    }
}
