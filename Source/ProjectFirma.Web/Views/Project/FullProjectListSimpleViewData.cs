using System.Collections.Generic;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Views.Shared;

namespace ProjectFirma.Web.Views.Project
{
    public class FullProjectListSimpleViewData : FirmaViewData
    {
        public readonly List<Models.Project> Projects; 

        public FullProjectListSimpleViewData(Person currentPerson, Models.FirmaPage firmaPage, List<Models.Project> projects)
            : base(currentPerson, firmaPage)
        {
            Projects = projects;
            PageTitle = "Full Project List (Simple)";
        }
    }
}