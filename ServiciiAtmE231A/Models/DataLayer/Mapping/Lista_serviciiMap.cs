using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ServiciiAtmE231A.Models.Mapping
{
    public class Lista_serviciiMap : EntityTypeConfiguration<Lista_servicii>
    {
        public Lista_serviciiMap()
        {
            // Primary Key
            this.HasKey(t => t.ID_ls);

            // Properties
            this.Property(t => t.Nume_serviciu)
                .IsFixedLength()
                .HasMaxLength(20);

            this.Property(t => t.An_studiu)
                .IsFixedLength()
                .HasMaxLength(3);

            // Table & Column Mappings
            this.ToTable("Lista_servicii");
            this.Property(t => t.ID_ls).HasColumnName("ID_ls");
            this.Property(t => t.Nume_serviciu).HasColumnName("Nume_serviciu");
            this.Property(t => t.Nr_componenta).HasColumnName("Nr_componenta");
            this.Property(t => t.An_studiu).HasColumnName("An_studiu");
        }
    }
}
