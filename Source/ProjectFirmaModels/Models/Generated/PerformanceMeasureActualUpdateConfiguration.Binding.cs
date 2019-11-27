//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[PerformanceMeasureActualUpdate]
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectFirmaModels.Models
{
    public class PerformanceMeasureActualUpdateConfiguration : EntityTypeConfiguration<PerformanceMeasureActualUpdate>
    {
        public PerformanceMeasureActualUpdateConfiguration() : this("dbo"){}

        public PerformanceMeasureActualUpdateConfiguration(string schema)
        {
            ToTable("PerformanceMeasureActualUpdate", schema);
            HasKey(x => x.PerformanceMeasureActualUpdateID);
            Property(x => x.PerformanceMeasureActualUpdateID).HasColumnName(@"PerformanceMeasureActualUpdateID").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.TenantID).HasColumnName(@"TenantID").HasColumnType("int").IsRequired();
            Property(x => x.ProjectUpdateBatchID).HasColumnName(@"ProjectUpdateBatchID").HasColumnType("int").IsRequired();
            Property(x => x.PerformanceMeasureID).HasColumnName(@"PerformanceMeasureID").HasColumnType("int").IsRequired();
            Property(x => x.ActualValue).HasColumnName(@"ActualValue").HasColumnType("float").IsOptional();
            Property(x => x.PerformanceMeasureReportingPeriodID).HasColumnName(@"PerformanceMeasureReportingPeriodID").HasColumnType("int").IsRequired();

            // Foreign keys
            HasRequired(a => a.ProjectUpdateBatch).WithMany(b => b.PerformanceMeasureActualUpdates).HasForeignKey(c => c.ProjectUpdateBatchID).WillCascadeOnDelete(false); // FK_PerformanceMeasureActualUpdate_ProjectUpdateBatch_ProjectUpdateBatchID
            HasRequired(a => a.PerformanceMeasure).WithMany(b => b.PerformanceMeasureActualUpdates).HasForeignKey(c => c.PerformanceMeasureID).WillCascadeOnDelete(false); // FK_PerformanceMeasureActualUpdate_PerformanceMeasure_PerformanceMeasureID
            HasRequired(a => a.PerformanceMeasureReportingPeriod).WithMany(b => b.PerformanceMeasureActualUpdates).HasForeignKey(c => c.PerformanceMeasureReportingPeriodID).WillCascadeOnDelete(false); // FK_PerformanceMeasureActualUpdate_PerformanceMeasureReportingPeriod_PerformanceMeasureReportingPeriodID
        }
    }
}