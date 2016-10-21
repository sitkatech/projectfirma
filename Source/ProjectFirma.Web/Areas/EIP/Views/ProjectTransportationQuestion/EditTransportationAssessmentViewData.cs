using System.Collections.Generic;
using ProjectFirma.Web.Areas.EIP.Views.Project;
using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.Areas.EIP.Views.ProjectTransportationQuestion
{
    public class EditTransportationAssessmentViewData : ProjectViewData
    {
        public readonly List<TransportationGoal> TransportationGoals;
        public readonly string ProjectName;
        
        public EditTransportationAssessmentViewData(Person currentPerson, Models.Project project, List<TransportationGoal> transportationGoals)
            : base(currentPerson, project)
        {
            ProjectName = project.DisplayName;
            TransportationGoals = transportationGoals;
        }
    }
}