//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[TaxonomyLeafPerformanceMeasure]
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectFirmaModels.Models
{
    public class TaxonomyLeafPerformanceMeasureConfiguration : EntityTypeConfiguration<TaxonomyLeafPerformanceMeasure>
    {
        public TaxonomyLeafPerformanceMeasureConfiguration() : this("dbo"){}

        public TaxonomyLeafPerformanceMeasureConfiguration(string schema)
        {
            ToTable("TaxonomyLeafPerformanceMeasure", schema);
            HasKey(x => x.TaxonomyLeafPerformanceMeasureID);
            Property(x => x.TaxonomyLeafPerformanceMeasureID).HasColumnName(@"TaxonomyLeafPerformanceMeasureID").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.TenantID).HasColumnName(@"TenantID").HasColumnType("int").IsRequired();
            Property(x => x.TaxonomyLeafID).HasColumnName(@"TaxonomyLeafID").HasColumnType("int").IsRequired();
            Property(x => x.PerformanceMeasureID).HasColumnName(@"PerformanceMeasureID").HasColumnType("int").IsRequired();
            Property(x => x.IsPrimaryTaxonomyLeaf).HasColumnName(@"IsPrimaryTaxonomyLeaf").HasColumnType("bit").IsRequired();

            // Foreign keys
            HasRequired(a => a.TaxonomyLeaf).WithMany(b => b.TaxonomyLeafPerformanceMeasures).HasForeignKey(c => c.TaxonomyLeafID).WillCascadeOnDelete(false); // FK_TaxonomyLeafPerformanceMeasure_TaxonomyLeaf_TaxonomyLeafID
            HasRequired(a => a.PerformanceMeasure).WithMany(b => b.TaxonomyLeafPerformanceMeasures).HasForeignKey(c => c.PerformanceMeasureID).WillCascadeOnDelete(false); // FK_TaxonomyLeafPerformanceMeasure_PerformanceMeasure_PerformanceMeasureID
        }
    }
}