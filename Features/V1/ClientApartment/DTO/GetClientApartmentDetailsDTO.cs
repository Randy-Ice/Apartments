using Apartments.Features.V1.Apartments.DTO;
using Apartments.Features.V1.Tenants.DTO;

namespace Apartments.Features.V1.ClientApartment.DTO
{
    public class GetClientApartmentDetailsDTO
    {
        public Guid Id { get; set; }

        public GetTenantDTO Tenant { get; set; }

        public GetApartmentDetailsDTO Apartment { get; set; }

        public DateOnly CreatedAt { get; set; }

        public string ManagementContact { get; set; }
        public string? Note { get; set; }
    }
}
