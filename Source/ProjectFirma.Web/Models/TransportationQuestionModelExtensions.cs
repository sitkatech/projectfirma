using System.Collections.Generic;
using System.Linq;
using LtInfo.Common;
using LtInfo.Common.Views;

namespace ProjectFirma.Web.Models
{
    public static class TransportationQuestionModelExtensions
    {
        public static FancyTreeNode ToFancyTreeNode(this TransportationQuestion transportationQuestion, List<ITransportationQuestionAnswer> projectTransportationQuestions)
        {
            var projectTransportationQuestion = projectTransportationQuestions != null && projectTransportationQuestions.Any()
                ? projectTransportationQuestions.SingleOrDefault(x => x.TransportationQuestionID == transportationQuestion.TransportationQuestionID)
                : null;
            var answer = projectTransportationQuestion != null ? projectTransportationQuestion.Answer : null;
            var fancyTreeNode = new FancyTreeNode(transportationQuestion.TransportationQuestionText, transportationQuestion.TransportationQuestionID.ToString(), false)
            {
                Answer = answer.HasValue ? answer.ToYesNo() : ViewUtilities.NoAnswerProvided
            };
            return fancyTreeNode;
        }
    }
}