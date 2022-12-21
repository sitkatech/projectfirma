//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProjectUpdateBatchClassificationSystem]
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectFirmaModels.Models
{
    public class ProjectUpdateBatchClassificationSystemConfiguration : EntityTypeConfiguration<ProjectUpdateBatchClassificationSystem>
    {
        public ProjectUpdateBatchClassificationSystemConfiguration() : this("dbo"){}

        public ProjectUpdateBatchClassificationSystemConfiguration(string schema)
        {
            ToTable("ProjectUpdateBatchClassificationSystem", schema);
            HasKey(x => x.ProjectUpdateBatchClassificationSystemID);
            Property(x => x.ProjectUpdateBatchClassificationSystemID).HasColumnName(@"ProjectUpdateBatchClassificationSystemID").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.TenantID).HasColumnName(@"TenantID").HasColumnType("int").IsRequired();
            Property(x => x.ProjectUpdateBatchID).HasColumnName(@"ProjectUpdateBatchID").HasColumnType("int").IsRequired();
            Property(x => x.ClassificationSystemID).HasColumnName(@"ClassificationSystemID").HasColumnType("int").IsRequired();
            Property(x => x.ProjectClassificationsDiffLog).HasColumnName(@"ProjectClassificationsDiffLog").HasColumnType("varchar").IsOptional();
            Property(x => x.ProjectClassificationsComment).HasColumnName(@"ProjectClassificationsComment").HasColumnType("varchar").IsOptional().IsUnicode(false).HasMaxLength(1000);

            // Foreign keys
            HasRequired(a => a.ProjectUpdateBatch).WithMany(b => b.ProjectUpdateBatchClassificationSystems).HasForeignKey(c => c.ProjectUpdateBatchID).WillCascadeOnDelete(false); // FK_ProjectUpdateBatchClassificationSystem_ProjectUpdateBatch_ProjectUpdateBatchID
            HasRequired(a => a.ClassificationSystem).WithMany(b => b.ProjectUpdateBatchClassificationSystems).HasForeignKey(c => c.ClassificationSystemID).WillCascadeOnDelete(false); // FK_ProjectUpdateBatchClassificationSystem_ClassificationSystem_ClassificationSystemID
        }
    }
}