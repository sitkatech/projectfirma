//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[PerformanceMeasure]
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectFirmaModels.Models
{
    public class PerformanceMeasureConfiguration : EntityTypeConfiguration<PerformanceMeasure>
    {
        public PerformanceMeasureConfiguration() : this("dbo"){}

        public PerformanceMeasureConfiguration(string schema)
        {
            ToTable("PerformanceMeasure", schema);
            HasKey(x => x.PerformanceMeasureID);
            Property(x => x.PerformanceMeasureID).HasColumnName(@"PerformanceMeasureID").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.TenantID).HasColumnName(@"TenantID").HasColumnType("int").IsRequired();
            Property(x => x.CriticalDefinitions).HasColumnName(@"CriticalDefinitions").HasColumnType("varchar").IsOptional();
            Property(x => x.ProjectReporting).HasColumnName(@"ProjectReporting").HasColumnType("varchar").IsOptional();
            Property(x => x.PerformanceMeasureDisplayName).HasColumnName(@"PerformanceMeasureDisplayName").HasColumnType("varchar").IsRequired().IsUnicode(false).HasMaxLength(200);
            Property(x => x.MeasurementUnitTypeID).HasColumnName(@"MeasurementUnitTypeID").HasColumnType("int").IsRequired();
            Property(x => x.PerformanceMeasureTypeID).HasColumnName(@"PerformanceMeasureTypeID").HasColumnType("int").IsRequired();
            Property(x => x.PerformanceMeasureDefinition).HasColumnName(@"PerformanceMeasureDefinition").HasColumnType("varchar").IsOptional();
            Property(x => x.DataSourceText).HasColumnName(@"DataSourceText").HasColumnType("varchar").IsOptional().IsUnicode(false).HasMaxLength(200);
            Property(x => x.ExternalDataSourceUrl).HasColumnName(@"ExternalDataSourceUrl").HasColumnType("varchar").IsOptional().IsUnicode(false).HasMaxLength(200);
            Property(x => x.ChartCaption).HasColumnName(@"ChartCaption").HasColumnType("varchar").IsOptional().IsUnicode(false).HasMaxLength(1000);
            Property(x => x.PerformanceMeasureSortOrder).HasColumnName(@"PerformanceMeasureSortOrder").HasColumnType("int").IsOptional();
            Property(x => x.IsSummable).HasColumnName(@"IsSummable").HasColumnType("bit").IsRequired();
            Property(x => x.PerformanceMeasureDataSourceTypeID).HasColumnName(@"PerformanceMeasureDataSourceTypeID").HasColumnType("int").IsRequired();
            Property(x => x.Importance).HasColumnName(@"Importance").HasColumnType("varchar").IsOptional();
            Property(x => x.AdditionalInformation).HasColumnName(@"AdditionalInformation").HasColumnType("varchar").IsOptional();

            // Foreign keys

        }
    }
}