//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[PerformanceMeasureSubcategory]
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectFirmaModels.Models
{
    public class PerformanceMeasureSubcategoryConfiguration : EntityTypeConfiguration<PerformanceMeasureSubcategory>
    {
        public PerformanceMeasureSubcategoryConfiguration() : this("dbo"){}

        public PerformanceMeasureSubcategoryConfiguration(string schema)
        {
            ToTable("PerformanceMeasureSubcategory", schema);
            HasKey(x => x.PerformanceMeasureSubcategoryID);
            Property(x => x.PerformanceMeasureSubcategoryID).HasColumnName(@"PerformanceMeasureSubcategoryID").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.TenantID).HasColumnName(@"TenantID").HasColumnType("int").IsRequired();
            Property(x => x.PerformanceMeasureID).HasColumnName(@"PerformanceMeasureID").HasColumnType("int").IsRequired();
            Property(x => x.PerformanceMeasureSubcategoryDisplayName).HasColumnName(@"PerformanceMeasureSubcategoryDisplayName").HasColumnType("varchar").IsRequired().IsUnicode(false).HasMaxLength(200);
            Property(x => x.ChartConfigurationJson).HasColumnName(@"ChartConfigurationJson").HasColumnType("varchar").IsOptional();
            Property(x => x.GoogleChartTypeID).HasColumnName(@"GoogleChartTypeID").HasColumnType("int").IsOptional();
            Property(x => x.CumulativeChartConfigurationJson).HasColumnName(@"CumulativeChartConfigurationJson").HasColumnType("varchar").IsOptional();
            Property(x => x.CumulativeGoogleChartTypeID).HasColumnName(@"CumulativeGoogleChartTypeID").HasColumnType("int").IsOptional();
            Property(x => x.GeospatialAreaTargetChartConfigurationJson).HasColumnName(@"GeospatialAreaTargetChartConfigurationJson").HasColumnType("varchar").IsOptional();
            Property(x => x.GeospatialAreaTargetGoogleChartTypeID).HasColumnName(@"GeospatialAreaTargetGoogleChartTypeID").HasColumnType("int").IsOptional();

            // Foreign keys
            HasRequired(a => a.PerformanceMeasure).WithMany(b => b.PerformanceMeasureSubcategories).HasForeignKey(c => c.PerformanceMeasureID).WillCascadeOnDelete(false); // FK_PerformanceMeasureSubcategory_PerformanceMeasure_PerformanceMeasureID
        }
    }
}