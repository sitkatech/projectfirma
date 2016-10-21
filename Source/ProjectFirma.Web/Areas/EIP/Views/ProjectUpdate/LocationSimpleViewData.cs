using System.Collections.Generic;
using ProjectFirma.Web.Areas.EIP.Controllers;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Areas.EIP.Views.Shared.ProjectLocationControls;
using LtInfo.Common;

namespace ProjectFirma.Web.Areas.EIP.Views.ProjectUpdate
{
    public class LocationSimpleViewData : ProjectUpdateViewData
    {
        public readonly EditProjectLocationSimpleViewData EditProjectLocationSimpleViewData;
        public readonly ProjectLocationSummaryViewData ProjectLocationSummaryViewData;
        public readonly string RefreshUrl;
        public readonly SectionCommentsViewData SectionCommentsViewData;
        public readonly ViewDataForAngularClass ViewDataForAngular;

        public LocationSimpleViewData(Person currentPerson,
            Models.ProjectUpdate projectUpdate,
            EditProjectLocationSimpleViewData editProjectLocationSimpleViewData,
            ProjectLocationSummaryViewData projectLocationSummaryViewData, ViewDataForAngularClass viewDataForAngularClass, UpdateStatus updateStatus) : base(currentPerson, projectUpdate.ProjectUpdateBatch, ProjectUpdateSectionEnum.LocationSimple, updateStatus)
        {
            EditProjectLocationSimpleViewData = editProjectLocationSimpleViewData;
            ProjectLocationSummaryViewData = projectLocationSummaryViewData;
            RefreshUrl = SitkaRoute<ProjectUpdateController>.BuildUrlFromExpression(x => x.RefreshProjectLocationSimple(projectUpdate.ProjectUpdateBatch.Project));
            SectionCommentsViewData = new SectionCommentsViewData(projectUpdate.ProjectUpdateBatch.LocationSimpleComment, projectUpdate.ProjectUpdateBatch.IsReturned);
            ViewDataForAngular = viewDataForAngularClass;
        }

        public class ViewDataForAngularClass
        {
            public readonly List<string> ValidationWarnings;

            public ViewDataForAngularClass(List<string> validationWarnings)
            {
                ValidationWarnings = validationWarnings;
            }
        }
    }
}