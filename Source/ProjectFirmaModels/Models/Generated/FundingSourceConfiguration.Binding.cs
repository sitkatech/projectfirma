//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[FundingSource]
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectFirmaModels.Models
{
    public class FundingSourceConfiguration : EntityTypeConfiguration<FundingSource>
    {
        public FundingSourceConfiguration() : this("dbo"){}

        public FundingSourceConfiguration(string schema)
        {
            ToTable("FundingSource", schema);
            HasKey(x => x.FundingSourceID);
            Property(x => x.FundingSourceID).HasColumnName(@"FundingSourceID").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.TenantID).HasColumnName(@"TenantID").HasColumnType("int").IsRequired();
            Property(x => x.OrganizationID).HasColumnName(@"OrganizationID").HasColumnType("int").IsRequired();
            Property(x => x.FundingSourceName).HasColumnName(@"FundingSourceName").HasColumnType("varchar").IsRequired().IsUnicode(false).HasMaxLength(200);
            Property(x => x.IsActive).HasColumnName(@"IsActive").HasColumnType("bit").IsRequired();
            Property(x => x.FundingSourceDescription).HasColumnName(@"FundingSourceDescription").HasColumnType("varchar").IsOptional().IsUnicode(false).HasMaxLength(500);
            Property(x => x.FundingSourceAmount).HasColumnName(@"FundingSourceAmount").HasColumnType("money").IsOptional().HasPrecision(19,4);

            // Foreign keys
            HasRequired(a => a.Organization).WithMany(b => b.FundingSources).HasForeignKey(c => c.OrganizationID).WillCascadeOnDelete(false); // FK_FundingSource_Organization_OrganizationID
        }
    }
}