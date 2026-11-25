using Apartments.Features.V1.Apartments;
using Apartments.Features.V1.Tenants;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Apartments.Features.V1.ClientApartment
{
    [Index(nameof(TenantId))]
    [Index(nameof(ApartmentId))]
    public class ClientToApartment
    {
        public Guid Id { get; set; }
        [Required]
        public Guid TenantId { get; set; }
        [Required]
        public Guid ApartmentId { get; set; }
        [Required]
        public DateOnly CreatedAt { get; set; } = DateOnly.FromDateTime(DateTime.UtcNow);
        [Required]
        public string ManagementContact { get; set; }
        public string? Note { get; set; }

        //associations
        public Tenant Tenant { get; set; }
        public Apartment Apartment { get; set; }
    }
}
