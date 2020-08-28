//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[MatchmakerOrganizationTaxonomyLeaf]
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectFirmaModels.Models
{
    public class MatchmakerOrganizationTaxonomyLeafConfiguration : EntityTypeConfiguration<MatchmakerOrganizationTaxonomyLeaf>
    {
        public MatchmakerOrganizationTaxonomyLeafConfiguration() : this("dbo"){}

        public MatchmakerOrganizationTaxonomyLeafConfiguration(string schema)
        {
            ToTable("MatchmakerOrganizationTaxonomyLeaf", schema);
            HasKey(x => x.MatchmakerOrganizationTaxonomyLeafID);
            Property(x => x.MatchmakerOrganizationTaxonomyLeafID).HasColumnName(@"MatchmakerOrganizationTaxonomyLeafID").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.TenantID).HasColumnName(@"TenantID").HasColumnType("int").IsRequired();
            Property(x => x.OrganizationID).HasColumnName(@"OrganizationID").HasColumnType("int").IsRequired();
            Property(x => x.TaxonomyLeafID).HasColumnName(@"TaxonomyLeafID").HasColumnType("int").IsRequired();
            Property(x => x.IsActive).HasColumnName(@"IsActive").HasColumnType("bit").IsRequired();

            // Foreign keys
            HasRequired(a => a.Organization).WithMany(b => b.MatchmakerOrganizationTaxonomyLeafs).HasForeignKey(c => c.OrganizationID).WillCascadeOnDelete(false); // FK_MatchmakerOrganizationTaxonomyLeaf_Organization_OrganizationID
            HasRequired(a => a.TaxonomyLeaf).WithMany(b => b.MatchmakerOrganizationTaxonomyLeafs).HasForeignKey(c => c.TaxonomyLeafID).WillCascadeOnDelete(false); // FK_MatchmakerOrganizationTaxonomyLeaf_TaxonomyLeaf_TaxonomyLeafID
        }
    }
}