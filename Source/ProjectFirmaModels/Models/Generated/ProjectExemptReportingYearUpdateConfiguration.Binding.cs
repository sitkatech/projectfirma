//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProjectExemptReportingYearUpdate]
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectFirmaModels.Models
{
    public class ProjectExemptReportingYearUpdateConfiguration : EntityTypeConfiguration<ProjectExemptReportingYearUpdate>
    {
        public ProjectExemptReportingYearUpdateConfiguration() : this("dbo"){}

        public ProjectExemptReportingYearUpdateConfiguration(string schema)
        {
            ToTable("ProjectExemptReportingYearUpdate", schema);
            HasKey(x => x.ProjectExemptReportingYearUpdateID);
            Property(x => x.ProjectExemptReportingYearUpdateID).HasColumnName(@"ProjectExemptReportingYearUpdateID").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.TenantID).HasColumnName(@"TenantID").HasColumnType("int").IsRequired();
            Property(x => x.ProjectUpdateBatchID).HasColumnName(@"ProjectUpdateBatchID").HasColumnType("int").IsRequired();
            Property(x => x.CalendarYear).HasColumnName(@"CalendarYear").HasColumnType("int").IsRequired();
            Property(x => x.ProjectExemptReportingTypeID).HasColumnName(@"ProjectExemptReportingTypeID").HasColumnType("int").IsRequired();

            // Foreign keys
            HasRequired(a => a.ProjectUpdateBatch).WithMany(b => b.ProjectExemptReportingYearUpdates).HasForeignKey(c => c.ProjectUpdateBatchID).WillCascadeOnDelete(false); // FK_ProjectExemptReportingYearUpdate_ProjectUpdateBatch_ProjectUpdateBatchID
        }
    }
}