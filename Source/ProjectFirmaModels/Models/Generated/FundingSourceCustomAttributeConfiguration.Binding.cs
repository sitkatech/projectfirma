//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[FundingSourceCustomAttribute]
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectFirmaModels.Models
{
    public class FundingSourceCustomAttributeConfiguration : EntityTypeConfiguration<FundingSourceCustomAttribute>
    {
        public FundingSourceCustomAttributeConfiguration() : this("dbo"){}

        public FundingSourceCustomAttributeConfiguration(string schema)
        {
            ToTable("FundingSourceCustomAttribute", schema);
            HasKey(x => x.FundingSourceCustomAttributeID);
            Property(x => x.FundingSourceCustomAttributeID).HasColumnName(@"FundingSourceCustomAttributeID").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.TenantID).HasColumnName(@"TenantID").HasColumnType("int").IsRequired();
            Property(x => x.FundingSourceID).HasColumnName(@"FundingSourceID").HasColumnType("int").IsRequired();
            Property(x => x.FundingSourceCustomAttributeTypeID).HasColumnName(@"FundingSourceCustomAttributeTypeID").HasColumnType("int").IsRequired();

            // Foreign keys
            HasRequired(a => a.FundingSource).WithMany(b => b.FundingSourceCustomAttributes).HasForeignKey(c => c.FundingSourceID).WillCascadeOnDelete(false); // FK_FundingSourceCustomAttribute_FundingSource_FundingSourceID
            HasRequired(a => a.FundingSourceCustomAttributeType).WithMany(b => b.FundingSourceCustomAttributes).HasForeignKey(c => c.FundingSourceCustomAttributeTypeID).WillCascadeOnDelete(false); // FK_FundingSourceCustomAttribute_FundingSourceCustomAttributeType_FundingSourceCustomAttributeTypeID
        }
    }
}