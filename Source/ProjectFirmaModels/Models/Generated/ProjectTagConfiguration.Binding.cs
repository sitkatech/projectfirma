//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProjectTag]
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectFirmaModels.Models
{
    public class ProjectTagConfiguration : EntityTypeConfiguration<ProjectTag>
    {
        public ProjectTagConfiguration() : this("dbo"){}

        public ProjectTagConfiguration(string schema)
        {
            ToTable("ProjectTag", schema);
            HasKey(x => x.ProjectTagID);
            Property(x => x.ProjectTagID).HasColumnName(@"ProjectTagID").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.TenantID).HasColumnName(@"TenantID").HasColumnType("int").IsRequired();
            Property(x => x.ProjectID).HasColumnName(@"ProjectID").HasColumnType("int").IsRequired();
            Property(x => x.TagID).HasColumnName(@"TagID").HasColumnType("int").IsRequired();

            // Foreign keys
            HasRequired(a => a.Project).WithMany(b => b.ProjectTags).HasForeignKey(c => c.ProjectID).WillCascadeOnDelete(false); // FK_ProjectTag_Project_ProjectID
            HasRequired(a => a.Tag).WithMany(b => b.ProjectTags).HasForeignKey(c => c.TagID).WillCascadeOnDelete(false); // FK_ProjectTag_Tag_TagID
        }
    }
}