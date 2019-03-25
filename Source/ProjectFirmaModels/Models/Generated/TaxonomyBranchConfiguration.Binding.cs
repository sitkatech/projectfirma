//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[TaxonomyBranch]
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectFirmaModels.Models
{
    public class TaxonomyBranchConfiguration : EntityTypeConfiguration<TaxonomyBranch>
    {
        public TaxonomyBranchConfiguration() : this("dbo"){}

        public TaxonomyBranchConfiguration(string schema)
        {
            ToTable("TaxonomyBranch", schema);
            HasKey(x => x.TaxonomyBranchID);
            Property(x => x.TaxonomyBranchID).HasColumnName(@"TaxonomyBranchID").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.TenantID).HasColumnName(@"TenantID").HasColumnType("int").IsRequired();
            Property(x => x.TaxonomyTrunkID).HasColumnName(@"TaxonomyTrunkID").HasColumnType("int").IsRequired();
            Property(x => x.TaxonomyBranchName).HasColumnName(@"TaxonomyBranchName").HasColumnType("varchar").IsRequired().IsUnicode(false).HasMaxLength(100);
            Property(x => x.TaxonomyBranchDescription).HasColumnName(@"TaxonomyBranchDescription").HasColumnType("varchar").IsOptional();
            Property(x => x.ThemeColor).HasColumnName(@"ThemeColor").HasColumnType("varchar").IsOptional().IsUnicode(false).HasMaxLength(7);
            Property(x => x.TaxonomyBranchCode).HasColumnName(@"TaxonomyBranchCode").HasColumnType("varchar").IsOptional().IsUnicode(false).HasMaxLength(10);
            Property(x => x.TaxonomyBranchSortOrder).HasColumnName(@"TaxonomyBranchSortOrder").HasColumnType("int").IsOptional();

            // Foreign keys
            HasRequired(a => a.TaxonomyTrunk).WithMany(b => b.TaxonomyBranches).HasForeignKey(c => c.TaxonomyTrunkID).WillCascadeOnDelete(false); // FK_TaxonomyBranch_TaxonomyTrunk_TaxonomyTrunkID
        }
    }
}