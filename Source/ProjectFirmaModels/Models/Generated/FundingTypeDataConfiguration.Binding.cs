//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[FundingTypeData]
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectFirmaModels.Models
{
    public class FundingTypeDataConfiguration : EntityTypeConfiguration<FundingTypeData>
    {
        public FundingTypeDataConfiguration() : this("dbo"){}

        public FundingTypeDataConfiguration(string schema)
        {
            ToTable("FundingTypeData", schema);
            HasKey(x => x.FundingTypeDataID);
            Property(x => x.FundingTypeDataID).HasColumnName(@"FundingTypeDataID").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.TenantID).HasColumnName(@"TenantID").HasColumnType("int").IsRequired();
            Property(x => x.FundingTypeID).HasColumnName(@"FundingTypeID").HasColumnType("int").IsRequired();
            Property(x => x.FundingTypeDisplayName).HasColumnName(@"FundingTypeDisplayName").HasColumnType("varchar").IsRequired().IsUnicode(false).HasMaxLength(100);
            Property(x => x.FundingTypeShortName).HasColumnName(@"FundingTypeShortName").HasColumnType("varchar").IsRequired().IsUnicode(false).HasMaxLength(20);
            Property(x => x.SortOrder).HasColumnName(@"SortOrder").HasColumnType("int").IsRequired();

            // Foreign keys
            HasRequired(a => a.FundingType).WithMany(b => b.FundingTypeDatas).HasForeignKey(c => c.FundingTypeID).WillCascadeOnDelete(false); // FK_FundingTypeData_FundingType_FundingTypeID
        }
    }
}