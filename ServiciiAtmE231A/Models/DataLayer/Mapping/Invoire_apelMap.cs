using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ServiciiAtmE231A.Models.Mapping
{
    public class Invoire_apelMap : EntityTypeConfiguration<Invoire_apel>
    {
        public Invoire_apelMap()
        {
            // Primary Key
            this.HasKey(t => t.ID_inv);

            // Properties
            // Table & Column Mappings
            this.ToTable("Invoire_apel");
            this.Property(t => t.ID_inv).HasColumnName("ID_inv");
            this.Property(t => t.ID_S).HasColumnName("ID_S");
            this.Property(t => t.Data).HasColumnName("Data");
            this.Property(t => t.Ora_plecare).HasColumnName("Ora_plecare");
            this.Property(t => t.Ora_sosire).HasColumnName("Ora_sosire");

            // Relationships
            this.HasRequired(t => t.Studenti)
                .WithMany(t => t.Invoire_apel)
                .HasForeignKey(d => d.ID_S);

        }
    }
}
