using Microsoft.EntityFrameworkCore;

namespace TenantsAPI.Models.DbContexts
{
    public class TenantsAPIDbContext : DbContext
    {
        public TenantsAPIDbContext()
        {

        }

        public TenantsAPIDbContext(DbContextOptions<TenantsAPIDbContext> options)
           : base(options)
        {
        }
    }
}
