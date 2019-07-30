//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProjectExpenditureRelevantCostType]
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectFirmaModels.Models
{
    public class ProjectExpenditureRelevantCostTypeConfiguration : EntityTypeConfiguration<ProjectExpenditureRelevantCostType>
    {
        public ProjectExpenditureRelevantCostTypeConfiguration() : this("dbo"){}

        public ProjectExpenditureRelevantCostTypeConfiguration(string schema)
        {
            ToTable("ProjectExpenditureRelevantCostType", schema);
            HasKey(x => x.ProjectExpenditureRelevantCostTypeID);
            Property(x => x.ProjectExpenditureRelevantCostTypeID).HasColumnName(@"ProjectExpenditureRelevantCostTypeID").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.TenantID).HasColumnName(@"TenantID").HasColumnType("int").IsRequired();
            Property(x => x.ProjectID).HasColumnName(@"ProjectID").HasColumnType("int").IsRequired();
            Property(x => x.CostTypeID).HasColumnName(@"CostTypeID").HasColumnType("int").IsRequired();

            // Foreign keys
            HasRequired(a => a.Project).WithMany(b => b.ProjectExpenditureRelevantCostTypes).HasForeignKey(c => c.ProjectID).WillCascadeOnDelete(false); // FK_ProjectExpenditureRelevantCostType_Project_ProjectID
            HasRequired(a => a.CostType).WithMany(b => b.ProjectExpenditureRelevantCostTypes).HasForeignKey(c => c.CostTypeID).WillCascadeOnDelete(false); // FK_ProjectExpenditureRelevantCostType_CostType_CostTypeID
        }
    }
}