using System.Collections.Generic;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Views.Shared;

namespace ProjectFirma.Web.Views.Project
{
    public class FullProjectListSimpleViewData : EIPViewData
    {
        public readonly List<Models.Project> Projects; 

        public FullProjectListSimpleViewData(Person currentPerson, Models.ProjectFirmaPage projectFirmaPage, List<Models.Project> projects)
            : base(currentPerson, projectFirmaPage)
        {
            Projects = projects;
            PageTitle = "Full Project List (Simple)";
        }
    }
}