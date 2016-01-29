using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ServiciiAtmE231A.Models.Mapping
{
    public class Apel_searaMap : EntityTypeConfiguration<Apel_seara>
    {
        public Apel_searaMap()
        {
            // Primary Key
            this.HasKey(t => t.ID_as);

            // Properties
            // Table & Column Mappings
            this.ToTable("Apel_seara");
            this.Property(t => t.ID_as).HasColumnName("ID_as");
            this.Property(t => t.ID_C).HasColumnName("ID_C");
            this.Property(t => t.Efectiv_control).HasColumnName("Efectiv_control");
            this.Property(t => t.Efectiv_prezenti).HasColumnName("Efectiv_prezenti");
            this.Property(t => t.Efectiv_absenti).HasColumnName("Efectiv_absenti");
            this.Property(t => t.Data).HasColumnName("Data");

            // Relationships
            this.HasRequired(t => t.Companii)
                .WithMany(t => t.Apel_seara)
                .HasForeignKey(d => d.ID_C);

        }
    }
}
