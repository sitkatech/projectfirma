//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProjectGeospatialAreaUpdate]
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectFirmaModels.Models
{
    public class ProjectGeospatialAreaUpdateConfiguration : EntityTypeConfiguration<ProjectGeospatialAreaUpdate>
    {
        public ProjectGeospatialAreaUpdateConfiguration() : this("dbo"){}

        public ProjectGeospatialAreaUpdateConfiguration(string schema)
        {
            ToTable("ProjectGeospatialAreaUpdate", schema);
            HasKey(x => x.ProjectGeospatialAreaUpdateID);
            Property(x => x.ProjectGeospatialAreaUpdateID).HasColumnName(@"ProjectGeospatialAreaUpdateID").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.TenantID).HasColumnName(@"TenantID").HasColumnType("int").IsRequired();
            Property(x => x.ProjectUpdateBatchID).HasColumnName(@"ProjectUpdateBatchID").HasColumnType("int").IsRequired();
            Property(x => x.GeospatialAreaID).HasColumnName(@"GeospatialAreaID").HasColumnType("int").IsRequired();

            // Foreign keys
            HasRequired(a => a.ProjectUpdateBatch).WithMany(b => b.ProjectGeospatialAreaUpdates).HasForeignKey(c => c.ProjectUpdateBatchID).WillCascadeOnDelete(false); // FK_ProjectGeospatialAreaUpdate_ProjectUpdateBatch_ProjectUpdateBatchID
            HasRequired(a => a.GeospatialArea).WithMany(b => b.ProjectGeospatialAreaUpdates).HasForeignKey(c => c.GeospatialAreaID).WillCascadeOnDelete(false); // FK_ProjectGeospatialAreaUpdate_GeospatialArea_GeospatialAreaID
        }
    }
}