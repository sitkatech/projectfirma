//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProjectFundingSourceBudget]
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectFirmaModels.Models
{
    public class ProjectFundingSourceBudgetConfiguration : EntityTypeConfiguration<ProjectFundingSourceBudget>
    {
        public ProjectFundingSourceBudgetConfiguration() : this("dbo"){}

        public ProjectFundingSourceBudgetConfiguration(string schema)
        {
            ToTable("ProjectFundingSourceBudget", schema);
            HasKey(x => x.ProjectFundingSourceBudgetID);
            Property(x => x.ProjectFundingSourceBudgetID).HasColumnName(@"ProjectFundingSourceBudgetID").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.TenantID).HasColumnName(@"TenantID").HasColumnType("int").IsRequired();
            Property(x => x.ProjectID).HasColumnName(@"ProjectID").HasColumnType("int").IsRequired();
            Property(x => x.FundingSourceID).HasColumnName(@"FundingSourceID").HasColumnType("int").IsRequired();
            Property(x => x.SecuredAmount).HasColumnName(@"SecuredAmount").HasColumnType("money").IsOptional().HasPrecision(19,4);
            Property(x => x.TargetedAmount).HasColumnName(@"TargetedAmount").HasColumnType("money").IsOptional().HasPrecision(19,4);

            // Foreign keys
            HasRequired(a => a.Project).WithMany(b => b.ProjectFundingSourceBudgets).HasForeignKey(c => c.ProjectID).WillCascadeOnDelete(false); // FK_ProjectFundingSourceBudget_Project_ProjectID
            HasRequired(a => a.FundingSource).WithMany(b => b.ProjectFundingSourceBudgets).HasForeignKey(c => c.FundingSourceID).WillCascadeOnDelete(false); // FK_ProjectFundingSourceBudget_FundingSource_FundingSourceID
        }
    }
}