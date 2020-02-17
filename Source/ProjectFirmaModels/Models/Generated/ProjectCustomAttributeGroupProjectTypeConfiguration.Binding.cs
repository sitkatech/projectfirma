//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProjectCustomAttributeGroupProjectType]
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectFirmaModels.Models
{
    public class ProjectCustomAttributeGroupProjectTypeConfiguration : EntityTypeConfiguration<ProjectCustomAttributeGroupProjectType>
    {
        public ProjectCustomAttributeGroupProjectTypeConfiguration() : this("dbo"){}

        public ProjectCustomAttributeGroupProjectTypeConfiguration(string schema)
        {
            ToTable("ProjectCustomAttributeGroupProjectType", schema);
            HasKey(x => x.ProjectCustomAttributeGroupProjectTypeID);
            Property(x => x.ProjectCustomAttributeGroupProjectTypeID).HasColumnName(@"ProjectCustomAttributeGroupProjectTypeID").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.TenantID).HasColumnName(@"TenantID").HasColumnType("int").IsRequired();
            Property(x => x.ProjectCustomAttributeGroupID).HasColumnName(@"ProjectCustomAttributeGroupID").HasColumnType("int").IsRequired();
            Property(x => x.ProjectTypeID).HasColumnName(@"ProjectTypeID").HasColumnType("int").IsRequired();

            // Foreign keys
            HasRequired(a => a.ProjectCustomAttributeGroup).WithMany(b => b.ProjectCustomAttributeGroupProjectTypes).HasForeignKey(c => c.ProjectCustomAttributeGroupID).WillCascadeOnDelete(false); // FK_ProjectCustomAttributeGroupProjectType_ProjectCustomAttributeGroup_ProjectCustomAttributeGroupID
        }
    }
}