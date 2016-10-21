using ProjectFirma.Web.Views;

namespace ProjectFirma.Web.Areas.EIP.Views.Shared.ProjectControls
{
    public class ProjectTaxonomyViewData : LakeTahoeInfoUserControlViewData
    {
        public readonly Models.FocusArea FocusArea;
        public readonly Models.Program Program;
        public readonly Models.ActionPriority ActionPriority;
        public readonly Models.Project Project;

        public readonly bool IsProject;
        public readonly bool IsActionPriority;
        public readonly bool IsProgram;
        public readonly bool IsFocusArea;

        public ProjectTaxonomyViewData(Models.FocusArea focusArea) : this(focusArea, null, null, null)
        {
        }

        public ProjectTaxonomyViewData(Models.Program program) : this(program.FocusArea, program, null, null)
        {
        }

        public ProjectTaxonomyViewData(Models.ActionPriority actionPriority) : this(actionPriority.Program.FocusArea, actionPriority.Program, actionPriority, null)
        {
        }

        public ProjectTaxonomyViewData(Models.Project project) : this(project.ActionPriority.Program.FocusArea, project.ActionPriority.Program, project.ActionPriority, project)
        {
        }

        private ProjectTaxonomyViewData(Models.FocusArea focusArea, Models.Program program, Models.ActionPriority actionPriority, Models.Project project)
        {
            FocusArea = focusArea;
            Program = program;
            ActionPriority = actionPriority;
            Project = project;
            IsProject = Project != null;
            IsActionPriority = ActionPriority != null && !IsProject;
            IsProgram = Program != null && !IsActionPriority && !IsProject;
            IsFocusArea = FocusArea != null && !IsProgram && !IsActionPriority && !IsProject;
        }
    }
}