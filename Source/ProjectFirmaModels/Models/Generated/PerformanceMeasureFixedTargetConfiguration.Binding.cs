//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[PerformanceMeasureFixedTarget]
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectFirmaModels.Models
{
    public class PerformanceMeasureFixedTargetConfiguration : EntityTypeConfiguration<PerformanceMeasureFixedTarget>
    {
        public PerformanceMeasureFixedTargetConfiguration() : this("dbo"){}

        public PerformanceMeasureFixedTargetConfiguration(string schema)
        {
            ToTable("PerformanceMeasureFixedTarget", schema);
            HasKey(x => x.PerformanceMeasureFixedTargetID);
            Property(x => x.PerformanceMeasureFixedTargetID).HasColumnName(@"PerformanceMeasureFixedTargetID").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.TenantID).HasColumnName(@"TenantID").HasColumnType("int").IsRequired();
            Property(x => x.PerformanceMeasureID).HasColumnName(@"PerformanceMeasureID").HasColumnType("int").IsRequired();
            Property(x => x.PerformanceMeasureTargetValue).HasColumnName(@"PerformanceMeasureTargetValue").HasColumnType("float").IsOptional();
            Property(x => x.PerformanceMeasureTargetValueLabel).HasColumnName(@"PerformanceMeasureTargetValueLabel").HasColumnType("varchar").IsOptional().IsUnicode(false).HasMaxLength(100);

            // Foreign keys
            HasRequired(a => a.PerformanceMeasure).WithMany(b => b.PerformanceMeasureFixedTargets).HasForeignKey(c => c.PerformanceMeasureID).WillCascadeOnDelete(false); // FK_PerformanceMeasureFixedTarget_PerformanceMeasure_PerformanceMeasureID
        }
    }
}