//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[PerformanceMeasureExpectedUpdate]
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectFirmaModels.Models
{
    public class PerformanceMeasureExpectedUpdateConfiguration : EntityTypeConfiguration<PerformanceMeasureExpectedUpdate>
    {
        public PerformanceMeasureExpectedUpdateConfiguration() : this("dbo"){}

        public PerformanceMeasureExpectedUpdateConfiguration(string schema)
        {
            ToTable("PerformanceMeasureExpectedUpdate", schema);
            HasKey(x => x.PerformanceMeasureExpectedUpdateID);
            Property(x => x.PerformanceMeasureExpectedUpdateID).HasColumnName(@"PerformanceMeasureExpectedUpdateID").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.TenantID).HasColumnName(@"TenantID").HasColumnType("int").IsRequired();
            Property(x => x.ProjectUpdateBatchID).HasColumnName(@"ProjectUpdateBatchID").HasColumnType("int").IsRequired();
            Property(x => x.PerformanceMeasureID).HasColumnName(@"PerformanceMeasureID").HasColumnType("int").IsRequired();
            Property(x => x.ExpectedValue).HasColumnName(@"ExpectedValue").HasColumnType("float").IsOptional();

            // Foreign keys
            HasRequired(a => a.ProjectUpdateBatch).WithMany(b => b.PerformanceMeasureExpectedUpdates).HasForeignKey(c => c.ProjectUpdateBatchID).WillCascadeOnDelete(false); // FK_PerformanceMeasureExpectedUpdate_ProjectUpdateBatch_ProjectUpdateBatchID
            HasRequired(a => a.PerformanceMeasure).WithMany(b => b.PerformanceMeasureExpectedUpdates).HasForeignKey(c => c.PerformanceMeasureID).WillCascadeOnDelete(false); // FK_PerformanceMeasureExpectedUpdate_PerformanceMeasure_PerformanceMeasureID
        }
    }
}