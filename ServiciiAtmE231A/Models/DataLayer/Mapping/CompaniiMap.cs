using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ServiciiAtmE231A.Models.Mapping
{
    public class CompaniiMap : EntityTypeConfiguration<Companii>
    {
        public CompaniiMap()
        {
            // Primary Key
            this.HasKey(t => t.ID_C);

            // Properties
            this.Property(t => t.An_studii)
                .IsFixedLength()
                .HasMaxLength(3);

            // Table & Column Mappings
            this.ToTable("Companii");
            this.Property(t => t.ID_C).HasColumnName("ID_C");
            this.Property(t => t.ID_com).HasColumnName("ID_com");
            this.Property(t => t.An_studii).HasColumnName("An_studii");

            // Relationships
            this.HasOptional(t => t.Comandanti)
                .WithMany(t => t.Companiis)
                .HasForeignKey(d => d.ID_com);

        }
    }
}
