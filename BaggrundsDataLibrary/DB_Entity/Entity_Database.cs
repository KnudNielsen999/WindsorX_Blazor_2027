using BaggrundsDataLibrary.LagerTransAktioner;
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
        public DbSet<TransaktionerModel> Transaktioner {  get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           modelBuilder.Entity<IndkobModel>().HasData(
               new IndkobModel { Id=1,ordreNummer="1",kundeNummer="1",leverandorNummer="1"},
               new IndkobModel { Id = 2, ordreNummer = "1", kundeNummer = "1", leverandorNummer = "1" },
                new IndkobModel { Id = 3, ordreNummer = "2", kundeNummer = "1", leverandorNummer = "1" },
               new IndkobModel { Id = 4, ordreNummer = "2", kundeNummer = "1", leverandorNummer = "1" }
               );
            modelBuilder.Entity<Lagermodel>().HasData(
                new Lagermodel { Id=3,vareNummer="2", vareTekst="Motor",vareMaengde=1,enheder="stk", kostPris=2500.00, maxLager=1, minLager=0, bestiltAntal = 0 },
                new Lagermodel { Id = 4, vareNummer = "4", vareTekst = "gevind", vareMaengde = 5, enheder = "mtr", kostPris = 150.00, maxLager = 5, minLager = 1, bestiltAntal=0 }
                );


     modelBuilder.Entity<IndkobModel>()
     .HasMany(i => i.ordreLinjer)
     .WithOne(o => o.IndkobModel)
     .HasForeignKey(o => o.IndkobModelId)
     .OnDelete(DeleteBehavior.Cascade);



        }

    }


}
