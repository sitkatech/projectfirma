using System.Collections.Generic;
using ProjectFirma.Web.Views.Project;
using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.Views.ProjectAssessmentQuestion
{
    public class EditAssessmentViewData : ProjectViewData
    {
        public readonly List<AssessmentGoal> AssessmentGoals;
        public readonly string ProjectName;
        
        public EditAssessmentViewData(Person currentPerson, Models.Project project, List<AssessmentGoal> assessmentGoals)
            : base(currentPerson, project)
        {
            ProjectName = project.DisplayName;
            AssessmentGoals = assessmentGoals;
        }
    }
}