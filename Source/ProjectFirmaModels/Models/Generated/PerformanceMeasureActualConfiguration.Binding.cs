//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[PerformanceMeasureActual]
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectFirmaModels.Models
{
    public class PerformanceMeasureActualConfiguration : EntityTypeConfiguration<PerformanceMeasureActual>
    {
        public PerformanceMeasureActualConfiguration() : this("dbo"){}

        public PerformanceMeasureActualConfiguration(string schema)
        {
            ToTable("PerformanceMeasureActual", schema);
            HasKey(x => x.PerformanceMeasureActualID);
            Property(x => x.PerformanceMeasureActualID).HasColumnName(@"PerformanceMeasureActualID").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.TenantID).HasColumnName(@"TenantID").HasColumnType("int").IsRequired();
            Property(x => x.ProjectID).HasColumnName(@"ProjectID").HasColumnType("int").IsRequired();
            Property(x => x.PerformanceMeasureID).HasColumnName(@"PerformanceMeasureID").HasColumnType("int").IsRequired();
            Property(x => x.ActualValue).HasColumnName(@"ActualValue").HasColumnType("float").IsRequired();
            Property(x => x.PerformanceMeasureReportingPeriodID).HasColumnName(@"PerformanceMeasureReportingPeriodID").HasColumnType("int").IsRequired();

            // Foreign keys
            HasRequired(a => a.Project).WithMany(b => b.PerformanceMeasureActuals).HasForeignKey(c => c.ProjectID).WillCascadeOnDelete(false); // FK_PerformanceMeasureActual_Project_ProjectID
            HasRequired(a => a.PerformanceMeasure).WithMany(b => b.PerformanceMeasureActuals).HasForeignKey(c => c.PerformanceMeasureID).WillCascadeOnDelete(false); // FK_PerformanceMeasureActual_PerformanceMeasure_PerformanceMeasureID
            HasRequired(a => a.PerformanceMeasureReportingPeriod).WithMany(b => b.PerformanceMeasureActuals).HasForeignKey(c => c.PerformanceMeasureReportingPeriodID).WillCascadeOnDelete(false); // FK_PerformanceMeasureActual_PerformanceMeasureReportingPeriod_PerformanceMeasureReportingPeriodID
        }
    }
}