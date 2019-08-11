//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProjectAttachmentUpdate]
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectFirmaModels.Models
{
    public class ProjectAttachmentUpdateConfiguration : EntityTypeConfiguration<ProjectAttachmentUpdate>
    {
        public ProjectAttachmentUpdateConfiguration() : this("dbo"){}

        public ProjectAttachmentUpdateConfiguration(string schema)
        {
            ToTable("ProjectAttachmentUpdate", schema);
            HasKey(x => x.ProjectAttachmentUpdateID);
            Property(x => x.ProjectAttachmentUpdateID).HasColumnName(@"ProjectAttachmentUpdateID").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.TenantID).HasColumnName(@"TenantID").HasColumnType("int").IsRequired();
            Property(x => x.ProjectUpdateBatchID).HasColumnName(@"ProjectUpdateBatchID").HasColumnType("int").IsRequired();
            Property(x => x.AttachmentID).HasColumnName(@"AttachmentID").HasColumnType("int").IsRequired();
            Property(x => x.AttachmentRelationshipTypeID).HasColumnName(@"AttachmentRelationshipTypeID").HasColumnType("int").IsRequired();

            // Foreign keys
            HasRequired(a => a.ProjectUpdateBatch).WithMany(b => b.ProjectAttachmentUpdates).HasForeignKey(c => c.ProjectUpdateBatchID).WillCascadeOnDelete(false); // FK_ProjectAttachmentUpdate_ProjectUpdateBatch_ProjectUpdateBatchID
            HasRequired(a => a.Attachment).WithMany(b => b.ProjectAttachmentUpdatesWhereYouAreTheAttachment).HasForeignKey(c => c.AttachmentID).WillCascadeOnDelete(false); // FK_ProjectAttachmentUpdate_FileResource_AttachmentID_FileResourceID
            HasRequired(a => a.AttachmentRelationshipType).WithMany(b => b.ProjectAttachmentUpdates).HasForeignKey(c => c.AttachmentRelationshipTypeID).WillCascadeOnDelete(false); // FK_ProjectAttachmentUpdate_AttachmentRelationshipType_AttachmentRelationshipTypeID
        }
    }
}