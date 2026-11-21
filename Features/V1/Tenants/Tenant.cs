using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Apartments.Features.V1.Tenants
{
    [Index(nameof(FirstName))]
    [Index(nameof(Email))]
    public class Tenant
    {
        public Guid Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        public string Email { get; set; }
    }
}
