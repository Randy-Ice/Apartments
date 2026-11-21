namespace Apartments.Features.V1.Addresses.DTO
{
    public class GetAddressDTO
    {
        public Guid Id { get; set; }
        public string City { get; set; }
        public string Location { get; set; }
        public string State { get; set; }
        public string Zipcode { get; set; }
    }
}
