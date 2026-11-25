namespace Apartments.Features.V1.ClientApartment.DTO
{
    public class GetClientApartmentDetailsDTO
    {
        public Guid Id { get; set; }

        public Guid TenantId { get; set; }

        public Guid ApartmentId { get; set; }

        public DateOnly CreatedAt { get; set; }

        public string ManagementContact { get; set; }
        public string? Note { get; set; }
    }
}
