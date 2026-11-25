namespace Apartments.Features.V1.ClientApartment.DTO
{
    public class GetClientApartmentSimpleDTO
    {
        public Guid Id { get; set; }

        public Guid TenantId { get; set; }

        public Guid ApartmentId { get; set; }

        public DateOnly CreatedAt { get; set; } = DateOnly.FromDateTime(DateTime.UtcNow);


    }
}
