//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProjectCustomGridConfiguration]
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectFirmaModels.Models
{
    public class ProjectCustomGridConfigurationConfiguration : EntityTypeConfiguration<ProjectCustomGridConfiguration>
    {
        public ProjectCustomGridConfigurationConfiguration() : this("dbo"){}

        public ProjectCustomGridConfigurationConfiguration(string schema)
        {
            ToTable("ProjectCustomGridConfiguration", schema);
            HasKey(x => x.ProjectCustomGridConfigurationID);
            Property(x => x.ProjectCustomGridConfigurationID).HasColumnName(@"ProjectCustomGridConfigurationID").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.TenantID).HasColumnName(@"TenantID").HasColumnType("int").IsRequired();
            Property(x => x.ProjectCustomGridTypeID).HasColumnName(@"ProjectCustomGridTypeID").HasColumnType("int").IsRequired();
            Property(x => x.ProjectCustomGridColumnID).HasColumnName(@"ProjectCustomGridColumnID").HasColumnType("int").IsRequired();
            Property(x => x.ProjectCustomAttributeTypeID).HasColumnName(@"ProjectCustomAttributeTypeID").HasColumnType("int").IsOptional();
            Property(x => x.GeospatialAreaTypeID).HasColumnName(@"GeospatialAreaTypeID").HasColumnType("int").IsOptional();
            Property(x => x.IsEnabled).HasColumnName(@"IsEnabled").HasColumnType("bit").IsRequired();
            Property(x => x.SortOrder).HasColumnName(@"SortOrder").HasColumnType("int").IsOptional();

            // Foreign keys
            HasOptional(a => a.ProjectCustomAttributeType).WithMany(b => b.ProjectCustomGridConfigurations).HasForeignKey(c => c.ProjectCustomAttributeTypeID).WillCascadeOnDelete(false); // FK_ProjectCustomGridConfiguration_ProjectCustomAttributeType_ProjectCustomAttributeTypeID
            HasOptional(a => a.GeospatialAreaType).WithMany(b => b.ProjectCustomGridConfigurations).HasForeignKey(c => c.GeospatialAreaTypeID).WillCascadeOnDelete(false); // FK_ProjectCustomGridConfiguration_GeospatialAreaType_GeospatialAreaTypeID
        }
    }
}