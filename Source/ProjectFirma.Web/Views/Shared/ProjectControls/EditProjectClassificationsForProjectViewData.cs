using System.Collections.Generic;
using ProjectFirma.Web.Views;

namespace ProjectFirma.Web.Views.Shared.ProjectControls
{
    public class EditProjectClassificationsForProjectViewData : FirmaUserControlViewData
    {
        public readonly List<Models.Classification> Classifications;
        public readonly string ProjectName;

        public EditProjectClassificationsForProjectViewData(Models.Project project, List<Models.Classification> classifications)
        {
            ProjectName = project.DisplayName;
            Classifications = classifications;
        }

        public EditProjectClassificationsForProjectViewData(Models.ProposedProject proposedProject, List<Models.Classification> classifications)
        {
            ProjectName = proposedProject.DisplayName;
            Classifications = classifications;
        }
    }
}