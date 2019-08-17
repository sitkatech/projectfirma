//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProjectUpdateBatch]
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectFirmaModels.Models
{
    public class ProjectUpdateBatchConfiguration : EntityTypeConfiguration<ProjectUpdateBatch>
    {
        public ProjectUpdateBatchConfiguration() : this("dbo"){}

        public ProjectUpdateBatchConfiguration(string schema)
        {
            ToTable("ProjectUpdateBatch", schema);
            HasKey(x => x.ProjectUpdateBatchID);
            Property(x => x.ProjectUpdateBatchID).HasColumnName(@"ProjectUpdateBatchID").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.TenantID).HasColumnName(@"TenantID").HasColumnType("int").IsRequired();
            Property(x => x.ProjectID).HasColumnName(@"ProjectID").HasColumnType("int").IsRequired();
            Property(x => x.LastUpdateDate).HasColumnName(@"LastUpdateDate").HasColumnType("datetime").IsRequired();
            Property(x => x.PerformanceMeasureActualYearsExemptionExplanation).HasColumnName(@"PerformanceMeasureActualYearsExemptionExplanation").HasColumnType("varchar").IsOptional().IsUnicode(false).HasMaxLength(4000);
            Property(x => x.LastUpdatePersonID).HasColumnName(@"LastUpdatePersonID").HasColumnType("int").IsRequired();
            Property(x => x.BasicsComment).HasColumnName(@"BasicsComment").HasColumnType("varchar").IsOptional().IsUnicode(false).HasMaxLength(1000);
            Property(x => x.ExpendituresComment).HasColumnName(@"ExpendituresComment").HasColumnType("varchar").IsOptional().IsUnicode(false).HasMaxLength(1000);
            Property(x => x.ReportedPerformanceMeasuresComment).HasColumnName(@"ReportedPerformanceMeasuresComment").HasColumnType("varchar").IsOptional().IsUnicode(false).HasMaxLength(1000);
            Property(x => x.LocationSimpleComment).HasColumnName(@"LocationSimpleComment").HasColumnType("varchar").IsOptional().IsUnicode(false).HasMaxLength(1000);
            Property(x => x.LocationDetailedComment).HasColumnName(@"LocationDetailedComment").HasColumnType("varchar").IsOptional().IsUnicode(false).HasMaxLength(1000);
            Property(x => x.BudgetsComment).HasColumnName(@"BudgetsComment").HasColumnType("varchar").IsOptional().IsUnicode(false).HasMaxLength(1000);
            Property(x => x.ProjectUpdateStateID).HasColumnName(@"ProjectUpdateStateID").HasColumnType("int").IsRequired();
            Property(x => x.IsPhotosUpdated).HasColumnName(@"IsPhotosUpdated").HasColumnType("bit").IsRequired();
            Property(x => x.BasicsDiffLog).HasColumnName(@"BasicsDiffLog").HasColumnType("varchar").IsOptional();
            Property(x => x.PerformanceMeasureDiffLog).HasColumnName(@"PerformanceMeasureDiffLog").HasColumnType("varchar").IsOptional();
            Property(x => x.ExpendituresDiffLog).HasColumnName(@"ExpendituresDiffLog").HasColumnType("varchar").IsOptional();
            Property(x => x.BudgetsDiffLog).HasColumnName(@"BudgetsDiffLog").HasColumnType("varchar").IsOptional();
            Property(x => x.ExternalLinksDiffLog).HasColumnName(@"ExternalLinksDiffLog").HasColumnType("varchar").IsOptional();
            Property(x => x.NotesDiffLog).HasColumnName(@"NotesDiffLog").HasColumnType("varchar").IsOptional();
            Property(x => x.GeospatialAreaComment).HasColumnName(@"GeospatialAreaComment").HasColumnType("varchar").IsOptional().IsUnicode(false).HasMaxLength(1000);
            Property(x => x.ExpectedFundingComment).HasColumnName(@"ExpectedFundingComment").HasColumnType("varchar").IsOptional().IsUnicode(false).HasMaxLength(1000);
            Property(x => x.ExpectedFundingDiffLog).HasColumnName(@"ExpectedFundingDiffLog").HasColumnType("varchar").IsOptional();
            Property(x => x.OrganizationsComment).HasColumnName(@"OrganizationsComment").HasColumnType("varchar").IsOptional().IsUnicode(false).HasMaxLength(1000);
            Property(x => x.OrganizationsDiffLog).HasColumnName(@"OrganizationsDiffLog").HasColumnType("varchar").IsOptional().IsUnicode(false).HasMaxLength(1);
            Property(x => x.NoExpendituresToReportExplanation).HasColumnName(@"NoExpendituresToReportExplanation").HasColumnType("varchar").IsOptional();
            Property(x => x.ExpectedPerformanceMeasuresComment).HasColumnName(@"ExpectedPerformanceMeasuresComment").HasColumnType("varchar").IsOptional().IsUnicode(false).HasMaxLength(1000);
            Property(x => x.TechnicalAssistanceRequestsComment).HasColumnName(@"TechnicalAssistanceRequestsComment").HasColumnType("varchar").IsOptional().IsUnicode(false).HasMaxLength(1000);
            Property(x => x.ContactsComment).HasColumnName(@"ContactsComment").HasColumnType("varchar").IsOptional().IsUnicode(false).HasMaxLength(1000);
            Property(x => x.ExpectedFundingUpdateNote).HasColumnName(@"ExpectedFundingUpdateNote").HasColumnType("varchar").IsOptional().IsUnicode(false).HasMaxLength(500);

            // Foreign keys
            HasRequired(a => a.Project).WithMany(b => b.ProjectUpdateBatches).HasForeignKey(c => c.ProjectID).WillCascadeOnDelete(false); // FK_ProjectUpdateBatch_Project_ProjectID
            HasRequired(a => a.LastUpdatePerson).WithMany(b => b.ProjectUpdateBatchesWhereYouAreTheLastUpdatePerson).HasForeignKey(c => c.LastUpdatePersonID).WillCascadeOnDelete(false); // FK_ProjectUpdateBatch_Person_LastUpdatePersonID_PersonID
        }
    }
}