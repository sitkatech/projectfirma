//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[AttachmentType]
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectFirmaModels.Models
{
    public class AttachmentTypeConfiguration : EntityTypeConfiguration<AttachmentType>
    {
        public AttachmentTypeConfiguration() : this("dbo"){}

        public AttachmentTypeConfiguration(string schema)
        {
            ToTable("AttachmentType", schema);
            HasKey(x => x.AttachmentTypeID);
            Property(x => x.AttachmentTypeID).HasColumnName(@"AttachmentTypeID").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.TenantID).HasColumnName(@"TenantID").HasColumnType("int").IsRequired();
            Property(x => x.AttachmentTypeName).HasColumnName(@"AttachmentTypeName").HasColumnType("varchar").IsRequired().IsUnicode(false).HasMaxLength(200);
            Property(x => x.AttachmentTypeDescription).HasColumnName(@"AttachmentTypeDescription").HasColumnType("varchar").IsOptional().IsUnicode(false).HasMaxLength(360);
            Property(x => x.MaxFileSize).HasColumnName(@"MaxFileSize").HasColumnType("int").IsRequired();
            Property(x => x.NumberOfAllowedAttachments).HasColumnName(@"NumberOfAllowedAttachments").HasColumnType("int").IsOptional();

            // Foreign keys

        }
    }
}