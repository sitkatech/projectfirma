//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[FundingSourceCustomAttributeValue]
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectFirmaModels.Models
{
    public class FundingSourceCustomAttributeValueConfiguration : EntityTypeConfiguration<FundingSourceCustomAttributeValue>
    {
        public FundingSourceCustomAttributeValueConfiguration() : this("dbo"){}

        public FundingSourceCustomAttributeValueConfiguration(string schema)
        {
            ToTable("FundingSourceCustomAttributeValue", schema);
            HasKey(x => x.FundingSourceCustomAttributeValueID);
            Property(x => x.FundingSourceCustomAttributeValueID).HasColumnName(@"FundingSourceCustomAttributeValueID").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.TenantID).HasColumnName(@"TenantID").HasColumnType("int").IsRequired();
            Property(x => x.FundingSourceCustomAttributeID).HasColumnName(@"FundingSourceCustomAttributeID").HasColumnType("int").IsRequired();
            Property(x => x.AttributeValue).HasColumnName(@"AttributeValue").HasColumnType("varchar").IsRequired().IsUnicode(false).HasMaxLength(1000);

            // Foreign keys
            HasRequired(a => a.FundingSourceCustomAttribute).WithMany(b => b.FundingSourceCustomAttributeValues).HasForeignKey(c => c.FundingSourceCustomAttributeID).WillCascadeOnDelete(false); // FK_FundingSourceCustomAttributeValue_FundingSourceCustomAttribute_FundingSourceCustomAttributeID
        }
    }
}