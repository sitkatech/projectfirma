using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.Areas.EIP.Views.Project
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