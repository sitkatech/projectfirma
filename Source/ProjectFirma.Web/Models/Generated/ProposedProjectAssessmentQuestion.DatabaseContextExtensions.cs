//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProposedProjectAssessmentQuestion]
using System.Collections.Generic;
using System.Linq;
using Z.EntityFramework.Plus;
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

        public static void DeleteProposedProjectAssessmentQuestion(this IQueryable<ProposedProjectAssessmentQuestion> proposedProjectAssessmentQuestions, List<int> proposedProjectAssessmentQuestionIDList)
        {
            if(proposedProjectAssessmentQuestionIDList.Any())
            {
                proposedProjectAssessmentQuestions.Where(x => proposedProjectAssessmentQuestionIDList.Contains(x.ProposedProjectAssessmentQuestionID)).Delete();
            }
        }

        public static void DeleteProposedProjectAssessmentQuestion(this IQueryable<ProposedProjectAssessmentQuestion> proposedProjectAssessmentQuestions, ICollection<ProposedProjectAssessmentQuestion> proposedProjectAssessmentQuestionsToDelete)
        {
            if(proposedProjectAssessmentQuestionsToDelete.Any())
            {
                var proposedProjectAssessmentQuestionIDList = proposedProjectAssessmentQuestionsToDelete.Select(x => x.ProposedProjectAssessmentQuestionID).ToList();
                proposedProjectAssessmentQuestions.Where(x => proposedProjectAssessmentQuestionIDList.Contains(x.ProposedProjectAssessmentQuestionID)).Delete();
            }
        }

        public static void DeleteProposedProjectAssessmentQuestion(this IQueryable<ProposedProjectAssessmentQuestion> proposedProjectAssessmentQuestions, int proposedProjectAssessmentQuestionID)
        {
            DeleteProposedProjectAssessmentQuestion(proposedProjectAssessmentQuestions, new List<int> { proposedProjectAssessmentQuestionID });
        }

        public static void DeleteProposedProjectAssessmentQuestion(this IQueryable<ProposedProjectAssessmentQuestion> proposedProjectAssessmentQuestions, ProposedProjectAssessmentQuestion proposedProjectAssessmentQuestionToDelete)
        {
            DeleteProposedProjectAssessmentQuestion(proposedProjectAssessmentQuestions, new List<ProposedProjectAssessmentQuestion> { proposedProjectAssessmentQuestionToDelete });
        }
    }
}