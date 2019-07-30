//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProjectFundingSourceExpenditureUpdate]
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectFirmaModels.Models
{
    public class ProjectFundingSourceExpenditureUpdateConfiguration : EntityTypeConfiguration<ProjectFundingSourceExpenditureUpdate>
    {
        public ProjectFundingSourceExpenditureUpdateConfiguration() : this("dbo"){}

        public ProjectFundingSourceExpenditureUpdateConfiguration(string schema)
        {
            ToTable("ProjectFundingSourceExpenditureUpdate", schema);
            HasKey(x => x.ProjectFundingSourceExpenditureUpdateID);
            Property(x => x.ProjectFundingSourceExpenditureUpdateID).HasColumnName(@"ProjectFundingSourceExpenditureUpdateID").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.TenantID).HasColumnName(@"TenantID").HasColumnType("int").IsRequired();
            Property(x => x.ProjectUpdateBatchID).HasColumnName(@"ProjectUpdateBatchID").HasColumnType("int").IsRequired();
            Property(x => x.FundingSourceID).HasColumnName(@"FundingSourceID").HasColumnType("int").IsRequired();
            Property(x => x.CalendarYear).HasColumnName(@"CalendarYear").HasColumnType("int").IsRequired();
            Property(x => x.ExpenditureAmount).HasColumnName(@"ExpenditureAmount").HasColumnType("money").IsRequired().HasPrecision(19,4);
            Property(x => x.CostTypeID).HasColumnName(@"CostTypeID").HasColumnType("int").IsOptional();

            // Foreign keys
            HasRequired(a => a.ProjectUpdateBatch).WithMany(b => b.ProjectFundingSourceExpenditureUpdates).HasForeignKey(c => c.ProjectUpdateBatchID).WillCascadeOnDelete(false); // FK_ProjectFundingSourceExpenditureUpdate_ProjectUpdateBatch_ProjectUpdateBatchID
            HasRequired(a => a.FundingSource).WithMany(b => b.ProjectFundingSourceExpenditureUpdates).HasForeignKey(c => c.FundingSourceID).WillCascadeOnDelete(false); // FK_ProjectFundingSourceExpenditureUpdate_FundingSource_FundingSourceID
            HasOptional(a => a.CostType).WithMany(b => b.ProjectFundingSourceExpenditureUpdates).HasForeignKey(c => c.CostTypeID).WillCascadeOnDelete(false); // FK_ProjectFundingSourceExpenditureUpdate_CostType_CostTypeID
        }
    }
}