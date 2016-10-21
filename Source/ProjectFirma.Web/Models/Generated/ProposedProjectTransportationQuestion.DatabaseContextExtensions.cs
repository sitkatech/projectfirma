//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProposedProjectTransportationQuestion]
using System.Collections.Generic;
using System.Linq;
using EntityFramework.Extensions;
using ProjectFirma.Web.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static ProposedProjectTransportationQuestion GetProposedProjectTransportationQuestion(this IQueryable<ProposedProjectTransportationQuestion> proposedProjectTransportationQuestions, int proposedProjectTransportationQuestionID)
        {
            var proposedProjectTransportationQuestion = proposedProjectTransportationQuestions.SingleOrDefault(x => x.ProposedProjectTransportationQuestionID == proposedProjectTransportationQuestionID);
            Check.RequireNotNullThrowNotFound(proposedProjectTransportationQuestion, "ProposedProjectTransportationQuestion", proposedProjectTransportationQuestionID);
            return proposedProjectTransportationQuestion;
        }

        public static void DeleteProposedProjectTransportationQuestion(this IQueryable<ProposedProjectTransportationQuestion> proposedProjectTransportationQuestions, List<int> proposedProjectTransportationQuestionIDList)
        {
            if(proposedProjectTransportationQuestionIDList.Any())
            {
                proposedProjectTransportationQuestions.Where(x => proposedProjectTransportationQuestionIDList.Contains(x.ProposedProjectTransportationQuestionID)).Delete();
            }
        }

        public static void DeleteProposedProjectTransportationQuestion(this IQueryable<ProposedProjectTransportationQuestion> proposedProjectTransportationQuestions, ICollection<ProposedProjectTransportationQuestion> proposedProjectTransportationQuestionsToDelete)
        {
            if(proposedProjectTransportationQuestionsToDelete.Any())
            {
                var proposedProjectTransportationQuestionIDList = proposedProjectTransportationQuestionsToDelete.Select(x => x.ProposedProjectTransportationQuestionID).ToList();
                proposedProjectTransportationQuestions.Where(x => proposedProjectTransportationQuestionIDList.Contains(x.ProposedProjectTransportationQuestionID)).Delete();
            }
        }

        public static void DeleteProposedProjectTransportationQuestion(this IQueryable<ProposedProjectTransportationQuestion> proposedProjectTransportationQuestions, int proposedProjectTransportationQuestionID)
        {
            DeleteProposedProjectTransportationQuestion(proposedProjectTransportationQuestions, new List<int> { proposedProjectTransportationQuestionID });
        }

        public static void DeleteProposedProjectTransportationQuestion(this IQueryable<ProposedProjectTransportationQuestion> proposedProjectTransportationQuestions, ProposedProjectTransportationQuestion proposedProjectTransportationQuestionToDelete)
        {
            DeleteProposedProjectTransportationQuestion(proposedProjectTransportationQuestions, new List<ProposedProjectTransportationQuestion> { proposedProjectTransportationQuestionToDelete });
        }
    }
}