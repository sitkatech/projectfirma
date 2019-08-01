//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProjectRelevantCostTypeGroup]
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectFirmaModels.Models
{
    public class ProjectRelevantCostTypeGroupConfiguration : EntityTypeConfiguration<ProjectRelevantCostTypeGroup>
    {
        public ProjectRelevantCostTypeGroupConfiguration() : this("dbo"){}

        public ProjectRelevantCostTypeGroupConfiguration(string schema)
        {
            ToTable("ProjectRelevantCostTypeGroup", schema);
            HasKey(x => x.ProjectRelevantCostTypeGroupID);
            Property(x => x.ProjectRelevantCostTypeGroupID).HasColumnName(@"ProjectRelevantCostTypeGroupID").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.ProjectRelevantCostTypeGroupName).HasColumnName(@"ProjectRelevantCostTypeGroupName").HasColumnType("varchar").IsRequired().IsUnicode(false).HasMaxLength(50);
            Property(x => x.ProjectRelevantCostTypeGroupDisplayName).HasColumnName(@"ProjectRelevantCostTypeGroupDisplayName").HasColumnType("varchar").IsRequired().IsUnicode(false).HasMaxLength(50);

            // Foreign keys

        }
    }
}