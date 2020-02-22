//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProjectCustomAttributeGroupProjectCategory]
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectFirmaModels.Models
{
    public class ProjectCustomAttributeGroupProjectCategoryConfiguration : EntityTypeConfiguration<ProjectCustomAttributeGroupProjectCategory>
    {
        public ProjectCustomAttributeGroupProjectCategoryConfiguration() : this("dbo"){}

        public ProjectCustomAttributeGroupProjectCategoryConfiguration(string schema)
        {
            ToTable("ProjectCustomAttributeGroupProjectCategory", schema);
            HasKey(x => x.ProjectCustomAttributeGroupProjectCategoryID);
            Property(x => x.ProjectCustomAttributeGroupProjectCategoryID).HasColumnName(@"ProjectCustomAttributeGroupProjectCategoryID").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.TenantID).HasColumnName(@"TenantID").HasColumnType("int").IsRequired();
            Property(x => x.ProjectCustomAttributeGroupID).HasColumnName(@"ProjectCustomAttributeGroupID").HasColumnType("int").IsRequired();
            Property(x => x.ProjectCategoryID).HasColumnName(@"ProjectCategoryID").HasColumnType("int").IsRequired();

            // Foreign keys
            HasRequired(a => a.ProjectCustomAttributeGroup).WithMany(b => b.ProjectCustomAttributeGroupProjectCategories).HasForeignKey(c => c.ProjectCustomAttributeGroupID).WillCascadeOnDelete(false); // FK_ProjectCustomAttributeGroupProjectCategory_ProjectCustomAttributeGroup_ProjectCustomAttributeGroupID
        }
    }
}