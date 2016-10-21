using System.Collections.Generic;
using System.Linq;
using ProjectFirma.Web.Models;
using LtInfo.Common;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Areas.EIP.Views.ProjectWatershed
{
    public class EditProjectWatershedsViewModel : FormViewModel
    {
        public List<ProjectWatershedSimple> ProjectWatersheds { get; set; }

        /// <summary>
        /// Needed by the ModelBinder
        /// </summary>
        public EditProjectWatershedsViewModel()
        {
        }

        public EditProjectWatershedsViewModel(List<ProjectWatershedSimple> projectWatersheds)
        {
            ProjectWatersheds = projectWatersheds;
        }

        public void UpdateModel(List<Models.ProjectWatershed> currentProjectWatersheds, IList<Models.ProjectWatershed> allProjectWatersheds)
        {
            var projectWatershedsUpdated = new List<Models.ProjectWatershed>();
            if (ProjectWatersheds != null)
            {
                // Completely rebuild the list
                projectWatershedsUpdated = ProjectWatersheds.Select(x => new Models.ProjectWatershed(x.ProjectID, x.WatershedID)).ToList();
            }
            currentProjectWatersheds.Merge(projectWatershedsUpdated, allProjectWatersheds, (x, y) => x.ProjectID == y.ProjectID && x.WatershedID == y.WatershedID);
        }
    }
}