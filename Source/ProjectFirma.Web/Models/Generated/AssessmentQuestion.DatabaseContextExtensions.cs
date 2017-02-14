//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[AssessmentQuestion]
using System.Collections.Generic;
using System.Linq;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static AssessmentQuestion GetAssessmentQuestion(this IQueryable<AssessmentQuestion> assessmentQuestions, int assessmentQuestionID)
        {
            var assessmentQuestion = assessmentQuestions.SingleOrDefault(x => x.AssessmentQuestionID == assessmentQuestionID);
            Check.RequireNotNullThrowNotFound(assessmentQuestion, "AssessmentQuestion", assessmentQuestionID);
            return assessmentQuestion;
        }

        public static void DeleteAssessmentQuestion(this List<int> assessmentQuestionIDList)
        {
            if(assessmentQuestionIDList.Any())
            {
                HttpRequestStorage.DatabaseEntities.AllAssessmentQuestions.RemoveRange(HttpRequestStorage.DatabaseEntities.AssessmentQuestions.Where(x => assessmentQuestionIDList.Contains(x.AssessmentQuestionID)));
            }
        }

        public static void DeleteAssessmentQuestion(this ICollection<AssessmentQuestion> assessmentQuestionsToDelete)
        {
            if(assessmentQuestionsToDelete.Any())
            {
                HttpRequestStorage.DatabaseEntities.AllAssessmentQuestions.RemoveRange(assessmentQuestionsToDelete);
            }
        }

        public static void DeleteAssessmentQuestion(this int assessmentQuestionID)
        {
            DeleteAssessmentQuestion(new List<int> { assessmentQuestionID });
        }

        public static void DeleteAssessmentQuestion(this AssessmentQuestion assessmentQuestionToDelete)
        {
            DeleteAssessmentQuestion(new List<AssessmentQuestion> { assessmentQuestionToDelete });
        }
    }
}