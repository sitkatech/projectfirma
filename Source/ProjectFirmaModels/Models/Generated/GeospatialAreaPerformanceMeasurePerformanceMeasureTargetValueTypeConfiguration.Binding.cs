//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[GeospatialAreaPerformanceMeasurePerformanceMeasureTargetValueType]
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectFirmaModels.Models
{
    public class GeospatialAreaPerformanceMeasurePerformanceMeasureTargetValueTypeConfiguration : EntityTypeConfiguration<GeospatialAreaPerformanceMeasurePerformanceMeasureTargetValueType>
    {
        public GeospatialAreaPerformanceMeasurePerformanceMeasureTargetValueTypeConfiguration() : this("dbo"){}

        public GeospatialAreaPerformanceMeasurePerformanceMeasureTargetValueTypeConfiguration(string schema)
        {
            ToTable("GeospatialAreaPerformanceMeasurePerformanceMeasureTargetValueType", schema);
            HasKey(x => x.GeospatialAreaPerformanceMeasurePerformanceMeasureTargetValueTypeID);
            Property(x => x.GeospatialAreaPerformanceMeasurePerformanceMeasureTargetValueTypeID).HasColumnName(@"GeospatialAreaPerformanceMeasurePerformanceMeasureTargetValueTypeID").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.TenantID).HasColumnName(@"TenantID").HasColumnType("int").IsRequired();
            Property(x => x.GeospatialAreaID).HasColumnName(@"GeospatialAreaID").HasColumnType("int").IsRequired();
            Property(x => x.PerformanceMeasureID).HasColumnName(@"PerformanceMeasureID").HasColumnType("int").IsRequired();
            Property(x => x.PerformanceMeasureTargetValueTypeID).HasColumnName(@"PerformanceMeasureTargetValueTypeID").HasColumnType("int").IsRequired();

            // Foreign keys
            HasRequired(a => a.GeospatialArea).WithMany(b => b.GeospatialAreaPerformanceMeasurePerformanceMeasureTargetValueTypes).HasForeignKey(c => c.GeospatialAreaID).WillCascadeOnDelete(false); // FK_GeospatialAreaPerformanceMeasurePerformanceMeasureTargetValueType_GeospatialArea_GeospatialAreaID
            HasRequired(a => a.PerformanceMeasure).WithMany(b => b.GeospatialAreaPerformanceMeasurePerformanceMeasureTargetValueTypes).HasForeignKey(c => c.PerformanceMeasureID).WillCascadeOnDelete(false); // FK_GeospatialAreaPerformanceMeasurePerformanceMeasureTargetValueType_PerformanceMeasure_PerformanceMeasureID
        }
    }
}