//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProjectFundingSourceRequestUpdate]
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectFirmaModels.Models
{
    public class ProjectFundingSourceRequestUpdateConfiguration : EntityTypeConfiguration<ProjectFundingSourceRequestUpdate>
    {
        public ProjectFundingSourceRequestUpdateConfiguration() : this("dbo"){}

        public ProjectFundingSourceRequestUpdateConfiguration(string schema)
        {
            ToTable("ProjectFundingSourceRequestUpdate", schema);
            HasKey(x => x.ProjectFundingSourceRequestUpdateID);
            Property(x => x.ProjectFundingSourceRequestUpdateID).HasColumnName(@"ProjectFundingSourceRequestUpdateID").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.TenantID).HasColumnName(@"TenantID").HasColumnType("int").IsRequired();
            Property(x => x.ProjectUpdateBatchID).HasColumnName(@"ProjectUpdateBatchID").HasColumnType("int").IsRequired();
            Property(x => x.FundingSourceID).HasColumnName(@"FundingSourceID").HasColumnType("int").IsRequired();
            Property(x => x.SecuredAmount).HasColumnName(@"SecuredAmount").HasColumnType("money").IsOptional().HasPrecision(19,4);
            Property(x => x.UnsecuredAmount).HasColumnName(@"UnsecuredAmount").HasColumnType("money").IsOptional().HasPrecision(19,4);

            // Foreign keys
            HasRequired(a => a.ProjectUpdateBatch).WithMany(b => b.ProjectFundingSourceRequestUpdates).HasForeignKey(c => c.ProjectUpdateBatchID).WillCascadeOnDelete(false); // FK_ProjectFundingSourceRequestUpdate_ProjectUpdateBatch_ProjectUpdateBatchID
            HasRequired(a => a.FundingSource).WithMany(b => b.ProjectFundingSourceRequestUpdates).HasForeignKey(c => c.FundingSourceID).WillCascadeOnDelete(false); // FK_ProjectFundingSourceRequestUpdate_FundingSource_FundingSourceID
        }
    }
}