using Microsoft.EntityFrameworkCore;
using WindsorX_2027.LagerModel;

namespace WindsorX_2027.DB_Entity
{
    public class Entity_Database:DbContext
    {
        public Entity_Database(DbContextOptions<Entity_Database> options) : base(options) { }

        // DbSet-egenskaber for dine entiteter
        public DbSet<Lagermodel> LagerData { get; set; }
    }
}
