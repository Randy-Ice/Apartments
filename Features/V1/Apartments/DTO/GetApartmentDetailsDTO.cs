namespace Apartments.Features.V1.Apartments.DTO
{
    public class GetApartmentDetailsDTO
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string ApartmentType { get; set; }//apartment, studio, ...

        public byte ApartmentNumber { get; set; }
        public ApartmentAddressDTO Address { get; set; }
        //public List<ApartmentImages> Images { get; set; }
        public string? ImageURL { get; set; }


        public decimal Price { get; set; }


        public byte Beds { get; set; }

        public byte Bathrooms { get; set; }

        public short SquareFeet { get; set; }
        public bool HasPool { get; set; }
        public bool HasGym { get; set; }
        public bool HasParking { get; set; }
        public bool HasEvCharging { get; set; }
        public string? SpotsAvailable { get; set; }
        public bool HasPet { get; set; }
        public string PetNote { get; set; }
        public bool IsAvailable { get; set; }//main filter on available, /me to filter on TenantApartment
    }
}
