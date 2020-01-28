using System;
using System.Collections.Generic;
using System.Linq;
using ProjectFirmaModels.Models;
using LtInfo.Common;

namespace ProjectFirma.Web.Models.ReportTemplate.Models
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
            PrimaryContactOrganization = new ReportTemplateOrganizationModel(Project.GetPrimaryContactOrganization());
            
            ProjectStage = Project.ProjectStage.ProjectStageDisplayName;
            NumberOfReportedPerformanceMeasures = Project.PerformanceMeasureActuals.Count;
            ProjectPrimaryContact = new ReportTemplatePersonModel(Project.GetPrimaryContact());
            PlanningDesignStartYear = ProjectModelExtensions.GetPlanningDesignStartYear(Project);
            ImplementationStartYear = ProjectModelExtensions.GetImplementationStartYear(Project);
            CompletionYear = ProjectModelExtensions.GetCompletionYear(Project);
            PrimaryTaxonomyLeaf = Project.TaxonomyLeaf.GetDisplayName();
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

        public List<ReportTemplatePersonModel> GetContacts()
        {
            return ProjectContacts.Select(x => new ReportTemplatePersonModel(x.Contact)).ToList();
        }

        public List<ReportTemplatePersonModel> GetContactsByType(string contactTypeName)
        {
            var projectContactsInType = ProjectContacts.Where(x => x.ContactRelationshipType.ContactRelationshipTypeName == contactTypeName).ToList();
            return projectContactsInType.Select(x => new ReportTemplatePersonModel(x.Contact)).ToList();
        }

        public List<ReportTemplateOrganizationModel> GetOrganizations()
        {
            return ProjectOrganizations.Select(x => new ReportTemplateOrganizationModel(x.Organization)).ToList();
        }

        public List<ReportTemplateOrganizationModel> GetOrganizationsByType(string organizationTypeName)
        {
            var organizationsInType = ProjectOrganizations.Where(x => x.OrganizationRelationshipType.OrganizationRelationshipTypeName == organizationTypeName).ToList();
            return organizationsInType.Select(x => new ReportTemplateOrganizationModel(x.Organization)).ToList();
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