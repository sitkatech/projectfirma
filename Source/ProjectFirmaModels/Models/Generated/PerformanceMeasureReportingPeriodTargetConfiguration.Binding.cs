//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[PerformanceMeasureReportingPeriodTarget]
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectFirmaModels.Models
{
    public class PerformanceMeasureReportingPeriodTargetConfiguration : EntityTypeConfiguration<PerformanceMeasureReportingPeriodTarget>
    {
        public PerformanceMeasureReportingPeriodTargetConfiguration() : this("dbo"){}

        public PerformanceMeasureReportingPeriodTargetConfiguration(string schema)
        {
            ToTable("PerformanceMeasureReportingPeriodTarget", schema);
            HasKey(x => x.PerformanceMeasureReportingPeriodTargetID);
            Property(x => x.PerformanceMeasureReportingPeriodTargetID).HasColumnName(@"PerformanceMeasureReportingPeriodTargetID").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.TenantID).HasColumnName(@"TenantID").HasColumnType("int").IsRequired();
            Property(x => x.PerformanceMeasureID).HasColumnName(@"PerformanceMeasureID").HasColumnType("int").IsRequired();
            Property(x => x.PerformanceMeasureReportingPeriodID).HasColumnName(@"PerformanceMeasureReportingPeriodID").HasColumnType("int").IsRequired();
            Property(x => x.PerformanceMeasureTargetValue).HasColumnName(@"PerformanceMeasureTargetValue").HasColumnType("float").IsOptional();
            Property(x => x.PerformanceMeasureTargetValueLabel).HasColumnName(@"PerformanceMeasureTargetValueLabel").HasColumnType("varchar").IsOptional().IsUnicode(false).HasMaxLength(100);

            // Foreign keys
            HasRequired(a => a.PerformanceMeasure).WithMany(b => b.PerformanceMeasureReportingPeriodTargets).HasForeignKey(c => c.PerformanceMeasureID).WillCascadeOnDelete(false); // FK_PerformanceMeasureReportingPeriodTarget_PerformanceMeasure_PerformanceMeasureID
            HasRequired(a => a.PerformanceMeasureReportingPeriod).WithMany(b => b.PerformanceMeasureReportingPeriodTargets).HasForeignKey(c => c.PerformanceMeasureReportingPeriodID).WillCascadeOnDelete(false); // FK_PerformanceMeasureReportingPeriodTarget_PerformanceMeasureReportingPeriod_PerformanceMeasureReportingPeriodID
        }
    }
}