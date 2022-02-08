//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[Solicitation]
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectFirmaModels.Models
{
    public class SolicitationConfiguration : EntityTypeConfiguration<Solicitation>
    {
        public SolicitationConfiguration() : this("dbo"){}

        public SolicitationConfiguration(string schema)
        {
            ToTable("Solicitation", schema);
            HasKey(x => x.SolicitationID);
            Property(x => x.SolicitationID).HasColumnName(@"SolicitationID").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.TenantID).HasColumnName(@"TenantID").HasColumnType("int").IsRequired();
            Property(x => x.SolicitationName).HasColumnName(@"SolicitationName").HasColumnType("varchar").IsRequired().IsUnicode(false).HasMaxLength(200);
            Property(x => x.Instructions).HasColumnName(@"Instructions").HasColumnType("varchar").IsOptional();
            Property(x => x.IsActive).HasColumnName(@"IsActive").HasColumnType("bit").IsRequired();

            // Foreign keys

        }
    }
}