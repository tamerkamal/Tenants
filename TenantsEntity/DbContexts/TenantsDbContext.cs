using Microsoft.EntityFrameworkCore;

namespace Tenants.Models.DbContexts
{
    public class TenantsDbContext : DbContext
    {
        public TenantsDbContext()
        {

        }

        public TenantsDbContext(DbContextOptions<TenantsDbContext> options)
           : base(options)
        {
        }
    }
}
