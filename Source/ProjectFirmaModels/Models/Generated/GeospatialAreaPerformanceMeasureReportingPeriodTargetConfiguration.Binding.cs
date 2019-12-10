//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[GeospatialAreaPerformanceMeasureReportingPeriodTarget]
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectFirmaModels.Models
{
    public class GeospatialAreaPerformanceMeasureReportingPeriodTargetConfiguration : EntityTypeConfiguration<GeospatialAreaPerformanceMeasureReportingPeriodTarget>
    {
        public GeospatialAreaPerformanceMeasureReportingPeriodTargetConfiguration() : this("dbo"){}

        public GeospatialAreaPerformanceMeasureReportingPeriodTargetConfiguration(string schema)
        {
            ToTable("GeospatialAreaPerformanceMeasureReportingPeriodTarget", schema);
            HasKey(x => x.GeospatialAreaPerformanceMeasureReportingPeriodTargetID);
            Property(x => x.GeospatialAreaPerformanceMeasureReportingPeriodTargetID).HasColumnName(@"GeospatialAreaPerformanceMeasureReportingPeriodTargetID").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.TenantID).HasColumnName(@"TenantID").HasColumnType("int").IsRequired();
            Property(x => x.GeospatialAreaID).HasColumnName(@"GeospatialAreaID").HasColumnType("int").IsRequired();
            Property(x => x.PerformanceMeasureID).HasColumnName(@"PerformanceMeasureID").HasColumnType("int").IsRequired();
            Property(x => x.PerformanceMeasureReportingPeriodID).HasColumnName(@"PerformanceMeasureReportingPeriodID").HasColumnType("int").IsRequired();
            Property(x => x.GeospatialAreaPerformanceMeasureTargetValue).HasColumnName(@"GeospatialAreaPerformanceMeasureTargetValue").HasColumnType("float").IsOptional();
            Property(x => x.GeospatialAreaPerformanceMeasureTargetValueLabel).HasColumnName(@"GeospatialAreaPerformanceMeasureTargetValueLabel").HasColumnType("varchar").IsOptional().IsUnicode(false).HasMaxLength(100);

            // Foreign keys
            HasRequired(a => a.GeospatialArea).WithMany(b => b.GeospatialAreaPerformanceMeasureReportingPeriodTargets).HasForeignKey(c => c.GeospatialAreaID).WillCascadeOnDelete(false); // FK_GeospatialAreaPerformanceMeasureReportingPeriodTarget_GeospatialArea_GeospatialAreaID
            HasRequired(a => a.PerformanceMeasure).WithMany(b => b.GeospatialAreaPerformanceMeasureReportingPeriodTargets).HasForeignKey(c => c.PerformanceMeasureID).WillCascadeOnDelete(false); // FK_GeospatialAreaPerformanceMeasureReportingPeriodTarget_PerformanceMeasure_PerformanceMeasureID
            HasRequired(a => a.PerformanceMeasureReportingPeriod).WithMany(b => b.GeospatialAreaPerformanceMeasureReportingPeriodTargets).HasForeignKey(c => c.PerformanceMeasureReportingPeriodID).WillCascadeOnDelete(false); // FK_GeospatialAreaPerformanceMeasureReportingPeriodTarget_PerformanceMeasureReportingPeriod_PerformanceMeasureReportingPeriodID
        }
    }
}