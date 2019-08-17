//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProjectRelevantCostType]
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectFirmaModels.Models
{
    public class ProjectRelevantCostTypeConfiguration : EntityTypeConfiguration<ProjectRelevantCostType>
    {
        public ProjectRelevantCostTypeConfiguration() : this("dbo"){}

        public ProjectRelevantCostTypeConfiguration(string schema)
        {
            ToTable("ProjectRelevantCostType", schema);
            HasKey(x => x.ProjectRelevantCostTypeID);
            Property(x => x.ProjectRelevantCostTypeID).HasColumnName(@"ProjectRelevantCostTypeID").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.TenantID).HasColumnName(@"TenantID").HasColumnType("int").IsRequired();
            Property(x => x.ProjectID).HasColumnName(@"ProjectID").HasColumnType("int").IsRequired();
            Property(x => x.CostTypeID).HasColumnName(@"CostTypeID").HasColumnType("int").IsRequired();
            Property(x => x.ProjectRelevantCostTypeGroupID).HasColumnName(@"ProjectRelevantCostTypeGroupID").HasColumnType("int").IsRequired();

            // Foreign keys
            HasRequired(a => a.Project).WithMany(b => b.ProjectRelevantCostTypes).HasForeignKey(c => c.ProjectID).WillCascadeOnDelete(false); // FK_ProjectRelevantCostType_Project_ProjectID
            HasRequired(a => a.CostType).WithMany(b => b.ProjectRelevantCostTypes).HasForeignKey(c => c.CostTypeID).WillCascadeOnDelete(false); // FK_ProjectRelevantCostType_CostType_CostTypeID
        }
    }
}