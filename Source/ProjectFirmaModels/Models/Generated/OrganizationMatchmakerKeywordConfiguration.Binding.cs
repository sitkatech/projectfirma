//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[OrganizationMatchmakerKeyword]
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectFirmaModels.Models
{
    public class OrganizationMatchmakerKeywordConfiguration : EntityTypeConfiguration<OrganizationMatchmakerKeyword>
    {
        public OrganizationMatchmakerKeywordConfiguration() : this("dbo"){}

        public OrganizationMatchmakerKeywordConfiguration(string schema)
        {
            ToTable("OrganizationMatchmakerKeyword", schema);
            HasKey(x => x.OrganizationMatchmakerKeywordID);
            Property(x => x.OrganizationMatchmakerKeywordID).HasColumnName(@"OrganizationMatchmakerKeywordID").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.TenantID).HasColumnName(@"TenantID").HasColumnType("int").IsRequired();
            Property(x => x.OrganizationID).HasColumnName(@"OrganizationID").HasColumnType("int").IsRequired();
            Property(x => x.MatchmakerKeywordID).HasColumnName(@"MatchmakerKeywordID").HasColumnType("int").IsRequired();

            // Foreign keys
            HasRequired(a => a.Organization).WithMany(b => b.OrganizationMatchmakerKeywords).HasForeignKey(c => c.OrganizationID).WillCascadeOnDelete(false); // FK_OrganizationMatchmakerKeyword_Organization_OrganizationID
            HasRequired(a => a.MatchmakerKeyword).WithMany(b => b.OrganizationMatchmakerKeywords).HasForeignKey(c => c.MatchmakerKeywordID).WillCascadeOnDelete(false); // FK_OrganizationMatchmakerKeyword_MatchmakerKeyword_MatchmakerKeywordID
        }
    }
}