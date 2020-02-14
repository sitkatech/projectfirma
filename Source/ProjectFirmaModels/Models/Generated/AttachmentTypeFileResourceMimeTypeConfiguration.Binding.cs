//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[AttachmentTypeFileResourceMimeType]
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectFirmaModels.Models
{
    public class AttachmentTypeFileResourceMimeTypeConfiguration : EntityTypeConfiguration<AttachmentTypeFileResourceMimeType>
    {
        public AttachmentTypeFileResourceMimeTypeConfiguration() : this("dbo"){}

        public AttachmentTypeFileResourceMimeTypeConfiguration(string schema)
        {
            ToTable("AttachmentTypeFileResourceMimeType", schema);
            HasKey(x => x.AttachmentTypeFileResourceMimeTypeID);
            Property(x => x.AttachmentTypeFileResourceMimeTypeID).HasColumnName(@"AttachmentTypeFileResourceMimeTypeID").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.TenantID).HasColumnName(@"TenantID").HasColumnType("int").IsRequired();
            Property(x => x.AttachmentTypeID).HasColumnName(@"AttachmentTypeID").HasColumnType("int").IsRequired();
            Property(x => x.FileResourceMimeTypeID).HasColumnName(@"FileResourceMimeTypeID").HasColumnType("int").IsRequired();

            // Foreign keys
            HasRequired(a => a.AttachmentType).WithMany(b => b.AttachmentTypeFileResourceMimeTypes).HasForeignKey(c => c.AttachmentTypeID).WillCascadeOnDelete(false); // FK_AttachmentTypeFileResourceMimeType_AttachmentType_AttachmentTypeID
        }
    }
}