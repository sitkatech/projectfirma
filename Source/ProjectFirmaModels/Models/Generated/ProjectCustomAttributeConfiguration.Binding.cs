//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProjectCustomAttribute]
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectFirmaModels.Models
{
    public class ProjectCustomAttributeConfiguration : EntityTypeConfiguration<ProjectCustomAttribute>
    {
        public ProjectCustomAttributeConfiguration() : this("dbo"){}

        public ProjectCustomAttributeConfiguration(string schema)
        {
            ToTable("ProjectCustomAttribute", schema);
            HasKey(x => x.ProjectCustomAttributeID);
            Property(x => x.ProjectCustomAttributeID).HasColumnName(@"ProjectCustomAttributeID").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.TenantID).HasColumnName(@"TenantID").HasColumnType("int").IsRequired();
            Property(x => x.ProjectID).HasColumnName(@"ProjectID").HasColumnType("int").IsRequired();
            Property(x => x.ProjectCustomAttributeTypeID).HasColumnName(@"ProjectCustomAttributeTypeID").HasColumnType("int").IsRequired();

            // Foreign keys
            HasRequired(a => a.Project).WithMany(b => b.ProjectCustomAttributes).HasForeignKey(c => c.ProjectID).WillCascadeOnDelete(false); // FK_ProjectCustomAttribute_Project_ProjectID
            HasRequired(a => a.ProjectCustomAttributeType).WithMany(b => b.ProjectCustomAttributes).HasForeignKey(c => c.ProjectCustomAttributeTypeID).WillCascadeOnDelete(false); // FK_ProjectCustomAttribute_ProjectCustomAttributeType_ProjectCustomAttributeTypeID
        }
    }
}