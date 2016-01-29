using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ServiciiAtmE231A.Models.Mapping
{
    public class ComandantiMap : EntityTypeConfiguration<Comandanti>
    {
        public ComandantiMap()
        {
            // Primary Key
            this.HasKey(t => t.ID_com);

            // Properties
            this.Property(t => t.Nume)
                .IsFixedLength()
                .HasMaxLength(20);

            this.Property(t => t.Prenume)
                .IsFixedLength()
                .HasMaxLength(20);

            this.Property(t => t.Nr_tel)
                .IsFixedLength()
                .HasMaxLength(10);

            this.Property(t => t.Email)
                .IsFixedLength()
                .HasMaxLength(20);

            this.Property(t => t.Adresa)
                .IsFixedLength()
                .HasMaxLength(20);

            this.Property(t => t.Grad_militar)
                .IsFixedLength()
                .HasMaxLength(15);

            // Table & Column Mappings
            this.ToTable("Comandanti");
            this.Property(t => t.ID_com).HasColumnName("ID_com");
            this.Property(t => t.Nume).HasColumnName("Nume");
            this.Property(t => t.Prenume).HasColumnName("Prenume");
            this.Property(t => t.Nr_tel).HasColumnName("Nr_tel");
            this.Property(t => t.Email).HasColumnName("Email");
            this.Property(t => t.Adresa).HasColumnName("Adresa");
            this.Property(t => t.Grad_militar).HasColumnName("Grad_militar");
        }
    }
}
