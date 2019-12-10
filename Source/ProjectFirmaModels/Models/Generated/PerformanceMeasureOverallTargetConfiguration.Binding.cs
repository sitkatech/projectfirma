//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[PerformanceMeasureOverallTarget]
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectFirmaModels.Models
{
    public class PerformanceMeasureOverallTargetConfiguration : EntityTypeConfiguration<PerformanceMeasureOverallTarget>
    {
        public PerformanceMeasureOverallTargetConfiguration() : this("dbo"){}

        public PerformanceMeasureOverallTargetConfiguration(string schema)
        {
            ToTable("PerformanceMeasureOverallTarget", schema);
            HasKey(x => x.PerformanceMeasureOverallTargetID);
            Property(x => x.PerformanceMeasureOverallTargetID).HasColumnName(@"PerformanceMeasureOverallTargetID").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.TenantID).HasColumnName(@"TenantID").HasColumnType("int").IsRequired();
            Property(x => x.PerformanceMeasureID).HasColumnName(@"PerformanceMeasureID").HasColumnType("int").IsRequired();
            Property(x => x.PerformanceMeasureTargetValue).HasColumnName(@"PerformanceMeasureTargetValue").HasColumnType("float").IsOptional();
            Property(x => x.PerformanceMeasureTargetValueLabel).HasColumnName(@"PerformanceMeasureTargetValueLabel").HasColumnType("varchar").IsOptional().IsUnicode(false).HasMaxLength(100);

            // Foreign keys
            HasRequired(a => a.PerformanceMeasure).WithMany(b => b.PerformanceMeasureOverallTargets).HasForeignKey(c => c.PerformanceMeasureID).WillCascadeOnDelete(false); // FK_PerformanceMeasureOverallTarget_PerformanceMeasure_PerformanceMeasureID
        }
    }
}