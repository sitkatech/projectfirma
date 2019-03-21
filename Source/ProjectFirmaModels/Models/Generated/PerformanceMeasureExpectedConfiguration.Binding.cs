//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[PerformanceMeasureExpected]
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectFirmaModels.Models
{
    public class PerformanceMeasureExpectedConfiguration : EntityTypeConfiguration<PerformanceMeasureExpected>
    {
        public PerformanceMeasureExpectedConfiguration() : this("dbo"){}

        public PerformanceMeasureExpectedConfiguration(string schema)
        {
            ToTable("PerformanceMeasureExpected", schema);
            HasKey(x => x.PerformanceMeasureExpectedID);
            Property(x => x.PerformanceMeasureExpectedID).HasColumnName(@"PerformanceMeasureExpectedID").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.TenantID).HasColumnName(@"TenantID").HasColumnType("int").IsRequired();
            Property(x => x.ProjectID).HasColumnName(@"ProjectID").HasColumnType("int").IsRequired();
            Property(x => x.PerformanceMeasureID).HasColumnName(@"PerformanceMeasureID").HasColumnType("int").IsRequired();
            Property(x => x.ExpectedValue).HasColumnName(@"ExpectedValue").HasColumnType("float").IsOptional();

            // Foreign keys
            HasRequired(a => a.Project).WithMany(b => b.PerformanceMeasureExpecteds).HasForeignKey(c => c.ProjectID).WillCascadeOnDelete(false); // FK_PerformanceMeasureExpected_Project_ProjectID
            HasRequired(a => a.PerformanceMeasure).WithMany(b => b.PerformanceMeasureExpecteds).HasForeignKey(c => c.PerformanceMeasureID).WillCascadeOnDelete(false); // FK_PerformanceMeasureExpected_PerformanceMeasure_PerformanceMeasureID
        }
    }
}