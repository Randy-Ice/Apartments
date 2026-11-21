using Microsoft.EntityFrameworkCore;

namespace Apartments.Data
{
    public class ProjectDB : DbContext
    {
        public ProjectDB(DbContextOptions<ProjectDB> options) : base(options)
        {

        }
    }
}
