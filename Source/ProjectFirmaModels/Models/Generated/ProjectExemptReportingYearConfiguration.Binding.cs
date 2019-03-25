//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProjectExemptReportingYear]
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectFirmaModels.Models
{
    public class ProjectExemptReportingYearConfiguration : EntityTypeConfiguration<ProjectExemptReportingYear>
    {
        public ProjectExemptReportingYearConfiguration() : this("dbo"){}

        public ProjectExemptReportingYearConfiguration(string schema)
        {
            ToTable("ProjectExemptReportingYear", schema);
            HasKey(x => x.ProjectExemptReportingYearID);
            Property(x => x.ProjectExemptReportingYearID).HasColumnName(@"ProjectExemptReportingYearID").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.TenantID).HasColumnName(@"TenantID").HasColumnType("int").IsRequired();
            Property(x => x.ProjectID).HasColumnName(@"ProjectID").HasColumnType("int").IsRequired();
            Property(x => x.CalendarYear).HasColumnName(@"CalendarYear").HasColumnType("int").IsRequired();
            Property(x => x.ProjectExemptReportingTypeID).HasColumnName(@"ProjectExemptReportingTypeID").HasColumnType("int").IsRequired();

            // Foreign keys
            HasRequired(a => a.Project).WithMany(b => b.ProjectExemptReportingYears).HasForeignKey(c => c.ProjectID).WillCascadeOnDelete(false); // FK_ProjectExemptReportingYear_Project_ProjectID
        }
    }
}