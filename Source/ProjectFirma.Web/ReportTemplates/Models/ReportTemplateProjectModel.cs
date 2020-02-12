using System;
using System.Collections.Generic;
using System.Linq;
using LtInfo.Common;
using ProjectFirma.Web.Models;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.ReportTemplates.Models
{
    public class ReportTemplateProjectModel : ReportTemplateBaseModel
    {

        private Project Project { get; set; }
        private List<ProjectContact> ProjectContacts { get; set; }
        private List<ProjectOrganization> ProjectOrganizations { get; set; }


        public string ProjectName { get; set; }
        public string ProjectUrl { get; set; }
        public ReportTemplateOrganizationModel PrimaryContactOrganization { get; set; }
        public string ProjectStage { get; set; }
        public int NumberOfReportedPerformanceMeasures { get; set; }
        public ReportTemplatePersonModel ProjectPrimaryContact { get; set; }
        public string PlanningDesignStartYear { get; set; }
        public string ImplementationStartYear { get; set; }
        public string CompletionYear { get; set; }
        public string PrimaryTaxonomyLeaf { get; set; }
        public int NumberOfReportedExpenditures { get; set; }
        public string FundingType { get; set; }
        public string EstimatedTotalCost { get; set; }
        public string SecuredFunding { get; set; }
        public string TargetedFunding { get; set; }
        public string NoFundingSourceIdentified { get; set; }
        public string ProjectDescription { get; set; }
        public int ProjectID { get; set; }
        public DateTime ProjectLastUpdated { get; set; }
        public string ProjectStatus { get; set; }
        public string ProjectStatusColor { get; set; }
        public string FinalStatusUpdateStatus { get; set; }


        public ReportTemplateProjectModel(Project project)
        {
            // Private properties
            Project = project;
            ProjectContacts = project.ProjectContacts.ToList();
            ProjectOrganizations = project.ProjectOrganizations.ToList();

            // Public properties
            ProjectName = Project.ProjectName;
            ProjectUrl = Project.GetDetailUrl();
            PrimaryContactOrganization = Project.GetPrimaryContactOrganization() != null ? new ReportTemplateOrganizationModel(Project.GetPrimaryContactOrganization()) : null;
            
            ProjectStage = Project.ProjectStage.ProjectStageDisplayName;
            NumberOfReportedPerformanceMeasures = Project.PerformanceMeasureActuals.Count;
            ProjectPrimaryContact = Project.GetPrimaryContact() != null ? new ReportTemplatePersonModel(Project.GetPrimaryContact()) : null;
            PlanningDesignStartYear = ProjectModelExtensions.GetPlanningDesignStartYear(Project);
            ImplementationStartYear = ProjectModelExtensions.GetImplementationStartYear(Project);
            CompletionYear = ProjectModelExtensions.GetCompletionYear(Project);
            PrimaryTaxonomyLeaf = Project.TaxonomyLeaf?.GetDisplayName();
            NumberOfReportedExpenditures = Project.ProjectFundingSourceExpenditures.Count;
            FundingType = Project.FundingType.FundingTypeDisplayName;
            EstimatedTotalCost = Project.GetEstimatedTotalRegardlessOfFundingType().ToStringCurrency();
            SecuredFunding = Project.GetSecuredFunding().ToStringCurrency();
            TargetedFunding = Project.GetTargetedFunding().ToStringCurrency();
            NoFundingSourceIdentified = Project.GetNoFundingSourceIdentifiedAmount().ToStringCurrency();
            ProjectDescription = Project.ProjectDescription;
            ProjectID = Project.ProjectID;
            ProjectLastUpdated = Project.LastUpdatedDate;

            var projectStatus = project.GetCurrentProjectStatus();
            if (projectStatus != null)
            {
                ProjectStatusColor = projectStatus.ProjectStatusColor;
                ProjectStatus = projectStatus.ProjectStatusDisplayName;
            }

            var finalProjectStatus = Project.FinalStatusReportStatusDescription;
            if (finalProjectStatus != null)
            {
                FinalStatusUpdateStatus = finalProjectStatus;
            }
        }

        public List<ReportTemplateProjectContactModel> GetProjectContacts()
        {
            return ProjectContacts.Select(x => new ReportTemplateProjectContactModel(x)).ToList();
        }

        public List<ReportTemplateProjectContactModel> GetProjectContactsByType(string contactTypeName)
        {
            var projectContactsInType = ProjectContacts.Where(x => x.ContactRelationshipType.ContactRelationshipTypeName == contactTypeName).ToList();
            return projectContactsInType.Select(x => new ReportTemplateProjectContactModel(x)).ToList();
        }

        public List<ReportTemplateProjectOrganizationModel> GetProjectOrganizations()
        {
            return ProjectOrganizations.Select(x => new ReportTemplateProjectOrganizationModel(x)).ToList();
        }

        public List<ReportTemplateProjectOrganizationModel> GetProjectOrganizationsByType(string organizationTypeName)
        {
            var organizationsInType = ProjectOrganizations.Where(x => x.OrganizationRelationshipType.OrganizationRelationshipTypeName == organizationTypeName).ToList();
            return organizationsInType.Select(x => new ReportTemplateProjectOrganizationModel(x)).ToList();
        }

        public string GetProjectContactNamesByType(string contactTypeName)
        {
            var projectContactsInType = ProjectContacts.Where(x => x.ContactRelationshipType.ContactRelationshipTypeName == contactTypeName).ToList();
            var projectContactNames = projectContactsInType.Select(x => x.Contact.GetFullNameFirstLast()).ToList();
            return $"{string.Join(", ", projectContactNames)}";
        }

        public string GetProjectOrganizationNamesByType(string organizationTypeName)
        {
            var organizationsInType = ProjectOrganizations.Where(x => x.OrganizationRelationshipType.OrganizationRelationshipTypeName == organizationTypeName).ToList();
            var organizationNames = organizationsInType.Select(x => x.Organization.GetDisplayName()).ToList();
            return $"{string.Join(", ", organizationNames)}";
        }

    }
}