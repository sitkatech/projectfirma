//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProjectLocation]
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectFirmaModels.Models
{
    public class ProjectLocationConfiguration : EntityTypeConfiguration<ProjectLocation>
    {
        public ProjectLocationConfiguration() : this("dbo"){}

        public ProjectLocationConfiguration(string schema)
        {
            ToTable("ProjectLocation", schema);
            HasKey(x => x.ProjectLocationID);
            Property(x => x.ProjectLocationID).HasColumnName(@"ProjectLocationID").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.TenantID).HasColumnName(@"TenantID").HasColumnType("int").IsRequired();
            Property(x => x.ProjectID).HasColumnName(@"ProjectID").HasColumnType("int").IsRequired();
            Property(x => x.ProjectLocationGeometry).HasColumnName(@"ProjectLocationGeometry").HasColumnType("geometry").IsRequired();
            Property(x => x.Annotation).HasColumnName(@"Annotation").HasColumnType("varchar").IsOptional().IsUnicode(false).HasMaxLength(255);

            // Foreign keys
            HasRequired(a => a.Project).WithMany(b => b.ProjectLocations).HasForeignKey(c => c.ProjectID).WillCascadeOnDelete(false); // FK_ProjectLocation_Project_ProjectID
        }
    }
}