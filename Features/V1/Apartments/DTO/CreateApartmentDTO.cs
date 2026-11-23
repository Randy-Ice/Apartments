using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Apartments.Features.V1.Apartments.DTO
{
    public class CreateApartmentDTO
    {

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
        //public List<ApartmentImages> Images { get; set; }
        public string? ImageURL { get; set; }

        [Required]
        [Precision(6, 2)] //1234.56
        public decimal Price { get; set; }

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

    }
}
