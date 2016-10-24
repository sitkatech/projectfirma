using LtInfo.Common.Mvc;

namespace ProjectFirma.Web.Views.Shared.ProjectControls
{
    public abstract class EditProject : TypedWebPartialViewPage<EditProjectViewData, EditProjectViewModel>
    {
    }

    public abstract class EditProjectType
    {
        public readonly string IntroductoryText;

        internal EditProjectType(string introductoryText)
        {
            IntroductoryText = introductoryText;
        }

        public static readonly EditProjectTypeNewProject NewProject = EditProjectTypeNewProject.Instance;
        public static readonly EditProjectTypeExistingProject ExistingProject = EditProjectTypeExistingProject.Instance;
        public static readonly EditProjectTypeProposedProject ProposedProject = EditProjectTypeProposedProject.Instance;
    }

    public class EditProjectTypeNewProject : EditProjectType
        {
        private EditProjectTypeNewProject(string introductoryText) : base(introductoryText) {  }
            public static readonly EditProjectTypeNewProject Instance = new EditProjectTypeNewProject("<p>Enter basic information about the project.</p>");
        }

    public class EditProjectTypeExistingProject : EditProjectType
        {
            private EditProjectTypeExistingProject(string introductoryText) : base(introductoryText) { }
            public static readonly EditProjectTypeExistingProject Instance = new EditProjectTypeExistingProject("<p>Update this project's information.</p>");
        }

    public class EditProjectTypeProposedProject : EditProjectType
    {
        private EditProjectTypeProposedProject(string introductoryText) : base(introductoryText) { }
        public static readonly EditProjectTypeProposedProject Instance = new EditProjectTypeProposedProject("<p>Enter additional information to approve this as a full-fledged project.</p>");
    }
}