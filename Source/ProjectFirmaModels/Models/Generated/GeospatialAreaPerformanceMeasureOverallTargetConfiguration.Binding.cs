//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[GeospatialAreaPerformanceMeasureOverallTarget]
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectFirmaModels.Models
{
    public class GeospatialAreaPerformanceMeasureOverallTargetConfiguration : EntityTypeConfiguration<GeospatialAreaPerformanceMeasureOverallTarget>
    {
        public GeospatialAreaPerformanceMeasureOverallTargetConfiguration() : this("dbo"){}

        public GeospatialAreaPerformanceMeasureOverallTargetConfiguration(string schema)
        {
            ToTable("GeospatialAreaPerformanceMeasureOverallTarget", schema);
            HasKey(x => x.GeospatialAreaPerformanceMeasureOverallTargetID);
            Property(x => x.GeospatialAreaPerformanceMeasureOverallTargetID).HasColumnName(@"GeospatialAreaPerformanceMeasureOverallTargetID").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.TenantID).HasColumnName(@"TenantID").HasColumnType("int").IsRequired();
            Property(x => x.GeospatialAreaID).HasColumnName(@"GeospatialAreaID").HasColumnType("int").IsRequired();
            Property(x => x.PerformanceMeasureID).HasColumnName(@"PerformanceMeasureID").HasColumnType("int").IsRequired();
            Property(x => x.GeospatialAreaPerformanceMeasureTargetValue).HasColumnName(@"GeospatialAreaPerformanceMeasureTargetValue").HasColumnType("float").IsRequired();
            Property(x => x.GeospatialAreaPerformanceMeasureTargetValueLabel).HasColumnName(@"GeospatialAreaPerformanceMeasureTargetValueLabel").HasColumnType("varchar").IsOptional().IsUnicode(false).HasMaxLength(100);

            // Foreign keys
            HasRequired(a => a.GeospatialArea).WithMany(b => b.GeospatialAreaPerformanceMeasureOverallTargets).HasForeignKey(c => c.GeospatialAreaID).WillCascadeOnDelete(false); // FK_GeospatialAreaPerformanceMeasureOverallTarget_GeospatialArea_GeospatialAreaID
            HasRequired(a => a.PerformanceMeasure).WithMany(b => b.GeospatialAreaPerformanceMeasureOverallTargets).HasForeignKey(c => c.PerformanceMeasureID).WillCascadeOnDelete(false); // FK_GeospatialAreaPerformanceMeasureOverallTarget_PerformanceMeasure_PerformanceMeasureID
        }
    }
}