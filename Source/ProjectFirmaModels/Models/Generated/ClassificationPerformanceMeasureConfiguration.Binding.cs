//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ClassificationPerformanceMeasure]
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectFirmaModels.Models
{
    public class ClassificationPerformanceMeasureConfiguration : EntityTypeConfiguration<ClassificationPerformanceMeasure>
    {
        public ClassificationPerformanceMeasureConfiguration() : this("dbo"){}

        public ClassificationPerformanceMeasureConfiguration(string schema)
        {
            ToTable("ClassificationPerformanceMeasure", schema);
            HasKey(x => x.ClassificationPerformanceMeasureID);
            Property(x => x.ClassificationPerformanceMeasureID).HasColumnName(@"ClassificationPerformanceMeasureID").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.TenantID).HasColumnName(@"TenantID").HasColumnType("int").IsRequired();
            Property(x => x.ClassificationID).HasColumnName(@"ClassificationID").HasColumnType("int").IsRequired();
            Property(x => x.PerformanceMeasureID).HasColumnName(@"PerformanceMeasureID").HasColumnType("int").IsRequired();
            Property(x => x.IsPrimaryChart).HasColumnName(@"IsPrimaryChart").HasColumnType("bit").IsRequired();

            // Foreign keys
            HasRequired(a => a.Classification).WithMany(b => b.ClassificationPerformanceMeasures).HasForeignKey(c => c.ClassificationID).WillCascadeOnDelete(false); // FK_ClassificationPerformanceMeasure_Classification_ClassificationID
            HasRequired(a => a.PerformanceMeasure).WithMany(b => b.ClassificationPerformanceMeasures).HasForeignKey(c => c.PerformanceMeasureID).WillCascadeOnDelete(false); // FK_ClassificationPerformanceMeasure_PerformanceMeasure_PerformanceMeasureID
        }
    }
}