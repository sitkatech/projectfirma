//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[FundingSourceCustomAttributeType]
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectFirmaModels.Models
{
    public class FundingSourceCustomAttributeTypeConfiguration : EntityTypeConfiguration<FundingSourceCustomAttributeType>
    {
        public FundingSourceCustomAttributeTypeConfiguration() : this("dbo"){}

        public FundingSourceCustomAttributeTypeConfiguration(string schema)
        {
            ToTable("FundingSourceCustomAttributeType", schema);
            HasKey(x => x.FundingSourceCustomAttributeTypeID);
            Property(x => x.FundingSourceCustomAttributeTypeID).HasColumnName(@"FundingSourceCustomAttributeTypeID").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.TenantID).HasColumnName(@"TenantID").HasColumnType("int").IsRequired();
            Property(x => x.FundingSourceCustomAttributeTypeName).HasColumnName(@"FundingSourceCustomAttributeTypeName").HasColumnType("varchar").IsRequired().IsUnicode(false).HasMaxLength(100);
            Property(x => x.FundingSourceCustomAttributeDataTypeID).HasColumnName(@"FundingSourceCustomAttributeDataTypeID").HasColumnType("int").IsRequired();
            Property(x => x.MeasurementUnitTypeID).HasColumnName(@"MeasurementUnitTypeID").HasColumnType("int").IsOptional();
            Property(x => x.IsRequired).HasColumnName(@"IsRequired").HasColumnType("bit").IsRequired();
            Property(x => x.FundingSourceCustomAttributeTypeDescription).HasColumnName(@"FundingSourceCustomAttributeTypeDescription").HasColumnType("varchar").IsOptional().IsUnicode(false).HasMaxLength(200);
            Property(x => x.FundingSourceCustomAttributeTypeOptionsSchema).HasColumnName(@"FundingSourceCustomAttributeTypeOptionsSchema").HasColumnType("varchar").IsOptional();
            Property(x => x.IncludeInFundingSourceGrid).HasColumnName(@"IncludeInFundingSourceGrid").HasColumnType("bit").IsRequired();

            // Foreign keys

        }
    }
}