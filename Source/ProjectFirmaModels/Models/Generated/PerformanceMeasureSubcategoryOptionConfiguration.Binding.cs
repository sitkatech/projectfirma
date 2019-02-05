//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[PerformanceMeasureSubcategoryOption]
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectFirmaModels.Models
{
    public class PerformanceMeasureSubcategoryOptionConfiguration : EntityTypeConfiguration<PerformanceMeasureSubcategoryOption>
    {
        public PerformanceMeasureSubcategoryOptionConfiguration() : this("dbo"){}

        public PerformanceMeasureSubcategoryOptionConfiguration(string schema)
        {
            ToTable("PerformanceMeasureSubcategoryOption", schema);
            HasKey(x => x.PerformanceMeasureSubcategoryOptionID);
            Property(x => x.PerformanceMeasureSubcategoryOptionID).HasColumnName(@"PerformanceMeasureSubcategoryOptionID").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.TenantID).HasColumnName(@"TenantID").HasColumnType("int").IsRequired();
            Property(x => x.PerformanceMeasureSubcategoryID).HasColumnName(@"PerformanceMeasureSubcategoryID").HasColumnType("int").IsRequired();
            Property(x => x.PerformanceMeasureSubcategoryOptionName).HasColumnName(@"PerformanceMeasureSubcategoryOptionName").HasColumnType("varchar").IsRequired().IsUnicode(false).HasMaxLength(100);
            Property(x => x.SortOrder).HasColumnName(@"SortOrder").HasColumnType("int").IsOptional();
            Property(x => x.ShowOnFactSheet).HasColumnName(@"ShowOnFactSheet").HasColumnType("bit").IsRequired();

            // Foreign keys
            HasRequired(a => a.PerformanceMeasureSubcategory).WithMany(b => b.PerformanceMeasureSubcategoryOptions).HasForeignKey(c => c.PerformanceMeasureSubcategoryID).WillCascadeOnDelete(false); // FK_PerformanceMeasureSubcategoryOption_PerformanceMeasureSubcategory_PerformanceMeasureSubcategoryID
        }
    }
}