//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[TransportationQuestion]
using System.Collections.Generic;
using System.Linq;
using EntityFramework.Extensions;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static TransportationQuestion GetTransportationQuestion(this IQueryable<TransportationQuestion> transportationQuestions, int transportationQuestionID)
        {
            var transportationQuestion = transportationQuestions.SingleOrDefault(x => x.TransportationQuestionID == transportationQuestionID);
            Check.RequireNotNullThrowNotFound(transportationQuestion, "TransportationQuestion", transportationQuestionID);
            return transportationQuestion;
        }

        public static void DeleteTransportationQuestion(this IQueryable<TransportationQuestion> transportationQuestions, List<int> transportationQuestionIDList)
        {
            if(transportationQuestionIDList.Any())
            {
                transportationQuestions.Where(x => transportationQuestionIDList.Contains(x.TransportationQuestionID)).Delete();
            }
        }

        public static void DeleteTransportationQuestion(this IQueryable<TransportationQuestion> transportationQuestions, ICollection<TransportationQuestion> transportationQuestionsToDelete)
        {
            if(transportationQuestionsToDelete.Any())
            {
                var transportationQuestionIDList = transportationQuestionsToDelete.Select(x => x.TransportationQuestionID).ToList();
                transportationQuestions.Where(x => transportationQuestionIDList.Contains(x.TransportationQuestionID)).Delete();
            }
        }

        public static void DeleteTransportationQuestion(this IQueryable<TransportationQuestion> transportationQuestions, int transportationQuestionID)
        {
            DeleteTransportationQuestion(transportationQuestions, new List<int> { transportationQuestionID });
        }

        public static void DeleteTransportationQuestion(this IQueryable<TransportationQuestion> transportationQuestions, TransportationQuestion transportationQuestionToDelete)
        {
            DeleteTransportationQuestion(transportationQuestions, new List<TransportationQuestion> { transportationQuestionToDelete });
        }
    }
}