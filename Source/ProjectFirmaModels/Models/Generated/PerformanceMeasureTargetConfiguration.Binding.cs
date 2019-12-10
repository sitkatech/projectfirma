//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[PerformanceMeasureTarget]
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectFirmaModels.Models
{
    public class PerformanceMeasureTargetConfiguration : EntityTypeConfiguration<PerformanceMeasureTarget>
    {
        public PerformanceMeasureTargetConfiguration() : this("dbo"){}

        public PerformanceMeasureTargetConfiguration(string schema)
        {
            ToTable("PerformanceMeasureTarget", schema);
            HasKey(x => x.PerformanceMeasureTargetID);
            Property(x => x.PerformanceMeasureTargetID).HasColumnName(@"PerformanceMeasureTargetID").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.TenantID).HasColumnName(@"TenantID").HasColumnType("int").IsRequired();
            Property(x => x.PerformanceMeasureID).HasColumnName(@"PerformanceMeasureID").HasColumnType("int").IsRequired();
            Property(x => x.PerformanceMeasureReportingPeriodID).HasColumnName(@"PerformanceMeasureReportingPeriodID").HasColumnType("int").IsRequired();
            Property(x => x.PerformanceMeasureTargetValue).HasColumnName(@"PerformanceMeasureTargetValue").HasColumnType("float").IsOptional();
            Property(x => x.PerformanceMeasureTargetValueLabel).HasColumnName(@"PerformanceMeasureTargetValueLabel").HasColumnType("varchar").IsOptional().IsUnicode(false).HasMaxLength(100);

            // Foreign keys
            HasRequired(a => a.PerformanceMeasure).WithMany(b => b.PerformanceMeasureTargets).HasForeignKey(c => c.PerformanceMeasureID).WillCascadeOnDelete(false); // FK_PerformanceMeasureTarget_PerformanceMeasure_PerformanceMeasureID
            HasRequired(a => a.PerformanceMeasureReportingPeriod).WithMany(b => b.PerformanceMeasureTargets).HasForeignKey(c => c.PerformanceMeasureReportingPeriodID).WillCascadeOnDelete(false); // FK_PerformanceMeasureTarget_PerformanceMeasureReportingPeriod_PerformanceMeasureReportingPeriodID
        }
    }
}