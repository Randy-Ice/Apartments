namespace Apartments.Features.V1.ClientApartment.DTO
{
    public class ApartmentAddressDTO
    {
        public Guid Id { get; set; }
        public string City { get; set; }
        public string Location { get; set; }
        public string State { get; set; }
        public string Zipcode { get; set; }
    }
}
