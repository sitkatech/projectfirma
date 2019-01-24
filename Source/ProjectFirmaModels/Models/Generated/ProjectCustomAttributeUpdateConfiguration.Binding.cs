//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProjectCustomAttributeUpdate]
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectFirmaModels.Models
{
    public class ProjectCustomAttributeUpdateConfiguration : EntityTypeConfiguration<ProjectCustomAttributeUpdate>
    {
        public ProjectCustomAttributeUpdateConfiguration() : this("dbo"){}

        public ProjectCustomAttributeUpdateConfiguration(string schema)
        {
            ToTable("ProjectCustomAttributeUpdate", schema);
            HasKey(x => x.ProjectCustomAttributeUpdateID);
            Property(x => x.ProjectCustomAttributeUpdateID).HasColumnName(@"ProjectCustomAttributeUpdateID").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.TenantID).HasColumnName(@"TenantID").HasColumnType("int").IsRequired();
            Property(x => x.ProjectUpdateBatchID).HasColumnName(@"ProjectUpdateBatchID").HasColumnType("int").IsRequired();
            Property(x => x.ProjectCustomAttributeTypeID).HasColumnName(@"ProjectCustomAttributeTypeID").HasColumnType("int").IsRequired();

            // Foreign keys
            HasRequired(a => a.ProjectUpdateBatch).WithMany(b => b.ProjectCustomAttributeUpdates).HasForeignKey(c => c.ProjectUpdateBatchID).WillCascadeOnDelete(false); // FK_ProjectCustomAttributeUpdate_ProjectUpdateBatch_ProjectUpdateBatchID
            HasRequired(a => a.ProjectCustomAttributeType).WithMany(b => b.ProjectCustomAttributeUpdates).HasForeignKey(c => c.ProjectCustomAttributeTypeID).WillCascadeOnDelete(false); // FK_ProjectCustomAttributeUpdate_ProjectCustomAttributeType_ProjectCustomAttributeTypeID
        }
    }
}