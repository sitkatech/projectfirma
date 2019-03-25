//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[AssessmentQuestion]
using System.Collections.Generic;
using System.Linq;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static AssessmentQuestion GetAssessmentQuestion(this IQueryable<AssessmentQuestion> assessmentQuestions, int assessmentQuestionID)
        {
            var assessmentQuestion = assessmentQuestions.SingleOrDefault(x => x.AssessmentQuestionID == assessmentQuestionID);
            Check.RequireNotNullThrowNotFound(assessmentQuestion, "AssessmentQuestion", assessmentQuestionID);
            return assessmentQuestion;
        }

    }
}