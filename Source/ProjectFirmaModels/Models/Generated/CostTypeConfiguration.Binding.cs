//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[CostType]
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectFirmaModels.Models
{
    public class CostTypeConfiguration : EntityTypeConfiguration<CostType>
    {
        public CostTypeConfiguration() : this("dbo"){}

        public CostTypeConfiguration(string schema)
        {
            ToTable("CostType", schema);
            HasKey(x => x.CostTypeID);
            Property(x => x.CostTypeID).HasColumnName(@"CostTypeID").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.TenantID).HasColumnName(@"TenantID").HasColumnType("int").IsRequired();
            Property(x => x.CostTypeName).HasColumnName(@"CostTypeName").HasColumnType("varchar").IsRequired().IsUnicode(false).HasMaxLength(100);

            // Foreign keys

        }
    }
}