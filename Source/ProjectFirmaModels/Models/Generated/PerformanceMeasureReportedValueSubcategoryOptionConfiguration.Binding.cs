//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[PerformanceMeasureReportedValueSubcategoryOption]
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectFirmaModels.Models
{
    public class PerformanceMeasureReportedValueSubcategoryOptionConfiguration : EntityTypeConfiguration<PerformanceMeasureReportedValueSubcategoryOption>
    {
        public PerformanceMeasureReportedValueSubcategoryOptionConfiguration() : this("dbo"){}

        public PerformanceMeasureReportedValueSubcategoryOptionConfiguration(string schema)
        {
            ToTable("PerformanceMeasureReportedValueSubcategoryOption", schema);
            HasKey(x => x.PerformanceMeasureReportedValueSubcategoryOptionID);
            Property(x => x.PerformanceMeasureReportedValueSubcategoryOptionID).HasColumnName(@"PerformanceMeasureReportedValueSubcategoryOptionID").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.PerformanceMeasureReportedValueID).HasColumnName(@"PerformanceMeasureReportedValueID").HasColumnType("int").IsRequired();
            Property(x => x.PerformanceMeasureSubcategoryOptionID).HasColumnName(@"PerformanceMeasureSubcategoryOptionID").HasColumnType("int").IsRequired();
            Property(x => x.PerformanceMeasureID).HasColumnName(@"PerformanceMeasureID").HasColumnType("int").IsRequired();
            Property(x => x.PerformanceMeasureSubcategoryID).HasColumnName(@"PerformanceMeasureSubcategoryID").HasColumnType("int").IsRequired();
            Property(x => x.TenantID).HasColumnName(@"TenantID").HasColumnType("int").IsRequired();

            // Foreign keys
            HasRequired(a => a.PerformanceMeasureReportedValue).WithMany(b => b.PerformanceMeasureReportedValueSubcategoryOptions).HasForeignKey(c => c.PerformanceMeasureReportedValueID).WillCascadeOnDelete(false); // FK_PerformanceMeasureReportedValueSubcategoryOption_PerformanceMeasureReportedValue_PerformanceMeasureReportedValueID
            HasRequired(a => a.PerformanceMeasureSubcategoryOption).WithMany(b => b.PerformanceMeasureReportedValueSubcategoryOptions).HasForeignKey(c => c.PerformanceMeasureSubcategoryOptionID).WillCascadeOnDelete(false); // FK_PerformanceMeasureReportedValueSubcategoryOption_PerformanceMeasureSubcategoryOption_PerformanceMeasureSubcategoryOptionID
            HasRequired(a => a.PerformanceMeasure).WithMany(b => b.PerformanceMeasureReportedValueSubcategoryOptions).HasForeignKey(c => c.PerformanceMeasureID).WillCascadeOnDelete(false); // FK_PerformanceMeasureReportedValueSubcategoryOption_PerformanceMeasure_PerformanceMeasureID
            HasRequired(a => a.PerformanceMeasureSubcategory).WithMany(b => b.PerformanceMeasureReportedValueSubcategoryOptions).HasForeignKey(c => c.PerformanceMeasureSubcategoryID).WillCascadeOnDelete(false); // FK_PerformanceMeasureReportedValueSubcategoryOption_PerformanceMeasureSubcategory_PerformanceMeasureSubcategoryID
        }
    }
}