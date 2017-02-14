//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProposedProjectAssessmentQuestion]
using System.Collections.Generic;
using System.Linq;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static ProposedProjectAssessmentQuestion GetProposedProjectAssessmentQuestion(this IQueryable<ProposedProjectAssessmentQuestion> proposedProjectAssessmentQuestions, int proposedProjectAssessmentQuestionID)
        {
            var proposedProjectAssessmentQuestion = proposedProjectAssessmentQuestions.SingleOrDefault(x => x.ProposedProjectAssessmentQuestionID == proposedProjectAssessmentQuestionID);
            Check.RequireNotNullThrowNotFound(proposedProjectAssessmentQuestion, "ProposedProjectAssessmentQuestion", proposedProjectAssessmentQuestionID);
            return proposedProjectAssessmentQuestion;
        }

        public static void DeleteProposedProjectAssessmentQuestion(this List<int> proposedProjectAssessmentQuestionIDList)
        {
            if(proposedProjectAssessmentQuestionIDList.Any())
            {
                HttpRequestStorage.DatabaseEntities.AllProposedProjectAssessmentQuestions.RemoveRange(HttpRequestStorage.DatabaseEntities.ProposedProjectAssessmentQuestions.Where(x => proposedProjectAssessmentQuestionIDList.Contains(x.ProposedProjectAssessmentQuestionID)));
            }
        }

        public static void DeleteProposedProjectAssessmentQuestion(this ICollection<ProposedProjectAssessmentQuestion> proposedProjectAssessmentQuestionsToDelete)
        {
            if(proposedProjectAssessmentQuestionsToDelete.Any())
            {
                HttpRequestStorage.DatabaseEntities.AllProposedProjectAssessmentQuestions.RemoveRange(proposedProjectAssessmentQuestionsToDelete);
            }
        }

        public static void DeleteProposedProjectAssessmentQuestion(this int proposedProjectAssessmentQuestionID)
        {
            DeleteProposedProjectAssessmentQuestion(new List<int> { proposedProjectAssessmentQuestionID });
        }

        public static void DeleteProposedProjectAssessmentQuestion(this ProposedProjectAssessmentQuestion proposedProjectAssessmentQuestionToDelete)
        {
            DeleteProposedProjectAssessmentQuestion(new List<ProposedProjectAssessmentQuestion> { proposedProjectAssessmentQuestionToDelete });
        }
    }
}