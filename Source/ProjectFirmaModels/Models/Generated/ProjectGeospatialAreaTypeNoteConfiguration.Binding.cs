//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProjectGeospatialAreaTypeNote]
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectFirmaModels.Models
{
    public class ProjectGeospatialAreaTypeNoteConfiguration : EntityTypeConfiguration<ProjectGeospatialAreaTypeNote>
    {
        public ProjectGeospatialAreaTypeNoteConfiguration() : this("dbo"){}

        public ProjectGeospatialAreaTypeNoteConfiguration(string schema)
        {
            ToTable("ProjectGeospatialAreaTypeNote", schema);
            HasKey(x => x.ProjectGeospatialAreaTypeNoteID);
            Property(x => x.ProjectGeospatialAreaTypeNoteID).HasColumnName(@"ProjectGeospatialAreaTypeNoteID").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.TenantID).HasColumnName(@"TenantID").HasColumnType("int").IsRequired();
            Property(x => x.ProjectID).HasColumnName(@"ProjectID").HasColumnType("int").IsRequired();
            Property(x => x.GeospatialAreaTypeID).HasColumnName(@"GeospatialAreaTypeID").HasColumnType("int").IsRequired();
            Property(x => x.Notes).HasColumnName(@"Notes").HasColumnType("varchar").IsRequired().IsUnicode(false).HasMaxLength(4000);

            // Foreign keys
            HasRequired(a => a.Project).WithMany(b => b.ProjectGeospatialAreaTypeNotes).HasForeignKey(c => c.ProjectID).WillCascadeOnDelete(false); // FK_ProjectGeospatialAreaTypeNote_Project_ProjectID
            HasRequired(a => a.GeospatialAreaType).WithMany(b => b.ProjectGeospatialAreaTypeNotes).HasForeignKey(c => c.GeospatialAreaTypeID).WillCascadeOnDelete(false); // FK_ProjectGeospatialAreaTypeNote_GeospatialAreaType_GeospatialAreaTypeID
        }
    }
}