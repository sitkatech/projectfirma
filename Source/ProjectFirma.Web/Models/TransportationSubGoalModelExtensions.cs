using System.Collections.Generic;
using System.Linq;

namespace ProjectFirma.Web.Models
{
    public static class TransportationSubGoalModelExtensions
    {
        public static FancyTreeNode ToFancyTreeNode(this TransportationSubGoal transportationSubGoal, List<ITransportationQuestionAnswer> projectTransportationQuestionsDict)
        {
            var fancyTreeNode = new FancyTreeNode(transportationSubGoal.DisplayName, transportationSubGoal.TransportationSubGoalID.ToString(), false)
            {
                Children = transportationSubGoal.ActiveQuestions.Select(x => x.ToFancyTreeNode(projectTransportationQuestionsDict)).ToList()
            };
            return fancyTreeNode;
        }
    }
}