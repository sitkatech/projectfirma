//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProjectAssessmentQuestion]
using System.Collections.Generic;
using System.Linq;
using CodeFirstStoreFunctions;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static ProjectAssessmentQuestion GetProjectAssessmentQuestion(this IQueryable<ProjectAssessmentQuestion> projectAssessmentQuestions, int projectAssessmentQuestionID)
        {
            var projectAssessmentQuestion = projectAssessmentQuestions.SingleOrDefault(x => x.ProjectAssessmentQuestionID == projectAssessmentQuestionID);
            Check.RequireNotNullThrowNotFound(projectAssessmentQuestion, "ProjectAssessmentQuestion", projectAssessmentQuestionID);
            return projectAssessmentQuestion;
        }

    }
}