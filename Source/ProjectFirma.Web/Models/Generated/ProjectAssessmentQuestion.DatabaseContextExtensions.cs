//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProjectAssessmentQuestion]
using System.Collections.Generic;
using System.Linq;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static ProjectAssessmentQuestion GetProjectAssessmentQuestion(this IQueryable<ProjectAssessmentQuestion> projectAssessmentQuestions, int projectAssessmentQuestionID)
        {
            var projectAssessmentQuestion = projectAssessmentQuestions.SingleOrDefault(x => x.ProjectAssessmentQuestionID == projectAssessmentQuestionID);
            Check.RequireNotNullThrowNotFound(projectAssessmentQuestion, "ProjectAssessmentQuestion", projectAssessmentQuestionID);
            return projectAssessmentQuestion;
        }

        public static void DeleteProjectAssessmentQuestion(this List<int> projectAssessmentQuestionIDList)
        {
            if(projectAssessmentQuestionIDList.Any())
            {
                HttpRequestStorage.DatabaseEntities.AllProjectAssessmentQuestions.RemoveRange(HttpRequestStorage.DatabaseEntities.ProjectAssessmentQuestions.Where(x => projectAssessmentQuestionIDList.Contains(x.ProjectAssessmentQuestionID)));
            }
        }

        public static void DeleteProjectAssessmentQuestion(this ICollection<ProjectAssessmentQuestion> projectAssessmentQuestionsToDelete)
        {
            if(projectAssessmentQuestionsToDelete.Any())
            {
                HttpRequestStorage.DatabaseEntities.AllProjectAssessmentQuestions.RemoveRange(projectAssessmentQuestionsToDelete);
            }
        }

        public static void DeleteProjectAssessmentQuestion(this int projectAssessmentQuestionID)
        {
            DeleteProjectAssessmentQuestion(new List<int> { projectAssessmentQuestionID });
        }

        public static void DeleteProjectAssessmentQuestion(this ProjectAssessmentQuestion projectAssessmentQuestionToDelete)
        {
            DeleteProjectAssessmentQuestion(new List<ProjectAssessmentQuestion> { projectAssessmentQuestionToDelete });
        }
    }
}