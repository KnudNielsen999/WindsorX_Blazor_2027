using Microsoft.EntityFrameworkCore;
using WindsorX_2027.IndkoebsModel;
using WindsorX_2027.LagerModel;

namespace WindsorX_2027.DB_Entity
{
    public class Entity_Database:DbContext
    {
        public Entity_Database(DbContextOptions<Entity_Database> options) : base(options) { }

        // DbSet-egenskaber for dine entiteter
        public DbSet<Lagermodel> LagerData { get; set; }
        public DbSet<IndkobModel> IndkobsOrdre { get; set; }
        public DbSet<OrdreModel> OrdreLinjer { get; set; }
        public DbSet<LeverandorReg> Leverandorer { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IndkobModel>()
                .HasMany(i => i.ordreLinjer)   // Brug ordreLinjer, som er en liste af OrdreModel
                .WithOne()                      // Definer relateret entitet
                .HasForeignKey(o => o.IndkobModelId);  // Tilføj fremmednøgle (kræver IndkobModelId i OrdreModel)
        }


    }


}
