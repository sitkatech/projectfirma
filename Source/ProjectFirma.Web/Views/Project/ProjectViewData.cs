using ProjectFirma.Web.Models;
using ProjectFirma.Web.Views.Shared;

namespace ProjectFirma.Web.Views.Project
{
    public abstract class ProjectViewData : EIPViewData
    {
        public readonly Models.Project Project;
        public readonly ProjectUpdateState LatestUpdateState;

        protected ProjectViewData(Person currentPerson, Models.Project project) : base(currentPerson)
        {
            Project = project;
            HtmlPageTitle = project.ProjectName;
            EntityName = "Project";
            LatestUpdateState = project.GetLatestUpdateState();
        }        
    }
}