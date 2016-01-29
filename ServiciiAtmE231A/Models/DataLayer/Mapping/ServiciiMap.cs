using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ServiciiAtmE231A.Models.Mapping
{
    public class ServiciiMap : EntityTypeConfiguration<Servicii>
    {
        public ServiciiMap()
        {
            // Primary Key
            this.HasKey(t => t.ID_serv);

            // Properties
            // Table & Column Mappings
            this.ToTable("Servicii");
            this.Property(t => t.ID_serv).HasColumnName("ID_serv");
            this.Property(t => t.ID_ls).HasColumnName("ID_ls");
            this.Property(t => t.ID_S).HasColumnName("ID_S");
            this.Property(t => t.Data).HasColumnName("Data");
            this.Property(t => t.Check).HasColumnName("Check");

            // Relationships
            this.HasRequired(t => t.Lista_servicii)
                .WithMany(t => t.Serviciis)
                .HasForeignKey(d => d.ID_ls);
            this.HasRequired(t => t.Studenti)
                .WithMany(t => t.Serviciis)
                .HasForeignKey(d => d.ID_S);

        }
    }
}
