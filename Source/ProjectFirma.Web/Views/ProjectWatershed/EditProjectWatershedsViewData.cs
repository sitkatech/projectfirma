using System.Collections.Generic;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Views;

namespace ProjectFirma.Web.Views.ProjectWatershed
{
    public class EditProjectWatershedsViewData : FirmaUserControlViewData
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