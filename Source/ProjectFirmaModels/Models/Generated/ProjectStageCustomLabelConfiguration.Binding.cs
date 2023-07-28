//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProjectStageCustomLabel]
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectFirmaModels.Models
{
    public class ProjectStageCustomLabelConfiguration : EntityTypeConfiguration<ProjectStageCustomLabel>
    {
        public ProjectStageCustomLabelConfiguration() : this("dbo"){}

        public ProjectStageCustomLabelConfiguration(string schema)
        {
            ToTable("ProjectStageCustomLabel", schema);
            HasKey(x => x.ProjectStageCustomLabelID);
            Property(x => x.ProjectStageCustomLabelID).HasColumnName(@"ProjectStageCustomLabelID").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.TenantID).HasColumnName(@"TenantID").HasColumnType("int").IsRequired();
            Property(x => x.ProjectStageID).HasColumnName(@"ProjectStageID").HasColumnType("int").IsRequired();
            Property(x => x.ProjectStageLabel).HasColumnName(@"ProjectStageLabel").HasColumnType("varchar").IsOptional().IsUnicode(false).HasMaxLength(300);
            Property(x => x.ProjectStageColor).HasColumnName(@"ProjectStageColor").HasColumnType("varchar").IsOptional().IsUnicode(false).HasMaxLength(20);

            // Foreign keys

        }
    }
}