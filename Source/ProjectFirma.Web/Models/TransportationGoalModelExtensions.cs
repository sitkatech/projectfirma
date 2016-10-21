using System.Collections.Generic;
using System.Linq;

namespace ProjectFirma.Web.Models
{
    public static class TransportationGoalModelExtensions
    {
        public static FancyTreeNode ToFancyTreeNode(this TransportationGoal transportationGoal, List<ITransportationQuestionAnswer> projectTransportationQuestionsDict)
        {
            var fancyTreeNode = new FancyTreeNode(transportationGoal.DisplayName, transportationGoal.TransportationGoalID.ToString(), false)
            {
                Children = transportationGoal.TransportationSubGoals.Select(x => x.ToFancyTreeNode(projectTransportationQuestionsDict)).ToList(),
            };
            return fancyTreeNode;
        }
    }
}