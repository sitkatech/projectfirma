//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[MatchmakerOrganizationPerformanceMeasure]
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectFirmaModels.Models
{
    public class MatchmakerOrganizationPerformanceMeasureConfiguration : EntityTypeConfiguration<MatchmakerOrganizationPerformanceMeasure>
    {
        public MatchmakerOrganizationPerformanceMeasureConfiguration() : this("dbo"){}

        public MatchmakerOrganizationPerformanceMeasureConfiguration(string schema)
        {
            ToTable("MatchmakerOrganizationPerformanceMeasure", schema);
            HasKey(x => x.MatchmakerOrganizationPerformanceMeasureID);
            Property(x => x.MatchmakerOrganizationPerformanceMeasureID).HasColumnName(@"MatchmakerOrganizationPerformanceMeasureID").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.TenantID).HasColumnName(@"TenantID").HasColumnType("int").IsRequired();
            Property(x => x.OrganizationID).HasColumnName(@"OrganizationID").HasColumnType("int").IsRequired();
            Property(x => x.PerformanceMeasureID).HasColumnName(@"PerformanceMeasureID").HasColumnType("int").IsRequired();

            // Foreign keys
            HasRequired(a => a.Organization).WithMany(b => b.MatchmakerOrganizationPerformanceMeasures).HasForeignKey(c => c.OrganizationID).WillCascadeOnDelete(false); // FK_MatchmakerOrganizationPerformanceMeasure_Organization_OrganizationID
            HasRequired(a => a.PerformanceMeasure).WithMany(b => b.MatchmakerOrganizationPerformanceMeasures).HasForeignKey(c => c.PerformanceMeasureID).WillCascadeOnDelete(false); // FK_MatchmakerOrganizationPerformanceMeasure_PerformanceMeasure_PerformanceMeasureID
        }
    }
}