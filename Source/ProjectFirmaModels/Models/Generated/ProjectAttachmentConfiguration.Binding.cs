//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProjectAttachment]
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectFirmaModels.Models
{
    public class ProjectAttachmentConfiguration : EntityTypeConfiguration<ProjectAttachment>
    {
        public ProjectAttachmentConfiguration() : this("dbo"){}

        public ProjectAttachmentConfiguration(string schema)
        {
            ToTable("ProjectAttachment", schema);
            HasKey(x => x.ProjectAttachmentID);
            Property(x => x.ProjectAttachmentID).HasColumnName(@"ProjectAttachmentID").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.TenantID).HasColumnName(@"TenantID").HasColumnType("int").IsRequired();
            Property(x => x.ProjectID).HasColumnName(@"ProjectID").HasColumnType("int").IsRequired();
            Property(x => x.AttachmentID).HasColumnName(@"AttachmentID").HasColumnType("int").IsRequired();
            Property(x => x.AttachmentTypeID).HasColumnName(@"AttachmentTypeID").HasColumnType("int").IsRequired();
            Property(x => x.DisplayName).HasColumnName(@"DisplayName").HasColumnType("varchar").IsRequired().IsUnicode(false).HasMaxLength(200);
            Property(x => x.Description).HasColumnName(@"Description").HasColumnType("varchar").IsOptional().IsUnicode(false).HasMaxLength(1000);

            // Foreign keys
            HasRequired(a => a.Project).WithMany(b => b.ProjectAttachments).HasForeignKey(c => c.ProjectID).WillCascadeOnDelete(false); // FK_ProjectAttachment_Project_ProjectID
            HasRequired(a => a.Attachment).WithMany(b => b.ProjectAttachmentsWhereYouAreTheAttachment).HasForeignKey(c => c.AttachmentID).WillCascadeOnDelete(false); // FK_ProjectAttachment_FileResource_AttachmentID_FileResourceID
            HasRequired(a => a.AttachmentType).WithMany(b => b.ProjectAttachments).HasForeignKey(c => c.AttachmentTypeID).WillCascadeOnDelete(false); // FK_ProjectAttachment_AttachmentType_AttachmentTypeID
        }
    }
}