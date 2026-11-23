namespace Apartments.Features.V1.Apartments.DTO
{
    public class GetApartmentSimpleDTO
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string ApartmentType { get; set; }//apartment, studio, ...

        public ApartmentAddressDTO Address { get; set; }
        //public List<ApartmentImages> Images { get; set; }
        public string? ImageURL { get; set; }


        public decimal Price { get; set; }


        public byte Beds { get; set; }

        public byte Bathrooms { get; set; }


    }
}
