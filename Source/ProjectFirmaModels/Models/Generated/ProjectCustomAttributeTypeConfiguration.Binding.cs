//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProjectCustomAttributeType]
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectFirmaModels.Models
{
    public class ProjectCustomAttributeTypeConfiguration : EntityTypeConfiguration<ProjectCustomAttributeType>
    {
        public ProjectCustomAttributeTypeConfiguration() : this("dbo"){}

        public ProjectCustomAttributeTypeConfiguration(string schema)
        {
            ToTable("ProjectCustomAttributeType", schema);
            HasKey(x => x.ProjectCustomAttributeTypeID);
            Property(x => x.ProjectCustomAttributeTypeID).HasColumnName(@"ProjectCustomAttributeTypeID").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.TenantID).HasColumnName(@"TenantID").HasColumnType("int").IsRequired();
            Property(x => x.ProjectCustomAttributeTypeName).HasColumnName(@"ProjectCustomAttributeTypeName").HasColumnType("varchar").IsRequired().IsUnicode(false).HasMaxLength(100);
            Property(x => x.ProjectCustomAttributeDataTypeID).HasColumnName(@"ProjectCustomAttributeDataTypeID").HasColumnType("int").IsRequired();
            Property(x => x.MeasurementUnitTypeID).HasColumnName(@"MeasurementUnitTypeID").HasColumnType("int").IsOptional();
            Property(x => x.IsRequired).HasColumnName(@"IsRequired").HasColumnType("bit").IsRequired();
            Property(x => x.ProjectCustomAttributeTypeDescription).HasColumnName(@"ProjectCustomAttributeTypeDescription").HasColumnType("varchar").IsOptional().IsUnicode(false).HasMaxLength(200);
            Property(x => x.ProjectCustomAttributeTypeOptionsSchema).HasColumnName(@"ProjectCustomAttributeTypeOptionsSchema").HasColumnType("varchar").IsOptional();
            Property(x => x.IsViewableOnFactSheet).HasColumnName(@"IsViewableOnFactSheet").HasColumnType("bit").IsRequired();
            Property(x => x.ProjectCustomAttributeGroupID).HasColumnName(@"ProjectCustomAttributeGroupID").HasColumnType("int").IsRequired();
            Property(x => x.SortOrder).HasColumnName(@"SortOrder").HasColumnType("int").IsOptional();

            // Foreign keys
            HasRequired(a => a.ProjectCustomAttributeGroup).WithMany(b => b.ProjectCustomAttributeTypes).HasForeignKey(c => c.ProjectCustomAttributeGroupID).WillCascadeOnDelete(false); // FK_ProjectCustomAttributeType_ProjectCustomAttributeGroup_ProjectCustomAttributeGroupID
        }
    }
}