//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[MatchmakerOrganizationTaxonomyBranch]
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectFirmaModels.Models
{
    public class MatchmakerOrganizationTaxonomyBranchConfiguration : EntityTypeConfiguration<MatchmakerOrganizationTaxonomyBranch>
    {
        public MatchmakerOrganizationTaxonomyBranchConfiguration() : this("dbo"){}

        public MatchmakerOrganizationTaxonomyBranchConfiguration(string schema)
        {
            ToTable("MatchmakerOrganizationTaxonomyBranch", schema);
            HasKey(x => x.MatchmakerOrganizationTaxonomyBranchID);
            Property(x => x.MatchmakerOrganizationTaxonomyBranchID).HasColumnName(@"MatchmakerOrganizationTaxonomyBranchID").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.TenantID).HasColumnName(@"TenantID").HasColumnType("int").IsRequired();
            Property(x => x.OrganizationID).HasColumnName(@"OrganizationID").HasColumnType("int").IsRequired();
            Property(x => x.TaxonomyBranchID).HasColumnName(@"TaxonomyBranchID").HasColumnType("int").IsRequired();
            Property(x => x.IsActive).HasColumnName(@"IsActive").HasColumnType("bit").IsRequired();

            // Foreign keys
            HasRequired(a => a.Organization).WithMany(b => b.MatchmakerOrganizationTaxonomyBranches).HasForeignKey(c => c.OrganizationID).WillCascadeOnDelete(false); // FK_MatchmakerOrganizationTaxonomyBranch_Organization_OrganizationID
            HasRequired(a => a.TaxonomyBranch).WithMany(b => b.MatchmakerOrganizationTaxonomyBranches).HasForeignKey(c => c.TaxonomyBranchID).WillCascadeOnDelete(false); // FK_MatchmakerOrganizationTaxonomyBranch_TaxonomyBranch_TaxonomyBranchID
        }
    }
}