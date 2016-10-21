using System;
using System.Collections.Generic;
using ProjectFirma.Web.Areas.EIP.Controllers;
using ProjectFirma.Web.Views;
using LtInfo.Common;

namespace ProjectFirma.Web.Areas.EIP.Views.Tag
{
    public class BulkTagProjectsViewData : LakeTahoeInfoUserControlViewData
    {
        public readonly string FindTagUrl;
        public readonly List<string> ProjectDisplayNames;
        public readonly string ProjectLabel;

        public BulkTagProjectsViewData(List<string> projectDisplayNames)
        {
            ProjectDisplayNames = projectDisplayNames;
            FindTagUrl = SitkaRoute<TagController>.BuildUrlFromExpression(c => c.Find(null));

            ProjectLabel = "Project" + (ProjectDisplayNames.Count > 1 ? "s" : String.Empty);

        }
    }
}