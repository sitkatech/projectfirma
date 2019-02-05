//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProjectGeospatialArea]
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectFirmaModels.Models
{
    public class ProjectGeospatialAreaConfiguration : EntityTypeConfiguration<ProjectGeospatialArea>
    {
        public ProjectGeospatialAreaConfiguration() : this("dbo"){}

        public ProjectGeospatialAreaConfiguration(string schema)
        {
            ToTable("ProjectGeospatialArea", schema);
            HasKey(x => x.ProjectGeospatialAreaID);
            Property(x => x.ProjectGeospatialAreaID).HasColumnName(@"ProjectGeospatialAreaID").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.TenantID).HasColumnName(@"TenantID").HasColumnType("int").IsRequired();
            Property(x => x.ProjectID).HasColumnName(@"ProjectID").HasColumnType("int").IsRequired();
            Property(x => x.GeospatialAreaID).HasColumnName(@"GeospatialAreaID").HasColumnType("int").IsRequired();

            // Foreign keys
            HasRequired(a => a.Project).WithMany(b => b.ProjectGeospatialAreas).HasForeignKey(c => c.ProjectID).WillCascadeOnDelete(false); // FK_ProjectGeospatialArea_Project_ProjectID
            HasRequired(a => a.GeospatialArea).WithMany(b => b.ProjectGeospatialAreas).HasForeignKey(c => c.GeospatialAreaID).WillCascadeOnDelete(false); // FK_ProjectGeospatialArea_GeospatialArea_GeospatialAreaID
        }
    }
}