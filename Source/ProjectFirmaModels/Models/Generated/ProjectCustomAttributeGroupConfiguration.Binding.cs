//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProjectCustomAttributeGroup]
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectFirmaModels.Models
{
    public class ProjectCustomAttributeGroupConfiguration : EntityTypeConfiguration<ProjectCustomAttributeGroup>
    {
        public ProjectCustomAttributeGroupConfiguration() : this("dbo"){}

        public ProjectCustomAttributeGroupConfiguration(string schema)
        {
            ToTable("ProjectCustomAttributeGroup", schema);
            HasKey(x => x.ProjectCustomAttributeGroupID);
            Property(x => x.ProjectCustomAttributeGroupID).HasColumnName(@"ProjectCustomAttributeGroupID").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.TenantID).HasColumnName(@"TenantID").HasColumnType("int").IsRequired();
            Property(x => x.ProjectCustomAttributeGroupName).HasColumnName(@"ProjectCustomAttributeGroupName").HasColumnType("nvarchar").IsOptional().HasMaxLength(100);
            Property(x => x.SortOrder).HasColumnName(@"SortOrder").HasColumnType("int").IsOptional();

            // Foreign keys

        }
    }
}