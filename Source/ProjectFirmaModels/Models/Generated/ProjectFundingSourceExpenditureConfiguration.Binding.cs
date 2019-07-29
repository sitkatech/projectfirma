//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProjectFundingSourceExpenditure]
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectFirmaModels.Models
{
    public class ProjectFundingSourceExpenditureConfiguration : EntityTypeConfiguration<ProjectFundingSourceExpenditure>
    {
        public ProjectFundingSourceExpenditureConfiguration() : this("dbo"){}

        public ProjectFundingSourceExpenditureConfiguration(string schema)
        {
            ToTable("ProjectFundingSourceExpenditure", schema);
            HasKey(x => x.ProjectFundingSourceExpenditureID);
            Property(x => x.ProjectFundingSourceExpenditureID).HasColumnName(@"ProjectFundingSourceExpenditureID").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.TenantID).HasColumnName(@"TenantID").HasColumnType("int").IsRequired();
            Property(x => x.ProjectID).HasColumnName(@"ProjectID").HasColumnType("int").IsRequired();
            Property(x => x.FundingSourceID).HasColumnName(@"FundingSourceID").HasColumnType("int").IsRequired();
            Property(x => x.CalendarYear).HasColumnName(@"CalendarYear").HasColumnType("int").IsRequired();
            Property(x => x.ExpenditureAmount).HasColumnName(@"ExpenditureAmount").HasColumnType("money").IsRequired().HasPrecision(19,4);
            Property(x => x.CostTypeID).HasColumnName(@"CostTypeID").HasColumnType("int").IsOptional();

            // Foreign keys
            HasRequired(a => a.Project).WithMany(b => b.ProjectFundingSourceExpenditures).HasForeignKey(c => c.ProjectID).WillCascadeOnDelete(false); // FK_ProjectFundingSourceExpenditure_Project_ProjectID
            HasRequired(a => a.FundingSource).WithMany(b => b.ProjectFundingSourceExpenditures).HasForeignKey(c => c.FundingSourceID).WillCascadeOnDelete(false); // FK_ProjectFundingSourceExpenditure_FundingSource_FundingSourceID
            HasOptional(a => a.CostType).WithMany(b => b.ProjectFundingSourceExpenditures).HasForeignKey(c => c.CostTypeID).WillCascadeOnDelete(false); // FK_ProjectFundingSourceExpenditure_CostType_CostTypeID
        }
    }
}