//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[CustomPageRole]
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectFirmaModels.Models
{
    public class CustomPageRoleConfiguration : EntityTypeConfiguration<CustomPageRole>
    {
        public CustomPageRoleConfiguration() : this("dbo"){}

        public CustomPageRoleConfiguration(string schema)
        {
            ToTable("CustomPageRole", schema);
            HasKey(x => x.CustomPageRoleID);
            Property(x => x.CustomPageRoleID).HasColumnName(@"CustomPageRoleID").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.TenantID).HasColumnName(@"TenantID").HasColumnType("int").IsRequired();
            Property(x => x.CustomPageID).HasColumnName(@"CustomPageID").HasColumnType("int").IsRequired();
            Property(x => x.RoleID).HasColumnName(@"RoleID").HasColumnType("int").IsOptional();

            // Foreign keys
            HasRequired(a => a.CustomPage).WithMany(b => b.CustomPageRoles).HasForeignKey(c => c.CustomPageID).WillCascadeOnDelete(false); // FK_CustomPageRole_CustomPage_CustomPageID
        }
    }
}