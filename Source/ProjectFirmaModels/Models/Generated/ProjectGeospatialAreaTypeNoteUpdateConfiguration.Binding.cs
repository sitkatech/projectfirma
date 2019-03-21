//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProjectGeospatialAreaTypeNoteUpdate]
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectFirmaModels.Models
{
    public class ProjectGeospatialAreaTypeNoteUpdateConfiguration : EntityTypeConfiguration<ProjectGeospatialAreaTypeNoteUpdate>
    {
        public ProjectGeospatialAreaTypeNoteUpdateConfiguration() : this("dbo"){}

        public ProjectGeospatialAreaTypeNoteUpdateConfiguration(string schema)
        {
            ToTable("ProjectGeospatialAreaTypeNoteUpdate", schema);
            HasKey(x => x.ProjectGeospatialAreaTypeNoteUpdateID);
            Property(x => x.ProjectGeospatialAreaTypeNoteUpdateID).HasColumnName(@"ProjectGeospatialAreaTypeNoteUpdateID").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.TenantID).HasColumnName(@"TenantID").HasColumnType("int").IsRequired();
            Property(x => x.ProjectUpdateBatchID).HasColumnName(@"ProjectUpdateBatchID").HasColumnType("int").IsRequired();
            Property(x => x.GeospatialAreaTypeID).HasColumnName(@"GeospatialAreaTypeID").HasColumnType("int").IsRequired();
            Property(x => x.Notes).HasColumnName(@"Notes").HasColumnType("varchar").IsRequired().IsUnicode(false).HasMaxLength(4000);

            // Foreign keys
            HasRequired(a => a.ProjectUpdateBatch).WithMany(b => b.ProjectGeospatialAreaTypeNoteUpdates).HasForeignKey(c => c.ProjectUpdateBatchID).WillCascadeOnDelete(false); // FK_ProjectGeospatialAreaTypeNoteUpdate_ProjectUpdateBatch_ProjectUpdateBatchID
            HasRequired(a => a.GeospatialAreaType).WithMany(b => b.ProjectGeospatialAreaTypeNoteUpdates).HasForeignKey(c => c.GeospatialAreaTypeID).WillCascadeOnDelete(false); // FK_ProjectGeospatialAreaTypeNoteUpdate_GeospatialAreaType_GeospatialAreaTypeID
        }
    }
}