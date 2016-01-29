using ServiciiAtmE231A.Models.Mapping;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace ServiciiAtmE231A.Models
{
    public partial class ServiciiATMContext : DbContext
    {
        static ServiciiATMContext()
        {
            Database.SetInitializer<ServiciiATMContext>(null);
        }

        public ServiciiATMContext()
            : base("Name=ServiciiATMContext")
        {
        }

        public DbSet<Apel_seara> Apel_seara { get; set; }
        public DbSet<Comandanti> Comandantis { get; set; }
        public DbSet<Companii> Companiis { get; set; }
        public DbSet<Invoire_apel> Invoire_apel { get; set; }
        public DbSet<Lista_servicii> Lista_servicii { get; set; }
        public DbSet<LoginComandanti_table> LoginComandanti_table { get; set; }
        public DbSet<Servicii> Serviciis { get; set; }
        public DbSet<Studenti> Studentis { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new Apel_searaMap());
            modelBuilder.Configurations.Add(new ComandantiMap());
            modelBuilder.Configurations.Add(new CompaniiMap());
            modelBuilder.Configurations.Add(new Invoire_apelMap());
            modelBuilder.Configurations.Add(new Lista_serviciiMap());
            modelBuilder.Configurations.Add(new LoginComandanti_tableMap());
            modelBuilder.Configurations.Add(new ServiciiMap());
            modelBuilder.Configurations.Add(new StudentiMap());
        }
    }
}
