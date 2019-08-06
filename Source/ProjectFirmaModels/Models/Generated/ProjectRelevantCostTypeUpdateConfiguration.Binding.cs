//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProjectRelevantCostTypeUpdate]
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectFirmaModels.Models
{
    public class ProjectRelevantCostTypeUpdateConfiguration : EntityTypeConfiguration<ProjectRelevantCostTypeUpdate>
    {
        public ProjectRelevantCostTypeUpdateConfiguration() : this("dbo"){}

        public ProjectRelevantCostTypeUpdateConfiguration(string schema)
        {
            ToTable("ProjectRelevantCostTypeUpdate", schema);
            HasKey(x => x.ProjectRelevantCostTypeUpdateID);
            Property(x => x.ProjectRelevantCostTypeUpdateID).HasColumnName(@"ProjectRelevantCostTypeUpdateID").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.TenantID).HasColumnName(@"TenantID").HasColumnType("int").IsRequired();
            Property(x => x.ProjectUpdateBatchID).HasColumnName(@"ProjectUpdateBatchID").HasColumnType("int").IsRequired();
            Property(x => x.CostTypeID).HasColumnName(@"CostTypeID").HasColumnType("int").IsRequired();
            Property(x => x.ProjectRelevantCostTypeGroupID).HasColumnName(@"ProjectRelevantCostTypeGroupID").HasColumnType("int").IsRequired();

            // Foreign keys
            HasRequired(a => a.ProjectUpdateBatch).WithMany(b => b.ProjectRelevantCostTypeUpdates).HasForeignKey(c => c.ProjectUpdateBatchID).WillCascadeOnDelete(false); // FK_ProjectRelevantCostTypeUpdate_ProjectUpdateBatch_ProjectUpdateBatchID
            HasRequired(a => a.CostType).WithMany(b => b.ProjectRelevantCostTypeUpdates).HasForeignKey(c => c.CostTypeID).WillCascadeOnDelete(false); // FK_ProjectRelevantCostTypeUpdate_CostType_CostTypeID
        }
    }
}