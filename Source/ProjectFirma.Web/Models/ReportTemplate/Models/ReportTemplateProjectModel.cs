using System.Collections.Generic;
using System.Linq;
using ProjectFirmaModels.Models;
using LtInfo.Common;

namespace ProjectFirma.Web.Models.ReportTemplate.Models
{
    public class ReportTemplateProjectModel : ReportTemplateBaseModel
    {

        public string ProjectName { get; set; }
        public string ProjectDescription { get; set; }
        public string ApprovalDate { get; set; }
        public string SubmissionDate { get; set; }
        public string CompletionYear { get; set; }
        public string ImplementationStartYear { get; set; }
        public string ProjectStatusColor { get; set; }
        public string ProjectStatusName { get; set; }
        public string ProjectStage { get; set; }
        public string EstimatedTotalCost { get; set; }

        private List<ProjectContact> ProjectContacts { get; set; }
        private List<ProjectOrganization> ProjectOrganizations { get; set; }

        public ReportTemplateProjectModel(Project project)
        {
            ProjectName = project.ProjectName;
            ProjectDescription = project.ProjectDescription;
            ApprovalDate = project.ApprovalDate.ToString();
            SubmissionDate = project.SubmissionDate.ToString();
            CompletionYear = project.CompletionYear.ToString();
            ImplementationStartYear = project.ImplementationStartYear.ToString();

            var projectStatus = project.GetCurrentProjectStatus();
            if (projectStatus != null)
            {
                ProjectStatusColor = projectStatus.ProjectStatusColor;
                ProjectStatusName = projectStatus.ProjectStatusDisplayName;
            }

            ProjectContacts = project.ProjectContacts.ToList();
            ProjectOrganizations = project.ProjectOrganizations.ToList();

            ProjectStage = project.ProjectStage.ProjectStageDisplayName;

            EstimatedTotalCost = project.GetEstimatedTotalRegardlessOfFundingType().ToStringCurrency();

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