//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProjectAssessmentQuestion]
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
        public static ProjectAssessmentQuestion GetProjectAssessmentQuestion(this IQueryable<ProjectAssessmentQuestion> projectAssessmentQuestions, int projectAssessmentQuestionID)
        {
            var projectAssessmentQuestion = projectAssessmentQuestions.SingleOrDefault(x => x.ProjectAssessmentQuestionID == projectAssessmentQuestionID);
            Check.RequireNotNullThrowNotFound(projectAssessmentQuestion, "ProjectAssessmentQuestion", projectAssessmentQuestionID);
            return projectAssessmentQuestion;
        }

        public static void DeleteProjectAssessmentQuestion(this IQueryable<ProjectAssessmentQuestion> projectAssessmentQuestions, List<int> projectAssessmentQuestionIDList)
        {
            if(projectAssessmentQuestionIDList.Any())
            {
                projectAssessmentQuestions.Where(x => projectAssessmentQuestionIDList.Contains(x.ProjectAssessmentQuestionID)).Delete();
            }
        }

        public static void DeleteProjectAssessmentQuestion(this IQueryable<ProjectAssessmentQuestion> projectAssessmentQuestions, ICollection<ProjectAssessmentQuestion> projectAssessmentQuestionsToDelete)
        {
            if(projectAssessmentQuestionsToDelete.Any())
            {
                var projectAssessmentQuestionIDList = projectAssessmentQuestionsToDelete.Select(x => x.ProjectAssessmentQuestionID).ToList();
                projectAssessmentQuestions.Where(x => projectAssessmentQuestionIDList.Contains(x.ProjectAssessmentQuestionID)).Delete();
            }
        }

        public static void DeleteProjectAssessmentQuestion(this IQueryable<ProjectAssessmentQuestion> projectAssessmentQuestions, int projectAssessmentQuestionID)
        {
            DeleteProjectAssessmentQuestion(projectAssessmentQuestions, new List<int> { projectAssessmentQuestionID });
        }

        public static void DeleteProjectAssessmentQuestion(this IQueryable<ProjectAssessmentQuestion> projectAssessmentQuestions, ProjectAssessmentQuestion projectAssessmentQuestionToDelete)
        {
            DeleteProjectAssessmentQuestion(projectAssessmentQuestions, new List<ProjectAssessmentQuestion> { projectAssessmentQuestionToDelete });
        }
    }
}