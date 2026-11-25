using Apartments.Features.V1.Addresses;
using Apartments.Features.V1.Apartments;
using Apartments.Features.V1.Tenants;
using Microsoft.EntityFrameworkCore;

namespace Apartments.Data
{
    public class ProjectDB : DbContext
    {
        public ProjectDB(DbContextOptions<ProjectDB> options) : base(options)
        {

        }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Tenant> Tenants { get; set; }
        public DbSet<Apartment> Apartments { get; set; }
    }
}
