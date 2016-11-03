//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[AssessmentQuestion]
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
        public static AssessmentQuestion GetAssessmentQuestion(this IQueryable<AssessmentQuestion> assessmentQuestions, int assessmentQuestionID)
        {
            var assessmentQuestion = assessmentQuestions.SingleOrDefault(x => x.AssessmentQuestionID == assessmentQuestionID);
            Check.RequireNotNullThrowNotFound(assessmentQuestion, "AssessmentQuestion", assessmentQuestionID);
            return assessmentQuestion;
        }

        public static void DeleteAssessmentQuestion(this IQueryable<AssessmentQuestion> assessmentQuestions, List<int> assessmentQuestionIDList)
        {
            if(assessmentQuestionIDList.Any())
            {
                assessmentQuestions.Where(x => assessmentQuestionIDList.Contains(x.AssessmentQuestionID)).Delete();
            }
        }

        public static void DeleteAssessmentQuestion(this IQueryable<AssessmentQuestion> assessmentQuestions, ICollection<AssessmentQuestion> assessmentQuestionsToDelete)
        {
            if(assessmentQuestionsToDelete.Any())
            {
                var assessmentQuestionIDList = assessmentQuestionsToDelete.Select(x => x.AssessmentQuestionID).ToList();
                assessmentQuestions.Where(x => assessmentQuestionIDList.Contains(x.AssessmentQuestionID)).Delete();
            }
        }

        public static void DeleteAssessmentQuestion(this IQueryable<AssessmentQuestion> assessmentQuestions, int assessmentQuestionID)
        {
            DeleteAssessmentQuestion(assessmentQuestions, new List<int> { assessmentQuestionID });
        }

        public static void DeleteAssessmentQuestion(this IQueryable<AssessmentQuestion> assessmentQuestions, AssessmentQuestion assessmentQuestionToDelete)
        {
            DeleteAssessmentQuestion(assessmentQuestions, new List<AssessmentQuestion> { assessmentQuestionToDelete });
        }
    }
}