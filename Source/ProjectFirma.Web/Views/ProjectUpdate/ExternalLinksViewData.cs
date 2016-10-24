using ProjectFirma.Web.Models;
using ProjectFirma.Web.Views.Shared.TextControls;

namespace ProjectFirma.Web.Views.ProjectUpdate
{
    public class ExternalLinksViewData : ProjectUpdateViewData
    {
        public readonly EntityExternalLinksViewData EntityExternalLinksViewData;
        public readonly string RefreshUrl;
        public readonly string DiffUrl;
        public readonly ViewDataForAngularClass ViewDataForAngular;

        public ExternalLinksViewData(Person currentPerson, ProjectUpdateBatch projectUpdateBatch, UpdateStatus updateStatus, ViewDataForAngularClass viewDataForAngular, EntityExternalLinksViewData entityExternalLinksViewData, string refreshUrl, string diffUrl)
            : base(currentPerson, projectUpdateBatch, ProjectUpdateSectionEnum.ExternalLinks, updateStatus)
        {
            ViewDataForAngular = viewDataForAngular;
            EntityExternalLinksViewData = entityExternalLinksViewData;
            RefreshUrl = refreshUrl;
            DiffUrl = diffUrl;
        }

        public class ViewDataForAngularClass
        {
            public readonly int ProjectID;

            public ViewDataForAngularClass(int projectUpdateBatchID)
            {
                ProjectID = projectUpdateBatchID;
            }
        }
    }
}