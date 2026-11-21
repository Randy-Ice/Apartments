using System.ComponentModel.DataAnnotations;

namespace Apartments.Features.V1.Tenants.DTO
{
    public class UpdateTenantDTO
    {
        [Required]

        public string Phone { get; set; }
        [Required]
        public string Email { get; set; }
    }
}
