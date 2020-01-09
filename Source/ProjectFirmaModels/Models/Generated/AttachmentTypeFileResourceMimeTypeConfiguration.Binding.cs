//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[AttachmentRelationshipTypeFileResourceMimeType]
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectFirmaModels.Models
{
    public class AttachmentRelationshipTypeFileResourceMimeTypeConfiguration : EntityTypeConfiguration<AttachmentRelationshipTypeFileResourceMimeType>
    {
        public AttachmentRelationshipTypeFileResourceMimeTypeConfiguration() : this("dbo"){}

        public AttachmentRelationshipTypeFileResourceMimeTypeConfiguration(string schema)
        {
            ToTable("AttachmentRelationshipTypeFileResourceMimeType", schema);
            HasKey(x => x.AttachmentRelationshipTypeFileResourceMimeTypeID);
            Property(x => x.AttachmentRelationshipTypeFileResourceMimeTypeID).HasColumnName(@"AttachmentRelationshipTypeFileResourceMimeTypeID").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.TenantID).HasColumnName(@"TenantID").HasColumnType("int").IsRequired();
            Property(x => x.AttachmentRelationshipTypeID).HasColumnName(@"AttachmentRelationshipTypeID").HasColumnType("int").IsRequired();
            Property(x => x.FileResourceMimeTypeID).HasColumnName(@"FileResourceMimeTypeID").HasColumnType("int").IsRequired();

            // Foreign keys
            HasRequired(a => a.AttachmentRelationshipType).WithMany(b => b.AttachmentRelationshipTypeFileResourceMimeTypes).HasForeignKey(c => c.AttachmentRelationshipTypeID).WillCascadeOnDelete(false); // FK_AttachmentRelationshipTypeFileResourceMimeType_AttachmentRelationshipType_AttachmentRelationshipTypeID
        }
    }
}