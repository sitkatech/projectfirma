//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[TaxonomyTrunk]
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectFirmaModels.Models
{
    public class TaxonomyTrunkConfiguration : EntityTypeConfiguration<TaxonomyTrunk>
    {
        public TaxonomyTrunkConfiguration() : this("dbo"){}

        public TaxonomyTrunkConfiguration(string schema)
        {
            ToTable("TaxonomyTrunk", schema);
            HasKey(x => x.TaxonomyTrunkID);
            Property(x => x.TaxonomyTrunkID).HasColumnName(@"TaxonomyTrunkID").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.TenantID).HasColumnName(@"TenantID").HasColumnType("int").IsRequired();
            Property(x => x.TaxonomyTrunkName).HasColumnName(@"TaxonomyTrunkName").HasColumnType("varchar").IsRequired().IsUnicode(false).HasMaxLength(100);
            Property(x => x.TaxonomyTrunkDescription).HasColumnName(@"TaxonomyTrunkDescription").HasColumnType("varchar").IsOptional();
            Property(x => x.ThemeColor).HasColumnName(@"ThemeColor").HasColumnType("varchar").IsOptional().IsUnicode(false).HasMaxLength(20);
            Property(x => x.TaxonomyTrunkCode).HasColumnName(@"TaxonomyTrunkCode").HasColumnType("varchar").IsOptional().IsUnicode(false).HasMaxLength(10);
            Property(x => x.TaxonomyTrunkSortOrder).HasColumnName(@"TaxonomyTrunkSortOrder").HasColumnType("int").IsOptional();

            // Foreign keys

        }
    }
}