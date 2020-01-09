//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[AttachmentRelationshipType]
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectFirmaModels.Models
{
    public class AttachmentRelationshipTypeConfiguration : EntityTypeConfiguration<AttachmentRelationshipType>
    {
        public AttachmentRelationshipTypeConfiguration() : this("dbo"){}

        public AttachmentRelationshipTypeConfiguration(string schema)
        {
            ToTable("AttachmentRelationshipType", schema);
            HasKey(x => x.AttachmentRelationshipTypeID);
            Property(x => x.AttachmentRelationshipTypeID).HasColumnName(@"AttachmentRelationshipTypeID").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.TenantID).HasColumnName(@"TenantID").HasColumnType("int").IsRequired();
            Property(x => x.AttachmentRelationshipTypeName).HasColumnName(@"AttachmentRelationshipTypeName").HasColumnType("varchar").IsRequired().IsUnicode(false).HasMaxLength(200);
            Property(x => x.AttachmentRelationshipTypeDescription).HasColumnName(@"AttachmentRelationshipTypeDescription").HasColumnType("varchar").IsOptional().IsUnicode(false).HasMaxLength(360);
            Property(x => x.MaxFileSize).HasColumnName(@"MaxFileSize").HasColumnType("int").IsRequired();
            Property(x => x.NumberOfAllowedAttachments).HasColumnName(@"NumberOfAllowedAttachments").HasColumnType("int").IsOptional();

            // Foreign keys

        }
    }
}