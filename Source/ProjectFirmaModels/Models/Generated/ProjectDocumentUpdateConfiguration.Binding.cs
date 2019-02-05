//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProjectDocumentUpdate]
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectFirmaModels.Models
{
    public class ProjectDocumentUpdateConfiguration : EntityTypeConfiguration<ProjectDocumentUpdate>
    {
        public ProjectDocumentUpdateConfiguration() : this("dbo"){}

        public ProjectDocumentUpdateConfiguration(string schema)
        {
            ToTable("ProjectDocumentUpdate", schema);
            HasKey(x => x.ProjectDocumentUpdateID);
            Property(x => x.ProjectDocumentUpdateID).HasColumnName(@"ProjectDocumentUpdateID").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.TenantID).HasColumnName(@"TenantID").HasColumnType("int").IsRequired();
            Property(x => x.ProjectUpdateBatchID).HasColumnName(@"ProjectUpdateBatchID").HasColumnType("int").IsRequired();
            Property(x => x.FileResourceID).HasColumnName(@"FileResourceID").HasColumnType("int").IsRequired();
            Property(x => x.DisplayName).HasColumnName(@"DisplayName").HasColumnType("varchar").IsRequired().IsUnicode(false).HasMaxLength(200);
            Property(x => x.Description).HasColumnName(@"Description").HasColumnType("varchar").IsOptional().IsUnicode(false).HasMaxLength(1000);

            // Foreign keys
            HasRequired(a => a.ProjectUpdateBatch).WithMany(b => b.ProjectDocumentUpdates).HasForeignKey(c => c.ProjectUpdateBatchID).WillCascadeOnDelete(false); // FK_ProjectDocumentUpdate_ProjectUpdateBatch_ProjectUpdateBatchID
            HasRequired(a => a.FileResource).WithMany(b => b.ProjectDocumentUpdates).HasForeignKey(c => c.FileResourceID).WillCascadeOnDelete(false); // FK_ProjectDocumentUpdate_FileResource_FileResourceID
        }
    }
}