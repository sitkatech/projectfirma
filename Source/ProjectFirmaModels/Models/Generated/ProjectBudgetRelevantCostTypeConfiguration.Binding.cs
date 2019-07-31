//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProjectBudgetRelevantCostType]
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectFirmaModels.Models
{
    public class ProjectBudgetRelevantCostTypeConfiguration : EntityTypeConfiguration<ProjectBudgetRelevantCostType>
    {
        public ProjectBudgetRelevantCostTypeConfiguration() : this("dbo"){}

        public ProjectBudgetRelevantCostTypeConfiguration(string schema)
        {
            ToTable("ProjectBudgetRelevantCostType", schema);
            HasKey(x => x.ProjectBudgetRelevantCostTypeID);
            Property(x => x.ProjectBudgetRelevantCostTypeID).HasColumnName(@"ProjectBudgetRelevantCostTypeID").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.TenantID).HasColumnName(@"TenantID").HasColumnType("int").IsRequired();
            Property(x => x.ProjectID).HasColumnName(@"ProjectID").HasColumnType("int").IsRequired();
            Property(x => x.CostTypeID).HasColumnName(@"CostTypeID").HasColumnType("int").IsRequired();

            // Foreign keys
            HasRequired(a => a.Project).WithMany(b => b.ProjectBudgetRelevantCostTypes).HasForeignKey(c => c.ProjectID).WillCascadeOnDelete(false); // FK_ProjectBudgetRelevantCostType_Project_ProjectID
            HasRequired(a => a.CostType).WithMany(b => b.ProjectBudgetRelevantCostTypes).HasForeignKey(c => c.CostTypeID).WillCascadeOnDelete(false); // FK_ProjectBudgetRelevantCostType_CostType_CostTypeID
        }
    }
}