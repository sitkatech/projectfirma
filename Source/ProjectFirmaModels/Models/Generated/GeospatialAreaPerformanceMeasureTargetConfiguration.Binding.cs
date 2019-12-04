//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[GeospatialAreaPerformanceMeasureTarget]
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectFirmaModels.Models
{
    public class GeospatialAreaPerformanceMeasureTargetConfiguration : EntityTypeConfiguration<GeospatialAreaPerformanceMeasureTarget>
    {
        public GeospatialAreaPerformanceMeasureTargetConfiguration() : this("dbo"){}

        public GeospatialAreaPerformanceMeasureTargetConfiguration(string schema)
        {
            ToTable("GeospatialAreaPerformanceMeasureTarget", schema);
            HasKey(x => x.GeospatialAreaPerformanceMeasureTargetID);
            Property(x => x.GeospatialAreaPerformanceMeasureTargetID).HasColumnName(@"GeospatialAreaPerformanceMeasureTargetID").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.TenantID).HasColumnName(@"TenantID").HasColumnType("int").IsRequired();
            Property(x => x.GeospatialAreaID).HasColumnName(@"GeospatialAreaID").HasColumnType("int").IsRequired();
            Property(x => x.PerformanceMeasureID).HasColumnName(@"PerformanceMeasureID").HasColumnType("int").IsRequired();
            Property(x => x.PerformanceMeasureReportingPeriodID).HasColumnName(@"PerformanceMeasureReportingPeriodID").HasColumnType("int").IsRequired();
            Property(x => x.GeospatialAreaPerformanceMeasureTargetValue).HasColumnName(@"GeospatialAreaPerformanceMeasureTargetValue").HasColumnType("float").IsOptional();
            Property(x => x.GeospatialAreaPerformanceMeasureTargetValueLabel).HasColumnName(@"GeospatialAreaPerformanceMeasureTargetValueLabel").HasColumnType("varchar").IsOptional().IsUnicode(false).HasMaxLength(100);

            // Foreign keys
            HasRequired(a => a.GeospatialArea).WithMany(b => b.GeospatialAreaPerformanceMeasureTargets).HasForeignKey(c => c.GeospatialAreaID).WillCascadeOnDelete(false); // FK_GeospatialAreaPerformanceMeasureTarget_GeospatialArea_GeospatialAreaID
            HasRequired(a => a.PerformanceMeasure).WithMany(b => b.GeospatialAreaPerformanceMeasureTargets).HasForeignKey(c => c.PerformanceMeasureID).WillCascadeOnDelete(false); // FK_GeospatialAreaPerformanceMeasureTarget_PerformanceMeasure_PerformanceMeasureID
            HasRequired(a => a.PerformanceMeasureReportingPeriod).WithMany(b => b.GeospatialAreaPerformanceMeasureTargets).HasForeignKey(c => c.PerformanceMeasureReportingPeriodID).WillCascadeOnDelete(false); // FK_GeospatialAreaPerformanceMeasureTarget_PerformanceMeasureReportingPeriod_PerformanceMeasureReportingPeriodID
        }
    }
}