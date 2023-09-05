//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[AttachmentTypeRole]
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectFirmaModels.Models
{
    public class AttachmentTypeRoleConfiguration : EntityTypeConfiguration<AttachmentTypeRole>
    {
        public AttachmentTypeRoleConfiguration() : this("dbo"){}

        public AttachmentTypeRoleConfiguration(string schema)
        {
            ToTable("AttachmentTypeRole", schema);
            HasKey(x => x.AttachmentTypeRoleID);
            Property(x => x.AttachmentTypeRoleID).HasColumnName(@"AttachmentTypeRoleID").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.TenantID).HasColumnName(@"TenantID").HasColumnType("int").IsRequired();
            Property(x => x.AttachmentTypeID).HasColumnName(@"AttachmentTypeID").HasColumnType("int").IsRequired();
            Property(x => x.RoleID).HasColumnName(@"RoleID").HasColumnType("int").IsOptional();

            // Foreign keys
            HasRequired(a => a.AttachmentType).WithMany(b => b.AttachmentTypeRoles).HasForeignKey(c => c.AttachmentTypeID).WillCascadeOnDelete(false); // FK_AttachmentTypeRole_AttachmentType_AttachmentTypeID
        }
    }
}