//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProjectExternalLink]
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectFirmaModels.Models
{
    public class ProjectExternalLinkConfiguration : EntityTypeConfiguration<ProjectExternalLink>
    {
        public ProjectExternalLinkConfiguration() : this("dbo"){}

        public ProjectExternalLinkConfiguration(string schema)
        {
            ToTable("ProjectExternalLink", schema);
            HasKey(x => x.ProjectExternalLinkID);
            Property(x => x.ProjectExternalLinkID).HasColumnName(@"ProjectExternalLinkID").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.TenantID).HasColumnName(@"TenantID").HasColumnType("int").IsRequired();
            Property(x => x.ProjectID).HasColumnName(@"ProjectID").HasColumnType("int").IsRequired();
            Property(x => x.ExternalLinkLabel).HasColumnName(@"ExternalLinkLabel").HasColumnType("varchar").IsRequired().IsUnicode(false).HasMaxLength(300);
            Property(x => x.ExternalLinkUrl).HasColumnName(@"ExternalLinkUrl").HasColumnType("varchar").IsRequired().IsUnicode(false).HasMaxLength(300);

            // Foreign keys
            HasRequired(a => a.Project).WithMany(b => b.ProjectExternalLinks).HasForeignKey(c => c.ProjectID).WillCascadeOnDelete(false); // FK_ProjectExternalLink_Project_ProjectID
        }
    }
}