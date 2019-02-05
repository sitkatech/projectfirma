//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProjectCustomAttributeUpdateValue]
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectFirmaModels.Models
{
    public class ProjectCustomAttributeUpdateValueConfiguration : EntityTypeConfiguration<ProjectCustomAttributeUpdateValue>
    {
        public ProjectCustomAttributeUpdateValueConfiguration() : this("dbo"){}

        public ProjectCustomAttributeUpdateValueConfiguration(string schema)
        {
            ToTable("ProjectCustomAttributeUpdateValue", schema);
            HasKey(x => x.ProjectCustomAttributeUpdateValueID);
            Property(x => x.ProjectCustomAttributeUpdateValueID).HasColumnName(@"ProjectCustomAttributeUpdateValueID").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.TenantID).HasColumnName(@"TenantID").HasColumnType("int").IsRequired();
            Property(x => x.ProjectCustomAttributeUpdateID).HasColumnName(@"ProjectCustomAttributeUpdateID").HasColumnType("int").IsRequired();
            Property(x => x.AttributeValue).HasColumnName(@"AttributeValue").HasColumnType("varchar").IsRequired().IsUnicode(false).HasMaxLength(1000);

            // Foreign keys
            HasRequired(a => a.ProjectCustomAttributeUpdate).WithMany(b => b.ProjectCustomAttributeUpdateValues).HasForeignKey(c => c.ProjectCustomAttributeUpdateID).WillCascadeOnDelete(false); // FK_ProjectCustomAttributeUpdateValue_ProjectCustomAttributeUpdate_ProjectCustomAttributeUpdateID
        }
    }
}