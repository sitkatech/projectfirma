//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[PerformanceMeasureExpectedSubcategoryOptionUpdate]
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectFirmaModels.Models
{
    public class PerformanceMeasureExpectedSubcategoryOptionUpdateConfiguration : EntityTypeConfiguration<PerformanceMeasureExpectedSubcategoryOptionUpdate>
    {
        public PerformanceMeasureExpectedSubcategoryOptionUpdateConfiguration() : this("dbo"){}

        public PerformanceMeasureExpectedSubcategoryOptionUpdateConfiguration(string schema)
        {
            ToTable("PerformanceMeasureExpectedSubcategoryOptionUpdate", schema);
            HasKey(x => x.PerformanceMeasureExpectedSubcategoryOptionUpdateID);
            Property(x => x.PerformanceMeasureExpectedSubcategoryOptionUpdateID).HasColumnName(@"PerformanceMeasureExpectedSubcategoryOptionUpdateID").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.TenantID).HasColumnName(@"TenantID").HasColumnType("int").IsRequired();
            Property(x => x.PerformanceMeasureExpectedUpdateID).HasColumnName(@"PerformanceMeasureExpectedUpdateID").HasColumnType("int").IsRequired();
            Property(x => x.PerformanceMeasureSubcategoryOptionID).HasColumnName(@"PerformanceMeasureSubcategoryOptionID").HasColumnType("int").IsRequired();
            Property(x => x.PerformanceMeasureID).HasColumnName(@"PerformanceMeasureID").HasColumnType("int").IsRequired();
            Property(x => x.PerformanceMeasureSubcategoryID).HasColumnName(@"PerformanceMeasureSubcategoryID").HasColumnType("int").IsRequired();

            // Foreign keys
            HasRequired(a => a.PerformanceMeasureExpectedUpdate).WithMany(b => b.PerformanceMeasureExpectedSubcategoryOptionUpdates).HasForeignKey(c => c.PerformanceMeasureExpectedUpdateID).WillCascadeOnDelete(false); // FK_PerformanceMeasureExpectedSubcategoryOptionUpdate_PerformanceMeasureExpectedUpdate_PerformanceMeasureExpectedUpdateID
            HasRequired(a => a.PerformanceMeasureSubcategoryOption).WithMany(b => b.PerformanceMeasureExpectedSubcategoryOptionUpdates).HasForeignKey(c => c.PerformanceMeasureSubcategoryOptionID).WillCascadeOnDelete(false); // FK_PerformanceMeasureExpectedSubcategoryOptionUpdate_PerformanceMeasureSubcategoryOption_PerformanceMeasureSubcategoryOptionID
            HasRequired(a => a.PerformanceMeasure).WithMany(b => b.PerformanceMeasureExpectedSubcategoryOptionUpdates).HasForeignKey(c => c.PerformanceMeasureID).WillCascadeOnDelete(false); // FK_PerformanceMeasureExpectedSubcategoryOptionUpdate_PerformanceMeasure_PerformanceMeasureID
            HasRequired(a => a.PerformanceMeasureSubcategory).WithMany(b => b.PerformanceMeasureExpectedSubcategoryOptionUpdates).HasForeignKey(c => c.PerformanceMeasureSubcategoryID).WillCascadeOnDelete(false); // FK_PerformanceMeasureExpectedSubcategoryOptionUpdate_PerformanceMeasureSubcategory_PerformanceMeasureSubcategoryID
        }
    }
}