using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ServiciiAtmE231A.Models.Mapping
{
    public class LoginComandanti_tableMap : EntityTypeConfiguration<LoginComandanti_table>
    {
        public LoginComandanti_tableMap()
        {
            // Primary Key
            this.HasKey(t => t.Id_C);

            // Properties
            this.Property(t => t.Id_C)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.Parola)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("LoginComandanti_table");
            this.Property(t => t.Id_C).HasColumnName("Id_C");
            this.Property(t => t.Parola).HasColumnName("Parola");
        }
    }
}
