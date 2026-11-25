using System.ComponentModel.DataAnnotations;

namespace Apartments.Features.V1.ClientApartment.DTO
{
    public class CreateClientApartmentDTO
    {

        [Required]
        public Guid TenantId { get; set; }
        [Required]
        public Guid ApartmentId { get; set; }
        [Required]
        public DateOnly CreatedAt { get; set; } = DateOnly.FromDateTime(DateTime.UtcNow);
        [Required]
        public string ManagementContact { get; set; }
        public string? Note { get; set; }
    }
}
