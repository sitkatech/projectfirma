//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[GeospatialAreaPerformanceMeasureNoTarget]
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectFirmaModels.Models
{
    public class GeospatialAreaPerformanceMeasureNoTargetConfiguration : EntityTypeConfiguration<GeospatialAreaPerformanceMeasureNoTarget>
    {
        public GeospatialAreaPerformanceMeasureNoTargetConfiguration() : this("dbo"){}

        public GeospatialAreaPerformanceMeasureNoTargetConfiguration(string schema)
        {
            ToTable("GeospatialAreaPerformanceMeasureNoTarget", schema);
            HasKey(x => x.GeospatialAreaPerformanceMeasureNoTargetID);
            Property(x => x.GeospatialAreaPerformanceMeasureNoTargetID).HasColumnName(@"GeospatialAreaPerformanceMeasureNoTargetID").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.TenantID).HasColumnName(@"TenantID").HasColumnType("int").IsRequired();
            Property(x => x.GeospatialAreaID).HasColumnName(@"GeospatialAreaID").HasColumnType("int").IsRequired();
            Property(x => x.PerformanceMeasureID).HasColumnName(@"PerformanceMeasureID").HasColumnType("int").IsRequired();

            // Foreign keys
            HasRequired(a => a.GeospatialArea).WithMany(b => b.GeospatialAreaPerformanceMeasureNoTargets).HasForeignKey(c => c.GeospatialAreaID).WillCascadeOnDelete(false); // FK_GeospatialAreaPerformanceMeasureNoTarget_GeospatialArea_GeospatialAreaID
            HasRequired(a => a.PerformanceMeasure).WithMany(b => b.GeospatialAreaPerformanceMeasureNoTargets).HasForeignKey(c => c.PerformanceMeasureID).WillCascadeOnDelete(false); // FK_GeospatialAreaPerformanceMeasureNoTarget_PerformanceMeasure_PerformanceMeasureID
        }
    }
}