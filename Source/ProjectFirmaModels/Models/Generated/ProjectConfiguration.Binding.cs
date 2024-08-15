//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[Project]
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectFirmaModels.Models
{
    public class ProjectConfiguration : EntityTypeConfiguration<Project>
    {
        public ProjectConfiguration() : this("dbo"){}

        public ProjectConfiguration(string schema)
        {
            ToTable("Project", schema);
            HasKey(x => x.ProjectID);
            Property(x => x.ProjectID).HasColumnName(@"ProjectID").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.TenantID).HasColumnName(@"TenantID").HasColumnType("int").IsRequired();
            Property(x => x.TaxonomyLeafID).HasColumnName(@"TaxonomyLeafID").HasColumnType("int").IsRequired();
            Property(x => x.ProjectStageID).HasColumnName(@"ProjectStageID").HasColumnType("int").IsRequired();
            Property(x => x.ProjectName).HasColumnName(@"ProjectName").HasColumnType("varchar").IsRequired().IsUnicode(false).HasMaxLength(140);
            Property(x => x.ProjectDescription).HasColumnName(@"ProjectDescription").HasColumnType("varchar").IsRequired().IsUnicode(false).HasMaxLength(4000);
            Property(x => x.ImplementationStartYear).HasColumnName(@"ImplementationStartYear").HasColumnType("int").IsOptional();
            Property(x => x.CompletionYear).HasColumnName(@"CompletionYear").HasColumnType("int").IsOptional();
            Property(x => x.EstimatedTotalCostDeprecated).HasColumnName(@"EstimatedTotalCostDeprecated").HasColumnType("money").IsOptional().HasPrecision(19,4);
            Property(x => x.ProjectLocationPoint).HasColumnName(@"ProjectLocationPoint").HasColumnType("geometry").IsOptional();
            Property(x => x.PerformanceMeasureActualYearsExemptionExplanation).HasColumnName(@"PerformanceMeasureActualYearsExemptionExplanation").HasColumnType("varchar").IsOptional().IsUnicode(false).HasMaxLength(4000);
            Property(x => x.IsFeatured).HasColumnName(@"IsFeatured").HasColumnType("bit").IsRequired();
            Property(x => x.ProjectLocationNotes).HasColumnName(@"ProjectLocationNotes").HasColumnType("varchar").IsOptional().IsUnicode(false).HasMaxLength(4000);
            Property(x => x.PlanningDesignStartYear).HasColumnName(@"PlanningDesignStartYear").HasColumnType("int").IsOptional();
            Property(x => x.ProjectLocationSimpleTypeID).HasColumnName(@"ProjectLocationSimpleTypeID").HasColumnType("int").IsRequired();
            Property(x => x.EstimatedAnnualOperatingCostDeprecated).HasColumnName(@"EstimatedAnnualOperatingCostDeprecated").HasColumnType("money").IsOptional().HasPrecision(19,4);
            Property(x => x.FundingTypeID).HasColumnName(@"FundingTypeID").HasColumnType("int").IsOptional();
            Property(x => x.PrimaryContactPersonID).HasColumnName(@"PrimaryContactPersonID").HasColumnType("int").IsOptional();
            Property(x => x.ProjectApprovalStatusID).HasColumnName(@"ProjectApprovalStatusID").HasColumnType("int").IsRequired();
            Property(x => x.ProposingPersonID).HasColumnName(@"ProposingPersonID").HasColumnType("int").IsOptional();
            Property(x => x.ProposingDate).HasColumnName(@"ProposingDate").HasColumnType("datetime").IsOptional();
            Property(x => x.PerformanceMeasureNotes).HasColumnName(@"PerformanceMeasureNotes").HasColumnType("varchar").IsOptional().IsUnicode(false).HasMaxLength(500);
            Property(x => x.SubmissionDate).HasColumnName(@"SubmissionDate").HasColumnType("datetime").IsOptional();
            Property(x => x.ApprovalDate).HasColumnName(@"ApprovalDate").HasColumnType("datetime").IsOptional();
            Property(x => x.ReviewedByPersonID).HasColumnName(@"ReviewedByPersonID").HasColumnType("int").IsOptional();
            Property(x => x.DefaultBoundingBox).HasColumnName(@"DefaultBoundingBox").HasColumnType("geometry").IsOptional();
            Property(x => x.ExpendituresNote).HasColumnName(@"ExpendituresNote").HasColumnType("varchar").IsOptional();
            Property(x => x.ExpectedFundingUpdateNote).HasColumnName(@"ExpectedFundingUpdateNote").HasColumnType("varchar").IsOptional().IsUnicode(false).HasMaxLength(500);
            Property(x => x.LastUpdatedDate).HasColumnName(@"LastUpdatedDate").HasColumnType("datetime").IsRequired();
            Property(x => x.ProjectCategoryID).HasColumnName(@"ProjectCategoryID").HasColumnType("int").IsRequired();
            Property(x => x.BasicsComment).HasColumnName(@"BasicsComment").HasColumnType("varchar").IsOptional().IsUnicode(false).HasMaxLength(1000);
            Property(x => x.CustomAttributesComment).HasColumnName(@"CustomAttributesComment").HasColumnType("varchar").IsOptional().IsUnicode(false).HasMaxLength(1000);
            Property(x => x.LocationSimpleComment).HasColumnName(@"LocationSimpleComment").HasColumnType("varchar").IsOptional().IsUnicode(false).HasMaxLength(1000);
            Property(x => x.LocationDetailedComment).HasColumnName(@"LocationDetailedComment").HasColumnType("varchar").IsOptional().IsUnicode(false).HasMaxLength(1000);
            Property(x => x.OrganizationsComment).HasColumnName(@"OrganizationsComment").HasColumnType("varchar").IsOptional().IsUnicode(false).HasMaxLength(1000);
            Property(x => x.ContactsComment).HasColumnName(@"ContactsComment").HasColumnType("varchar").IsOptional().IsUnicode(false).HasMaxLength(1000);
            Property(x => x.ExpectedAccomplishmentsComment).HasColumnName(@"ExpectedAccomplishmentsComment").HasColumnType("varchar").IsOptional().IsUnicode(false).HasMaxLength(1000);
            Property(x => x.ReportedAccomplishmentsComment).HasColumnName(@"ReportedAccomplishmentsComment").HasColumnType("varchar").IsOptional().IsUnicode(false).HasMaxLength(1000);
            Property(x => x.BudgetComment).HasColumnName(@"BudgetComment").HasColumnType("varchar").IsOptional().IsUnicode(false).HasMaxLength(1000);
            Property(x => x.ExpendituresComment).HasColumnName(@"ExpendituresComment").HasColumnType("varchar").IsOptional().IsUnicode(false).HasMaxLength(1000);
            Property(x => x.ProposalClassificationsComment).HasColumnName(@"ProposalClassificationsComment").HasColumnType("varchar").IsOptional().IsUnicode(false).HasMaxLength(1000);
            Property(x => x.AttachmentsNotesComment).HasColumnName(@"AttachmentsNotesComment").HasColumnType("varchar").IsOptional().IsUnicode(false).HasMaxLength(1000);
            Property(x => x.PhotosComment).HasColumnName(@"PhotosComment").HasColumnType("varchar").IsOptional().IsUnicode(false).HasMaxLength(1000);
            Property(x => x.SubmittedByPersonID).HasColumnName(@"SubmittedByPersonID").HasColumnType("int").IsOptional();
            Property(x => x.LocationIsPrivate).HasColumnName(@"LocationIsPrivate").HasColumnType("bit").IsRequired();
            Property(x => x.SolicitationID).HasColumnName(@"SolicitationID").HasColumnType("int").IsOptional();
            Property(x => x.OtherPartners).HasColumnName(@"OtherPartners").HasColumnType("varchar").IsOptional().IsUnicode(false).HasMaxLength(500);
            Property(x => x.ExternalLinksComment).HasColumnName(@"ExternalLinksComment").HasColumnType("varchar").IsOptional().IsUnicode(false).HasMaxLength(1000);
            Property(x => x.ExternalID).HasColumnName(@"ExternalID").HasColumnType("int").IsOptional();
            Property(x => x.PrimaryContactPersonFullName).HasColumnName(@"PrimaryContactPersonFullName").HasColumnType("varchar").IsOptional().IsUnicode(false).HasMaxLength(201);

            // Foreign keys
            HasRequired(a => a.TaxonomyLeaf).WithMany(b => b.Projects).HasForeignKey(c => c.TaxonomyLeafID).WillCascadeOnDelete(false); // FK_Project_TaxonomyLeaf_TaxonomyLeafID
            HasOptional(a => a.PrimaryContactPerson).WithMany(b => b.ProjectsWhereYouAreThePrimaryContactPerson).HasForeignKey(c => c.PrimaryContactPersonID).WillCascadeOnDelete(false); // FK_Project_Person_PrimaryContactPersonID_PersonID
            HasOptional(a => a.ProposingPerson).WithMany(b => b.ProjectsWhereYouAreTheProposingPerson).HasForeignKey(c => c.ProposingPersonID).WillCascadeOnDelete(false); // FK_Project_Person_ProposingPersonID_PersonID
            HasOptional(a => a.ReviewedByPerson).WithMany(b => b.ProjectsWhereYouAreTheReviewedByPerson).HasForeignKey(c => c.ReviewedByPersonID).WillCascadeOnDelete(false); // FK_Project_Person_ReviewedByPersonID_PersonID
            HasOptional(a => a.SubmittedByPerson).WithMany(b => b.ProjectsWhereYouAreTheSubmittedByPerson).HasForeignKey(c => c.SubmittedByPersonID).WillCascadeOnDelete(false); // FK_Project_Person_SubmittedByPersonID_PersonID
            HasOptional(a => a.Solicitation).WithMany(b => b.Projects).HasForeignKey(c => c.SolicitationID).WillCascadeOnDelete(false); // FK_Project_Solicitation_SolicitationID
        }
    }
}