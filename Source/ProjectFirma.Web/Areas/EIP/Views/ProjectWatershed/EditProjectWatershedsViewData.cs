using System.Collections.Generic;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Views;

namespace ProjectFirma.Web.Areas.EIP.Views.ProjectWatershed
{
    public class EditProjectWatershedsViewData : LakeTahoeInfoUserControlViewData
    {
        public readonly List<WatershedSimple> AllWatersheds;
        public readonly int ProjectID;

        public EditProjectWatershedsViewData(Models.Project project, List<WatershedSimple> allWatersheds)
        {
            AllWatersheds = allWatersheds;
            ProjectID = project.ProjectID;
        }
    }
}