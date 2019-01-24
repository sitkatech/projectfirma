//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProjectLocationStaging]
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectFirmaModels.Models
{
    public class ProjectLocationStagingConfiguration : EntityTypeConfiguration<ProjectLocationStaging>
    {
        public ProjectLocationStagingConfiguration() : this("dbo"){}

        public ProjectLocationStagingConfiguration(string schema)
        {
            ToTable("ProjectLocationStaging", schema);
            HasKey(x => x.ProjectLocationStagingID);
            Property(x => x.ProjectLocationStagingID).HasColumnName(@"ProjectLocationStagingID").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.TenantID).HasColumnName(@"TenantID").HasColumnType("int").IsRequired();
            Property(x => x.ProjectID).HasColumnName(@"ProjectID").HasColumnType("int").IsRequired();
            Property(x => x.PersonID).HasColumnName(@"PersonID").HasColumnType("int").IsRequired();
            Property(x => x.FeatureClassName).HasColumnName(@"FeatureClassName").HasColumnType("varchar").IsRequired().IsUnicode(false).HasMaxLength(255);
            Property(x => x.GeoJson).HasColumnName(@"GeoJson").HasColumnType("varchar").IsRequired();
            Property(x => x.SelectedProperty).HasColumnName(@"SelectedProperty").HasColumnType("varchar").IsOptional().IsUnicode(false).HasMaxLength(255);
            Property(x => x.ShouldImport).HasColumnName(@"ShouldImport").HasColumnType("bit").IsRequired();

            // Foreign keys
            HasRequired(a => a.Project).WithMany(b => b.ProjectLocationStagings).HasForeignKey(c => c.ProjectID).WillCascadeOnDelete(false); // FK_ProjectLocationStaging_Project_ProjectID
            HasRequired(a => a.Person).WithMany(b => b.ProjectLocationStagings).HasForeignKey(c => c.PersonID).WillCascadeOnDelete(false); // FK_ProjectLocationStaging_Person_PersonID
        }
    }
}