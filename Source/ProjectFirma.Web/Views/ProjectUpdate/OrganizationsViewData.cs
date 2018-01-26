using System.Collections.Generic;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.Views.ProjectUpdate
{
    public class OrganizationsViewData : ProjectUpdateViewData
    {
        public readonly string RefreshUrl;
        public readonly string DiffUrl;

        public OrganizationsViewData(Person currentPerson, ProjectUpdateBatch projectUpdateBatch,
            ProjectUpdateSection currentSection, UpdateStatus updateStatus, List<string> validationWarnings) : base(
            currentPerson, projectUpdateBatch, currentSection, updateStatus, validationWarnings)
        {
            SectionCommentsViewData =
                new SectionCommentsViewData(projectUpdateBatch.OrganizationsComment, projectUpdateBatch.IsReturned);
            RefreshUrl = SitkaRoute<ProjectUpdateController>.BuildUrlFromExpression(x => x.RefreshOrganizations(projectUpdateBatch.Project));
            DiffUrl = SitkaRoute<ProjectUpdateController>.BuildUrlFromExpression(x => x.DiffOrganizations(projectUpdateBatch.Project));
        }

        public readonly SectionCommentsViewData SectionCommentsViewData;
    }
}