using Apartments.Features.V1.Addresses;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Apartments.Features.V1.Apartments
{
    [Index(nameof(Name))]
    [Index(nameof(Beds))]
    [Index(nameof(Price))]
    [Index(nameof(ApartmentType))]
    public class Apartment
    {
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string ApartmentType { get; set; }//apartment, studio, ...
        [Required]
        [Range(1, 50)]
        public byte ApartmentNumber { get; set; }
        public Guid AddressId { get; set; }

        [Required]
        [Precision(6, 2)] //1234.56
        public double Price { get; set; }

        [Required]
        public byte Beds { get; set; }
        [Required]
        public byte Bathrooms { get; set; }
        [Required]
        public short SquareFeet { get; set; }
        public bool HasPool { get; set; }
        public bool HasGym { get; set; }
        public bool HasParking { get; set; }
        public bool HasEvCharging { get; set; }
        public string? SpotsAvailable { get; set; }
        public bool HasPet { get; set; }
        public string PetNote { get; set; }
        public bool IsAvailable { get; set; }//main filter on available, /me to filter on TenantApartment ID

        //associations here
        public Address Address { get; set; }
    }
}
