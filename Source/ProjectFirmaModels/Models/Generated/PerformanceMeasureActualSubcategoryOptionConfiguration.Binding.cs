//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[PerformanceMeasureActualSubcategoryOption]
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectFirmaModels.Models
{
    public class PerformanceMeasureActualSubcategoryOptionConfiguration : EntityTypeConfiguration<PerformanceMeasureActualSubcategoryOption>
    {
        public PerformanceMeasureActualSubcategoryOptionConfiguration() : this("dbo"){}

        public PerformanceMeasureActualSubcategoryOptionConfiguration(string schema)
        {
            ToTable("PerformanceMeasureActualSubcategoryOption", schema);
            HasKey(x => x.PerformanceMeasureActualSubcategoryOptionID);
            Property(x => x.PerformanceMeasureActualSubcategoryOptionID).HasColumnName(@"PerformanceMeasureActualSubcategoryOptionID").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.TenantID).HasColumnName(@"TenantID").HasColumnType("int").IsRequired();
            Property(x => x.PerformanceMeasureActualID).HasColumnName(@"PerformanceMeasureActualID").HasColumnType("int").IsRequired();
            Property(x => x.PerformanceMeasureSubcategoryOptionID).HasColumnName(@"PerformanceMeasureSubcategoryOptionID").HasColumnType("int").IsRequired();
            Property(x => x.PerformanceMeasureID).HasColumnName(@"PerformanceMeasureID").HasColumnType("int").IsRequired();
            Property(x => x.PerformanceMeasureSubcategoryID).HasColumnName(@"PerformanceMeasureSubcategoryID").HasColumnType("int").IsRequired();

            // Foreign keys
            HasRequired(a => a.PerformanceMeasureActual).WithMany(b => b.PerformanceMeasureActualSubcategoryOptions).HasForeignKey(c => c.PerformanceMeasureActualID).WillCascadeOnDelete(false); // FK_PerformanceMeasureActualSubcategoryOption_PerformanceMeasureActual_PerformanceMeasureActualID
            HasRequired(a => a.PerformanceMeasureSubcategoryOption).WithMany(b => b.PerformanceMeasureActualSubcategoryOptions).HasForeignKey(c => c.PerformanceMeasureSubcategoryOptionID).WillCascadeOnDelete(false); // FK_PerformanceMeasureActualSubcategoryOption_PerformanceMeasureSubcategoryOption_PerformanceMeasureSubcategoryOptionID
            HasRequired(a => a.PerformanceMeasure).WithMany(b => b.PerformanceMeasureActualSubcategoryOptions).HasForeignKey(c => c.PerformanceMeasureID).WillCascadeOnDelete(false); // FK_PerformanceMeasureActualSubcategoryOption_PerformanceMeasure_PerformanceMeasureID
            HasRequired(a => a.PerformanceMeasureSubcategory).WithMany(b => b.PerformanceMeasureActualSubcategoryOptions).HasForeignKey(c => c.PerformanceMeasureSubcategoryID).WillCascadeOnDelete(false); // FK_PerformanceMeasureActualSubcategoryOption_PerformanceMeasureSubcategory_PerformanceMeasureSubcategoryID
        }
    }
}