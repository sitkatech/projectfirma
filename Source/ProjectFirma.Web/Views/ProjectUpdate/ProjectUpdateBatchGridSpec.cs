using System;
using System.Collections.Generic;
using System.Web;
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Models;
using LtInfo.Common;
using LtInfo.Common.DhtmlWrappers;
using LtInfo.Common.ModalDialog;
using LtInfo.Common.Views;

namespace ProjectFirma.Web.Views.ProjectUpdate
{
    public class ProjectUpdateBatchGridSpec : GridSpec<ProjectUpdateBatch>
    {
        private DateTime _detailTrackingStartDate = new DateTime(2016, 3, 8);

        public ProjectUpdateBatchGridSpec()
        {
            Add("Date", x => x.LastUpdateDate, 120);
            Add("Project Update Status", x => x.ProjectUpdateState.ProjectUpdateStateDisplayName, 170, DhtmlxGridColumnFilterType.SelectFilterStrict);
            Add("Updated By", x => x.LastUpdatePerson.FullNameFirstLastAndOrg, 350, DhtmlxGridColumnFilterType.SelectFilterStrict);
            Add("Project Update Details",
                pub =>
                {
                    if (pub.ProjectUpdateState == ProjectUpdateState.Approved && pub.LastUpdateDate.IsDateOnOrAfter(_detailTrackingStartDate))
                    {
                        var url = SitkaRoute<ProjectUpdateController>.BuildUrlFromExpression(c => c.ProjectUpdateBatchDiff(pub));
                        return ModalDialogFormHelper.ModalDialogFormLink("diff-link-id",
                            "Show Details",
                            url,
                            "Project Update Change Log",
                            1000,
                            "hidden-save-button",
                            string.Empty,
                            "diff-close-button",
                            "Close",
                            new List<string>() {"gridButton"},
                            null,
                            null,
                            null,
                            new List<string>() {"btn-firma", "btn-xs"}, false);
                    }
                    else if (pub.ProjectUpdateState == ProjectUpdateState.Approved)
                    {
                        return new HtmlString("Only available for Updates submitted after " + _detailTrackingStartDate.ToShortDateString());
                    }
                    else
                    {
                        return new HtmlString("Not yet submitted");
                    }
                },
                270);
        }
    }
}