//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[PerformanceMeasureExpectedSubcategoryOption]
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectFirmaModels.Models
{
    public class PerformanceMeasureExpectedSubcategoryOptionConfiguration : EntityTypeConfiguration<PerformanceMeasureExpectedSubcategoryOption>
    {
        public PerformanceMeasureExpectedSubcategoryOptionConfiguration() : this("dbo"){}

        public PerformanceMeasureExpectedSubcategoryOptionConfiguration(string schema)
        {
            ToTable("PerformanceMeasureExpectedSubcategoryOption", schema);
            HasKey(x => x.PerformanceMeasureExpectedSubcategoryOptionID);
            Property(x => x.PerformanceMeasureExpectedSubcategoryOptionID).HasColumnName(@"PerformanceMeasureExpectedSubcategoryOptionID").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.TenantID).HasColumnName(@"TenantID").HasColumnType("int").IsRequired();
            Property(x => x.PerformanceMeasureExpectedID).HasColumnName(@"PerformanceMeasureExpectedID").HasColumnType("int").IsRequired();
            Property(x => x.PerformanceMeasureSubcategoryOptionID).HasColumnName(@"PerformanceMeasureSubcategoryOptionID").HasColumnType("int").IsRequired();
            Property(x => x.PerformanceMeasureID).HasColumnName(@"PerformanceMeasureID").HasColumnType("int").IsRequired();
            Property(x => x.PerformanceMeasureSubcategoryID).HasColumnName(@"PerformanceMeasureSubcategoryID").HasColumnType("int").IsRequired();

            // Foreign keys
            HasRequired(a => a.PerformanceMeasureExpected).WithMany(b => b.PerformanceMeasureExpectedSubcategoryOptions).HasForeignKey(c => c.PerformanceMeasureExpectedID).WillCascadeOnDelete(false); // FK_PerformanceMeasureExpectedSubcategoryOption_PerformanceMeasureExpected_PerformanceMeasureExpectedID
            HasRequired(a => a.PerformanceMeasureSubcategoryOption).WithMany(b => b.PerformanceMeasureExpectedSubcategoryOptions).HasForeignKey(c => c.PerformanceMeasureSubcategoryOptionID).WillCascadeOnDelete(false); // FK_PerformanceMeasureExpectedSubcategoryOption_PerformanceMeasureSubcategoryOption_PerformanceMeasureSubcategoryOptionID
            HasRequired(a => a.PerformanceMeasure).WithMany(b => b.PerformanceMeasureExpectedSubcategoryOptions).HasForeignKey(c => c.PerformanceMeasureID).WillCascadeOnDelete(false); // FK_PerformanceMeasureExpectedSubcategoryOption_PerformanceMeasure_PerformanceMeasureID
            HasRequired(a => a.PerformanceMeasureSubcategory).WithMany(b => b.PerformanceMeasureExpectedSubcategoryOptions).HasForeignKey(c => c.PerformanceMeasureSubcategoryID).WillCascadeOnDelete(false); // FK_PerformanceMeasureExpectedSubcategoryOption_PerformanceMeasureSubcategory_PerformanceMeasureSubcategoryID
        }
    }
}