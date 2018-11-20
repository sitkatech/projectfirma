using System.Collections.Generic;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Views.Shared.ProjectOrganization;

namespace ProjectFirma.Web.Views.ProjectUpdate
{
    public class OrganizationsViewData : ProjectUpdateViewData
    {
        public readonly string RefreshUrl;
        public readonly string DiffUrl;

        public OrganizationsViewData(Person currentPerson, ProjectUpdateBatch projectUpdateBatch, UpdateStatus updateStatus, EditOrganizationsViewData editOrganizationsViewData, OrganizationsValidationResult organizationsValidationResult, ProjectOrganizationsDetailViewData projectOrganizationsDetailViewData) : base(
            currentPerson, projectUpdateBatch, updateStatus, organizationsValidationResult.GetWarningMessages(), ProjectUpdateSection.Organizations.ProjectUpdateSectionDisplayName)
        {
            EditOrganizationsViewData = editOrganizationsViewData;
            ProjectOrganizationsDetailViewData = projectOrganizationsDetailViewData;
            SectionCommentsViewData =
                new SectionCommentsViewData(projectUpdateBatch.OrganizationsComment, projectUpdateBatch.IsReturned);
            RefreshUrl = SitkaRoute<ProjectUpdateController>.BuildUrlFromExpression(x => x.RefreshOrganizations(projectUpdateBatch.Project));
            DiffUrl = SitkaRoute<ProjectUpdateController>.BuildUrlFromExpression(x => x.DiffOrganizations(projectUpdateBatch.Project));
        }

        public readonly SectionCommentsViewData SectionCommentsViewData;
        public readonly EditOrganizationsViewData EditOrganizationsViewData;
        public readonly ProjectOrganizationsDetailViewData ProjectOrganizationsDetailViewData;
    }
}