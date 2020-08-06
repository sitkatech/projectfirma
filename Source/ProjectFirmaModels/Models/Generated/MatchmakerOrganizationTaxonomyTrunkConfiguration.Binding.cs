//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[MatchmakerOrganizationTaxonomyTrunk]
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectFirmaModels.Models
{
    public class MatchmakerOrganizationTaxonomyTrunkConfiguration : EntityTypeConfiguration<MatchmakerOrganizationTaxonomyTrunk>
    {
        public MatchmakerOrganizationTaxonomyTrunkConfiguration() : this("dbo"){}

        public MatchmakerOrganizationTaxonomyTrunkConfiguration(string schema)
        {
            ToTable("MatchmakerOrganizationTaxonomyTrunk", schema);
            HasKey(x => x.MatchmakerOrganizationTaxonomyTrunkID);
            Property(x => x.MatchmakerOrganizationTaxonomyTrunkID).HasColumnName(@"MatchmakerOrganizationTaxonomyTrunkID").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.TenantID).HasColumnName(@"TenantID").HasColumnType("int").IsRequired();
            Property(x => x.OrganizationID).HasColumnName(@"OrganizationID").HasColumnType("int").IsRequired();
            Property(x => x.TaxonomyTrunkID).HasColumnName(@"TaxonomyTrunkID").HasColumnType("int").IsRequired();
            Property(x => x.IsActive).HasColumnName(@"IsActive").HasColumnType("bit").IsRequired();

            // Foreign keys
            HasRequired(a => a.Organization).WithMany(b => b.MatchmakerOrganizationTaxonomyTrunks).HasForeignKey(c => c.OrganizationID).WillCascadeOnDelete(false); // FK_MatchmakerOrganizationTaxonomyTrunk_Organization_OrganizationID
            HasRequired(a => a.TaxonomyTrunk).WithMany(b => b.MatchmakerOrganizationTaxonomyTrunks).HasForeignKey(c => c.TaxonomyTrunkID).WillCascadeOnDelete(false); // FK_MatchmakerOrganizationTaxonomyTrunk_TaxonomyTrunk_TaxonomyTrunkID
        }
    }
}