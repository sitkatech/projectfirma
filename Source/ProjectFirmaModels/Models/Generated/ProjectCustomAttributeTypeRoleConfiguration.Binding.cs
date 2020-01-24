//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProjectCustomAttributeTypeRole]
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectFirmaModels.Models
{
    public class ProjectCustomAttributeTypeRoleConfiguration : EntityTypeConfiguration<ProjectCustomAttributeTypeRole>
    {
        public ProjectCustomAttributeTypeRoleConfiguration() : this("dbo"){}

        public ProjectCustomAttributeTypeRoleConfiguration(string schema)
        {
            ToTable("ProjectCustomAttributeTypeRole", schema);
            HasKey(x => x.ProjectCustomAttributeTypeRoleID);
            Property(x => x.ProjectCustomAttributeTypeRoleID).HasColumnName(@"ProjectCustomAttributeTypeRoleID").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.TenantID).HasColumnName(@"TenantID").HasColumnType("int").IsRequired();
            Property(x => x.ProjectCustomAttributeTypeID).HasColumnName(@"ProjectCustomAttributeTypeID").HasColumnType("int").IsRequired();
            Property(x => x.RoleID).HasColumnName(@"RoleID").HasColumnType("int").IsOptional();
            Property(x => x.ProjectCustomAttributeTypeRolePermissionTypeID).HasColumnName(@"ProjectCustomAttributeTypeRolePermissionTypeID").HasColumnType("int").IsRequired();

            // Foreign keys
            HasRequired(a => a.ProjectCustomAttributeType).WithMany(b => b.ProjectCustomAttributeTypeRoles).HasForeignKey(c => c.ProjectCustomAttributeTypeID).WillCascadeOnDelete(false); // FK_ProjectCustomAttributeTypeRole_ProjectCustomAttributeType_ProjectCustomAttributeTypeID
        }
    }
}