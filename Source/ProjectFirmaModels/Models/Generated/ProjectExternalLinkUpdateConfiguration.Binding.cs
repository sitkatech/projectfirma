//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProjectExternalLinkUpdate]
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectFirmaModels.Models
{
    public class ProjectExternalLinkUpdateConfiguration : EntityTypeConfiguration<ProjectExternalLinkUpdate>
    {
        public ProjectExternalLinkUpdateConfiguration() : this("dbo"){}

        public ProjectExternalLinkUpdateConfiguration(string schema)
        {
            ToTable("ProjectExternalLinkUpdate", schema);
            HasKey(x => x.ProjectExternalLinkUpdateID);
            Property(x => x.ProjectExternalLinkUpdateID).HasColumnName(@"ProjectExternalLinkUpdateID").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.TenantID).HasColumnName(@"TenantID").HasColumnType("int").IsRequired();
            Property(x => x.ProjectUpdateBatchID).HasColumnName(@"ProjectUpdateBatchID").HasColumnType("int").IsRequired();
            Property(x => x.ExternalLinkLabel).HasColumnName(@"ExternalLinkLabel").HasColumnType("varchar").IsRequired().IsUnicode(false).HasMaxLength(300);
            Property(x => x.ExternalLinkUrl).HasColumnName(@"ExternalLinkUrl").HasColumnType("varchar").IsRequired().IsUnicode(false).HasMaxLength(300);

            // Foreign keys
            HasRequired(a => a.ProjectUpdateBatch).WithMany(b => b.ProjectExternalLinkUpdates).HasForeignKey(c => c.ProjectUpdateBatchID).WillCascadeOnDelete(false); // FK_ProjectExternalLinkUpdate_ProjectUpdateBatch_ProjectUpdateBatchID
        }
    }
}