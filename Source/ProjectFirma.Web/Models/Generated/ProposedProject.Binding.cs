//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProposedProject]
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Data.Entity.Spatial;
using System.Linq;
using System.Web;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    [Table("[dbo].[ProposedProject]")]
    public partial class ProposedProject : IHavePrimaryKey, IHaveATenantID
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected ProposedProject()
        {
            this.NotificationProposedProjects = new HashSet<NotificationProposedProject>();
            this.PerformanceMeasureExpectedProposeds = new HashSet<PerformanceMeasureExpectedProposed>();
            this.ProposedProjectAssessmentQuestions = new HashSet<ProposedProjectAssessmentQuestion>();
            this.ProposedProjectClassifications = new HashSet<ProposedProjectClassification>();
            this.ProposedProjectImages = new HashSet<ProposedProjectImage>();
            this.ProposedProjectLocations = new HashSet<ProposedProjectLocation>();
            this.ProposedProjectLocationStagings = new HashSet<ProposedProjectLocationStaging>();
            this.ProposedProjectNotes = new HashSet<ProposedProjectNote>();
            this.TenantID = HttpRequestStorage.Tenant.TenantID;
        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public ProposedProject(int proposedProjectID, string projectName, string projectDescription, int leadImplementerOrganizationID, int proposingPersonID, DateTime proposingDate, int? implementationStartYear, int? completionYear, decimal? estimatedTotalCost, decimal? securedFunding, DbGeometry projectLocationPoint, string projectLocationNotes, int? planningDesignStartYear, int projectLocationSimpleTypeID, decimal? estimatedAnnualOperatingCost, int fundingTypeID, int proposedProjectStateID, int? taxonomyTierOneID, string performanceMeasureNotes, int? projectID, DateTime? submissionDate, DateTime? approvalDate, int? reviewedByPersonID, int? primaryContactPersonID) : this()
        {
            this.ProposedProjectID = proposedProjectID;
            this.ProjectName = projectName;
            this.ProjectDescription = projectDescription;
            this.LeadImplementerOrganizationID = leadImplementerOrganizationID;
            this.ProposingPersonID = proposingPersonID;
            this.ProposingDate = proposingDate;
            this.ImplementationStartYear = implementationStartYear;
            this.CompletionYear = completionYear;
            this.EstimatedTotalCost = estimatedTotalCost;
            this.SecuredFunding = securedFunding;
            this.ProjectLocationPoint = projectLocationPoint;
            this.ProjectLocationNotes = projectLocationNotes;
            this.PlanningDesignStartYear = planningDesignStartYear;
            this.ProjectLocationSimpleTypeID = projectLocationSimpleTypeID;
            this.EstimatedAnnualOperatingCost = estimatedAnnualOperatingCost;
            this.FundingTypeID = fundingTypeID;
            this.ProposedProjectStateID = proposedProjectStateID;
            this.TaxonomyTierOneID = taxonomyTierOneID;
            this.PerformanceMeasureNotes = performanceMeasureNotes;
            this.ProjectID = projectID;
            this.SubmissionDate = submissionDate;
            this.ApprovalDate = approvalDate;
            this.ReviewedByPersonID = reviewedByPersonID;
            this.PrimaryContactPersonID = primaryContactPersonID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public ProposedProject(string projectName, string projectDescription, int leadImplementerOrganizationID, int proposingPersonID, DateTime proposingDate, int projectLocationSimpleTypeID, int fundingTypeID, int proposedProjectStateID) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.ProposedProjectID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.ProjectName = projectName;
            this.ProjectDescription = projectDescription;
            this.LeadImplementerOrganizationID = leadImplementerOrganizationID;
            this.ProposingPersonID = proposingPersonID;
            this.ProposingDate = proposingDate;
            this.ProjectLocationSimpleTypeID = projectLocationSimpleTypeID;
            this.FundingTypeID = fundingTypeID;
            this.ProposedProjectStateID = proposedProjectStateID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields, using objects whenever possible
        /// </summary>
        public ProposedProject(string projectName, string projectDescription, Organization leadImplementerOrganization, Person proposingPerson, DateTime proposingDate, ProjectLocationSimpleType projectLocationSimpleType, FundingType fundingType, ProposedProjectState proposedProjectState) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.ProposedProjectID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            this.ProjectName = projectName;
            this.ProjectDescription = projectDescription;
            this.LeadImplementerOrganizationID = leadImplementerOrganization.OrganizationID;
            this.LeadImplementerOrganization = leadImplementerOrganization;
            leadImplementerOrganization.ProposedProjectsWhereYouAreTheLeadImplementerOrganization.Add(this);
            this.ProposingPersonID = proposingPerson.PersonID;
            this.ProposingPerson = proposingPerson;
            proposingPerson.ProposedProjectsWhereYouAreTheProposingPerson.Add(this);
            this.ProposingDate = proposingDate;
            this.ProjectLocationSimpleTypeID = projectLocationSimpleType.ProjectLocationSimpleTypeID;
            this.FundingTypeID = fundingType.FundingTypeID;
            this.ProposedProjectStateID = proposedProjectState.ProposedProjectStateID;
        }

        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static ProposedProject CreateNewBlank(Organization leadImplementerOrganization, Person proposingPerson, ProjectLocationSimpleType projectLocationSimpleType, FundingType fundingType, ProposedProjectState proposedProjectState)
        {
            return new ProposedProject(default(string), default(string), leadImplementerOrganization, proposingPerson, default(DateTime), projectLocationSimpleType, fundingType, proposedProjectState);
        }

        /// <summary>
        /// Does this object have any dependent objects? (If it does have dependent objects, these would need to be deleted before this object could be deleted.)
        /// </summary>
        /// <returns></returns>
        public bool HasDependentObjects()
        {
            return NotificationProposedProjects.Any() || PerformanceMeasureExpectedProposeds.Any() || ProposedProjectAssessmentQuestions.Any() || ProposedProjectClassifications.Any() || ProposedProjectImages.Any() || ProposedProjectLocations.Any() || ProposedProjectLocationStagings.Any() || ProposedProjectNotes.Any();
        }

        /// <summary>
        /// Dependent type names of this entity
        /// </summary>
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(ProposedProject).Name, typeof(NotificationProposedProject).Name, typeof(PerformanceMeasureExpectedProposed).Name, typeof(ProposedProjectAssessmentQuestion).Name, typeof(ProposedProjectClassification).Name, typeof(ProposedProjectImage).Name, typeof(ProposedProjectLocation).Name, typeof(ProposedProjectLocationStaging).Name, typeof(ProposedProjectNote).Name};

        [Key]
        public int ProposedProjectID { get; set; }
        public int TenantID { get; private set; }
        public string ProjectName { get; set; }
        public string ProjectDescription { get; set; }
        public int LeadImplementerOrganizationID { get; set; }
        public int ProposingPersonID { get; set; }
        public DateTime ProposingDate { get; set; }
        public int? ImplementationStartYear { get; set; }
        public int? CompletionYear { get; set; }
        public decimal? EstimatedTotalCost { get; set; }
        public decimal? SecuredFunding { get; set; }
        public DbGeometry ProjectLocationPoint { get; set; }
        public string ProjectLocationNotes { get; set; }
        public int? PlanningDesignStartYear { get; set; }
        public int ProjectLocationSimpleTypeID { get; set; }
        public decimal? EstimatedAnnualOperatingCost { get; set; }
        public int FundingTypeID { get; set; }
        public int ProposedProjectStateID { get; set; }
        public int? TaxonomyTierOneID { get; set; }
        public string PerformanceMeasureNotes { get; set; }
        public int? ProjectID { get; set; }
        public DateTime? SubmissionDate { get; set; }
        public DateTime? ApprovalDate { get; set; }
        public int? ReviewedByPersonID { get; set; }
        public int? PrimaryContactPersonID { get; set; }
        public int PrimaryKey { get { return ProposedProjectID; } set { ProposedProjectID = value; } }

        public virtual ICollection<NotificationProposedProject> NotificationProposedProjects { get; set; }
        public virtual ICollection<PerformanceMeasureExpectedProposed> PerformanceMeasureExpectedProposeds { get; set; }
        public virtual ICollection<ProposedProjectAssessmentQuestion> ProposedProjectAssessmentQuestions { get; set; }
        public virtual ICollection<ProposedProjectClassification> ProposedProjectClassifications { get; set; }
        public virtual ICollection<ProposedProjectImage> ProposedProjectImages { get; set; }
        public virtual ICollection<ProposedProjectLocation> ProposedProjectLocations { get; set; }
        public virtual ICollection<ProposedProjectLocationStaging> ProposedProjectLocationStagings { get; set; }
        public virtual ICollection<ProposedProjectNote> ProposedProjectNotes { get; set; }
        public Tenant Tenant { get { return Tenant.AllLookupDictionary[TenantID]; } }
        public virtual Organization LeadImplementerOrganization { get; set; }
        public virtual Person PrimaryContactPerson { get; set; }
        public virtual Person ProposingPerson { get; set; }
        public virtual Person ReviewedByPerson { get; set; }
        public ProjectLocationSimpleType ProjectLocationSimpleType { get { return ProjectLocationSimpleType.AllLookupDictionary[ProjectLocationSimpleTypeID]; } }
        public FundingType FundingType { get { return FundingType.AllLookupDictionary[FundingTypeID]; } }
        public ProposedProjectState ProposedProjectState { get { return ProposedProjectState.AllLookupDictionary[ProposedProjectStateID]; } }
        public virtual TaxonomyTierOne TaxonomyTierOne { get; set; }
        public virtual Project Project { get; set; }

        public static class FieldLengths
        {
            public const int ProjectName = 140;
            public const int ProjectDescription = 4000;
            public const int ProjectLocationNotes = 4000;
            public const int PerformanceMeasureNotes = 500;
        }
    }
}