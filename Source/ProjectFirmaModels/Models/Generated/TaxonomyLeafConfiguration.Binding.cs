//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[TaxonomyLeaf]
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectFirmaModels.Models
{
    public class TaxonomyLeafConfiguration : EntityTypeConfiguration<TaxonomyLeaf>
    {
        public TaxonomyLeafConfiguration() : this("dbo"){}

        public TaxonomyLeafConfiguration(string schema)
        {
            ToTable("TaxonomyLeaf", schema);
            HasKey(x => x.TaxonomyLeafID);
            Property(x => x.TaxonomyLeafID).HasColumnName(@"TaxonomyLeafID").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.TenantID).HasColumnName(@"TenantID").HasColumnType("int").IsRequired();
            Property(x => x.TaxonomyBranchID).HasColumnName(@"TaxonomyBranchID").HasColumnType("int").IsRequired();
            Property(x => x.TaxonomyLeafName).HasColumnName(@"TaxonomyLeafName").HasColumnType("varchar").IsRequired().IsUnicode(false).HasMaxLength(100);
            Property(x => x.TaxonomyLeafDescription).HasColumnName(@"TaxonomyLeafDescription").HasColumnType("varchar").IsOptional();
            Property(x => x.TaxonomyLeafCode).HasColumnName(@"TaxonomyLeafCode").HasColumnType("varchar").IsOptional().IsUnicode(false).HasMaxLength(10);
            Property(x => x.ThemeColor).HasColumnName(@"ThemeColor").HasColumnType("varchar").IsOptional().IsUnicode(false).HasMaxLength(7);
            Property(x => x.TaxonomyLeafSortOrder).HasColumnName(@"TaxonomyLeafSortOrder").HasColumnType("int").IsOptional();

            // Foreign keys
            HasRequired(a => a.TaxonomyBranch).WithMany(b => b.TaxonomyLeafs).HasForeignKey(c => c.TaxonomyBranchID).WillCascadeOnDelete(false); // FK_TaxonomyLeaf_TaxonomyBranch_TaxonomyBranchID
        }
    }
}