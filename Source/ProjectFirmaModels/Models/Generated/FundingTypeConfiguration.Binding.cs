//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[FundingType]
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectFirmaModels.Models
{
    public class FundingTypeConfiguration : EntityTypeConfiguration<FundingType>
    {
        public FundingTypeConfiguration() : this("dbo"){}

        public FundingTypeConfiguration(string schema)
        {
            ToTable("FundingType", schema);
            HasKey(x => x.FundingTypeID);
            Property(x => x.FundingTypeID).HasColumnName(@"FundingTypeID").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.FundingTypeName).HasColumnName(@"FundingTypeName").HasColumnType("varchar").IsRequired().IsUnicode(false).HasMaxLength(100);
            Property(x => x.FundingTypeDisplayName).HasColumnName(@"FundingTypeDisplayName").HasColumnType("varchar").IsRequired().IsUnicode(false).HasMaxLength(100);

            // Foreign keys

        }
    }
}