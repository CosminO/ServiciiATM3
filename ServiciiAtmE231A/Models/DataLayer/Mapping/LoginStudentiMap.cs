using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ServiciiAtmE231A.Models.Mapping
{
    public class LoginStudentiMap : EntityTypeConfiguration<LoginStudenti>
    {
        public LoginStudentiMap()
        {
            // Primary Key
            this.HasKey(t => t.Id_S);

            // Properties
            this.Property(t => t.Id_S)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.Parola)
                .HasMaxLength(40);

            // Table & Column Mappings
            this.ToTable("LoginStudenti");
            this.Property(t => t.Id_S).HasColumnName("Id_S");
            this.Property(t => t.Parola).HasColumnName("Parola");
        }
    }
}
