//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProjectLocationUpdate]
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectFirmaModels.Models
{
    public class ProjectLocationUpdateConfiguration : EntityTypeConfiguration<ProjectLocationUpdate>
    {
        public ProjectLocationUpdateConfiguration() : this("dbo"){}

        public ProjectLocationUpdateConfiguration(string schema)
        {
            ToTable("ProjectLocationUpdate", schema);
            HasKey(x => x.ProjectLocationUpdateID);
            Property(x => x.ProjectLocationUpdateID).HasColumnName(@"ProjectLocationUpdateID").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.TenantID).HasColumnName(@"TenantID").HasColumnType("int").IsRequired();
            Property(x => x.ProjectUpdateBatchID).HasColumnName(@"ProjectUpdateBatchID").HasColumnType("int").IsRequired();
            Property(x => x.ProjectLocationUpdateGeometry).HasColumnName(@"ProjectLocationUpdateGeometry").HasColumnType("geometry").IsRequired();
            Property(x => x.Annotation).HasColumnName(@"Annotation").HasColumnType("varchar").IsOptional().IsUnicode(false).HasMaxLength(255);

            // Foreign keys
            HasRequired(a => a.ProjectUpdateBatch).WithMany(b => b.ProjectLocationUpdates).HasForeignKey(c => c.ProjectUpdateBatchID).WillCascadeOnDelete(false); // FK_ProjectLocationUpdate_ProjectUpdateBatch_ProjectUpdateBatchID
        }
    }
}