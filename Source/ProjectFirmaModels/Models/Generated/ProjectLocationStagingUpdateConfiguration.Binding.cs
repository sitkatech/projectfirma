//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProjectLocationStagingUpdate]
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectFirmaModels.Models
{
    public class ProjectLocationStagingUpdateConfiguration : EntityTypeConfiguration<ProjectLocationStagingUpdate>
    {
        public ProjectLocationStagingUpdateConfiguration() : this("dbo"){}

        public ProjectLocationStagingUpdateConfiguration(string schema)
        {
            ToTable("ProjectLocationStagingUpdate", schema);
            HasKey(x => x.ProjectLocationStagingUpdateID);
            Property(x => x.ProjectLocationStagingUpdateID).HasColumnName(@"ProjectLocationStagingUpdateID").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.TenantID).HasColumnName(@"TenantID").HasColumnType("int").IsRequired();
            Property(x => x.ProjectUpdateBatchID).HasColumnName(@"ProjectUpdateBatchID").HasColumnType("int").IsRequired();
            Property(x => x.PersonID).HasColumnName(@"PersonID").HasColumnType("int").IsRequired();
            Property(x => x.FeatureClassName).HasColumnName(@"FeatureClassName").HasColumnType("varchar").IsRequired().IsUnicode(false).HasMaxLength(255);
            Property(x => x.GeoJson).HasColumnName(@"GeoJson").HasColumnType("varchar").IsRequired();
            Property(x => x.SelectedProperty).HasColumnName(@"SelectedProperty").HasColumnType("varchar").IsOptional().IsUnicode(false).HasMaxLength(255);
            Property(x => x.ShouldImport).HasColumnName(@"ShouldImport").HasColumnType("bit").IsRequired();

            // Foreign keys
            HasRequired(a => a.ProjectUpdateBatch).WithMany(b => b.ProjectLocationStagingUpdates).HasForeignKey(c => c.ProjectUpdateBatchID).WillCascadeOnDelete(false); // FK_ProjectLocationStagingUpdate_ProjectUpdateBatch_ProjectUpdateBatchID
            HasRequired(a => a.Person).WithMany(b => b.ProjectLocationStagingUpdates).HasForeignKey(c => c.PersonID).WillCascadeOnDelete(false); // FK_ProjectLocationStagingUpdate_Person_PersonID
        }
    }
}