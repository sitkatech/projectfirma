//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProjectCustomAttributeValue]
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectFirmaModels.Models
{
    public class ProjectCustomAttributeValueConfiguration : EntityTypeConfiguration<ProjectCustomAttributeValue>
    {
        public ProjectCustomAttributeValueConfiguration() : this("dbo"){}

        public ProjectCustomAttributeValueConfiguration(string schema)
        {
            ToTable("ProjectCustomAttributeValue", schema);
            HasKey(x => x.ProjectCustomAttributeValueID);
            Property(x => x.ProjectCustomAttributeValueID).HasColumnName(@"ProjectCustomAttributeValueID").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.TenantID).HasColumnName(@"TenantID").HasColumnType("int").IsRequired();
            Property(x => x.ProjectCustomAttributeID).HasColumnName(@"ProjectCustomAttributeID").HasColumnType("int").IsRequired();
            Property(x => x.AttributeValue).HasColumnName(@"AttributeValue").HasColumnType("varchar").IsRequired().IsUnicode(false).HasMaxLength(1000);

            // Foreign keys
            HasRequired(a => a.ProjectCustomAttribute).WithMany(b => b.ProjectCustomAttributeValues).HasForeignKey(c => c.ProjectCustomAttributeID).WillCascadeOnDelete(false); // FK_ProjectCustomAttributeValue_ProjectCustomAttribute_ProjectCustomAttributeID
        }
    }
}