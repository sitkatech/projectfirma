//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[PerformanceMeasureReportedValue]
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectFirmaModels.Models
{
    public class PerformanceMeasureReportedValueConfiguration : EntityTypeConfiguration<PerformanceMeasureReportedValue>
    {
        public PerformanceMeasureReportedValueConfiguration() : this("dbo"){}

        public PerformanceMeasureReportedValueConfiguration(string schema)
        {
            ToTable("PerformanceMeasureReportedValue", schema);
            HasKey(x => x.PerformanceMeasureReportedValueID);
            Property(x => x.PerformanceMeasureReportedValueID).HasColumnName(@"PerformanceMeasureReportedValueID").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.PerformanceMeasureID).HasColumnName(@"PerformanceMeasureID").HasColumnType("int").IsRequired();
            Property(x => x.PerformanceMeasureReportingPeriodID).HasColumnName(@"PerformanceMeasureReportingPeriodID").HasColumnType("int").IsRequired();
            Property(x => x.TenantID).HasColumnName(@"TenantID").HasColumnType("int").IsRequired();
            Property(x => x.ReportedValue).HasColumnName(@"ReportedValue").HasColumnType("float").IsRequired();

            // Foreign keys
            HasRequired(a => a.PerformanceMeasure).WithMany(b => b.PerformanceMeasureReportedValues).HasForeignKey(c => c.PerformanceMeasureID).WillCascadeOnDelete(false); // FK_PerformanceMeasureReportedValue_PerformanceMeasure_PerformanceMeasureID
            HasRequired(a => a.PerformanceMeasureReportingPeriod).WithMany(b => b.PerformanceMeasureReportedValues).HasForeignKey(c => c.PerformanceMeasureReportingPeriodID).WillCascadeOnDelete(false); // FK_PerformanceMeasureReportedValue_PerformanceMeasureReportingPeriod_PerformanceMeasureReportingPeriodID
        }
    }
}