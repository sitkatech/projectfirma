//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[PerformanceMeasureActualSubcategoryOptionUpdate]
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectFirmaModels.Models
{
    public class PerformanceMeasureActualSubcategoryOptionUpdateConfiguration : EntityTypeConfiguration<PerformanceMeasureActualSubcategoryOptionUpdate>
    {
        public PerformanceMeasureActualSubcategoryOptionUpdateConfiguration() : this("dbo"){}

        public PerformanceMeasureActualSubcategoryOptionUpdateConfiguration(string schema)
        {
            ToTable("PerformanceMeasureActualSubcategoryOptionUpdate", schema);
            HasKey(x => x.PerformanceMeasureActualSubcategoryOptionUpdateID);
            Property(x => x.PerformanceMeasureActualSubcategoryOptionUpdateID).HasColumnName(@"PerformanceMeasureActualSubcategoryOptionUpdateID").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.TenantID).HasColumnName(@"TenantID").HasColumnType("int").IsRequired();
            Property(x => x.PerformanceMeasureActualUpdateID).HasColumnName(@"PerformanceMeasureActualUpdateID").HasColumnType("int").IsRequired();
            Property(x => x.PerformanceMeasureSubcategoryOptionID).HasColumnName(@"PerformanceMeasureSubcategoryOptionID").HasColumnType("int").IsRequired();
            Property(x => x.PerformanceMeasureID).HasColumnName(@"PerformanceMeasureID").HasColumnType("int").IsRequired();
            Property(x => x.PerformanceMeasureSubcategoryID).HasColumnName(@"PerformanceMeasureSubcategoryID").HasColumnType("int").IsRequired();

            // Foreign keys
            HasRequired(a => a.PerformanceMeasureActualUpdate).WithMany(b => b.PerformanceMeasureActualSubcategoryOptionUpdates).HasForeignKey(c => c.PerformanceMeasureActualUpdateID).WillCascadeOnDelete(false); // FK_PerformanceMeasureActualSubcategoryOptionUpdate_PerformanceMeasureActualUpdate_PerformanceMeasureActualUpdateID
            HasRequired(a => a.PerformanceMeasureSubcategoryOption).WithMany(b => b.PerformanceMeasureActualSubcategoryOptionUpdates).HasForeignKey(c => c.PerformanceMeasureSubcategoryOptionID).WillCascadeOnDelete(false); // FK_PerformanceMeasureActualSubcategoryOptionUpdate_PerformanceMeasureSubcategoryOption_PerformanceMeasureSubcategoryOptionID
            HasRequired(a => a.PerformanceMeasure).WithMany(b => b.PerformanceMeasureActualSubcategoryOptionUpdates).HasForeignKey(c => c.PerformanceMeasureID).WillCascadeOnDelete(false); // FK_PerformanceMeasureActualSubcategoryOptionUpdate_PerformanceMeasure_PerformanceMeasureID
            HasRequired(a => a.PerformanceMeasureSubcategory).WithMany(b => b.PerformanceMeasureActualSubcategoryOptionUpdates).HasForeignKey(c => c.PerformanceMeasureSubcategoryID).WillCascadeOnDelete(false); // FK_PerformanceMeasureActualSubcategoryOptionUpdate_PerformanceMeasureSubcategory_PerformanceMeasureSubcategoryID
        }
    }
}