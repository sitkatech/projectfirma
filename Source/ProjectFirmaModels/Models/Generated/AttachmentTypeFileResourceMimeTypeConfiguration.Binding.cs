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
            HasKey(x => x.AttachmentRelationshipTypeFileResourceMimeTypeID);
            Property(x => x.AttachmentRelationshipTypeFileResourceMimeTypeID).HasColumnName(@"AttachmentRelationshipTypeFileResourceMimeTypeID").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.TenantID).HasColumnName(@"TenantID").HasColumnType("int").IsRequired();
            Property(x => x.AttachmentRelationshipTypeID).HasColumnName(@"AttachmentRelationshipTypeID").HasColumnType("int").IsRequired();
            Property(x => x.FileResourceMimeTypeID).HasColumnName(@"FileResourceMimeTypeID").HasColumnType("int").IsRequired();

            // Foreign keys
            HasRequired(a => a.AttachmentRelationshipType).WithMany(b => b.AttachmentTypeFileResourceMimeTypes).HasForeignKey(c => c.AttachmentRelationshipTypeID).WillCascadeOnDelete(false); // FK_AttachmentTypeFileResourceMimeType_AttachmentType_AttachmentRelationshipTypeID
        }
    }
}