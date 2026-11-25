using Apartments.Features.V1.Apartments;
using Apartments.Features.V1.Tenants;
using Microsoft.EntityFrameworkCore;

namespace Apartments.Features.V1.ClientApartment
{
    [Index(nameof(TenantId))]
    [Index(nameof(ApartmentId))]
    public class ClientToApartment
    {
        public Guid Id { get; set; }
        public Guid TenantId { get; set; }
        public Guid ApartmentId { get; set; }
        public DateOnly CreatedAt { get; set; } = DateOnly.FromDateTime(DateTime.UtcNow);
        public string ManagementContact { get; set; }
        public string Note { get; set; }

        //associations
        public Tenant Tenant { get; set; }
        public Apartment Apartment { get; set; }
    }
}
