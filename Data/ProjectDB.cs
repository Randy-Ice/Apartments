using Apartments.Features.V1.Addresses;
using Microsoft.EntityFrameworkCore;

namespace Apartments.Data
{
    public class ProjectDB : DbContext
    {
        public ProjectDB(DbContextOptions<ProjectDB> options) : base(options)
        {

        }
        public DbSet<Address> Addresses { get; set; }
    }
}
