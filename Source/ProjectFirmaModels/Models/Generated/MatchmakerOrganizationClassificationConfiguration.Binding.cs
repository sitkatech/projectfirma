//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[MatchmakerOrganizationClassification]
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectFirmaModels.Models
{
    public class MatchmakerOrganizationClassificationConfiguration : EntityTypeConfiguration<MatchmakerOrganizationClassification>
    {
        public MatchmakerOrganizationClassificationConfiguration() : this("dbo"){}

        public MatchmakerOrganizationClassificationConfiguration(string schema)
        {
            ToTable("MatchmakerOrganizationClassification", schema);
            HasKey(x => x.MatchmakerOrganizationClassificationID);
            Property(x => x.MatchmakerOrganizationClassificationID).HasColumnName(@"MatchmakerOrganizationClassificationID").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.TenantID).HasColumnName(@"TenantID").HasColumnType("int").IsRequired();
            Property(x => x.OrganizationID).HasColumnName(@"OrganizationID").HasColumnType("int").IsRequired();
            Property(x => x.ClassificationID).HasColumnName(@"ClassificationID").HasColumnType("int").IsRequired();

            // Foreign keys
            HasRequired(a => a.Organization).WithMany(b => b.MatchmakerOrganizationClassifications).HasForeignKey(c => c.OrganizationID).WillCascadeOnDelete(false); // FK_MatchmakerOrganizationClassification_Organization_OrganizationID
            HasRequired(a => a.Classification).WithMany(b => b.MatchmakerOrganizationClassifications).HasForeignKey(c => c.ClassificationID).WillCascadeOnDelete(false); // FK_MatchmakerOrganizationClassification_Classification_ClassificationID
        }
    }
}