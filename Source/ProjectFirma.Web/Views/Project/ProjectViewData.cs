using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.Views.Project
{
    public abstract class ProjectViewData : FirmaViewData
    {
        public readonly Models.Project Project;
        public readonly ProjectUpdateState LatestUpdateState;

        protected ProjectViewData(Person currentPerson, Models.Project project) : this(currentPerson, project, false)
        {
        }        

        protected ProjectViewData(Person currentPerson, Models.Project project, bool useFluidContainer) : base(currentPerson, null, useFluidContainer)
        {
            Project = project;
            HtmlPageTitle = project.ProjectName;
            EntityName = "Project";
            LatestUpdateState = project.GetLatestUpdateState();
        }        
    }
}