using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ServiciiAtmE231A.Models.Mapping
{
    public class StudentiMap : EntityTypeConfiguration<Studenti>
    {
        public StudentiMap()
        {
            // Primary Key
            this.HasKey(t => t.ID_S);

            // Properties
            this.Property(t => t.Nume)
                .IsFixedLength()
                .HasMaxLength(20);

            this.Property(t => t.Prenume)
                .IsFixedLength()
                .HasMaxLength(20);

            this.Property(t => t.Email)
                .IsFixedLength()
                .HasMaxLength(20);

            this.Property(t => t.Nr_tel)
                .IsFixedLength()
                .HasMaxLength(10);

            this.Property(t => t.Grad_militar)
                .IsFixedLength()
                .HasMaxLength(15);

            this.Property(t => t.Functie)
                .IsFixedLength()
                .HasMaxLength(15);

            // Table & Column Mappings
            this.ToTable("Studenti");
            this.Property(t => t.ID_S).HasColumnName("ID_S");
            this.Property(t => t.ID_C).HasColumnName("ID_C");
            this.Property(t => t.Nume).HasColumnName("Nume");
            this.Property(t => t.Prenume).HasColumnName("Prenume");
            this.Property(t => t.Email).HasColumnName("Email");
            this.Property(t => t.Nr_tel).HasColumnName("Nr_tel");
            this.Property(t => t.Grad_militar).HasColumnName("Grad_militar");
            this.Property(t => t.Camera).HasColumnName("Camera");
            this.Property(t => t.Functie).HasColumnName("Functie");

            // Relationships
            this.HasRequired(t => t.Companii)
                .WithMany(t => t.Studentis)
                .HasForeignKey(d => d.ID_C);

        }
    }
}
