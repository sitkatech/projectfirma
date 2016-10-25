using System.Collections.Generic;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Views;

namespace ProjectFirma.Web.Views.Project
{
    public class EditFeaturedProjectsViewData : FirmaUserControlViewData
    {
        public readonly List<ProjectSimple> AllProjects;

        public EditFeaturedProjectsViewData(List<ProjectSimple> allProjects)
        {
            AllProjects = allProjects;
        }
    }
}