using System.Collections.Generic;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Views;

namespace ProjectFirma.Web.Areas.EIP.Views.Project
{
    public class EditFeaturedProjectsViewData : LakeTahoeInfoUserControlViewData
    {
        public readonly List<ProjectSimple> AllProjects;

        public EditFeaturedProjectsViewData(List<ProjectSimple> allProjects)
        {
            AllProjects = allProjects;
        }
    }
}