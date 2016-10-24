//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProjectTransportationQuestion]
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
        public static ProjectTransportationQuestion GetProjectTransportationQuestion(this IQueryable<ProjectTransportationQuestion> projectTransportationQuestions, int projectTransportationQuestionID)
        {
            var projectTransportationQuestion = projectTransportationQuestions.SingleOrDefault(x => x.ProjectTransportationQuestionID == projectTransportationQuestionID);
            Check.RequireNotNullThrowNotFound(projectTransportationQuestion, "ProjectTransportationQuestion", projectTransportationQuestionID);
            return projectTransportationQuestion;
        }

        public static void DeleteProjectTransportationQuestion(this IQueryable<ProjectTransportationQuestion> projectTransportationQuestions, List<int> projectTransportationQuestionIDList)
        {
            if(projectTransportationQuestionIDList.Any())
            {
                projectTransportationQuestions.Where(x => projectTransportationQuestionIDList.Contains(x.ProjectTransportationQuestionID)).Delete();
            }
        }

        public static void DeleteProjectTransportationQuestion(this IQueryable<ProjectTransportationQuestion> projectTransportationQuestions, ICollection<ProjectTransportationQuestion> projectTransportationQuestionsToDelete)
        {
            if(projectTransportationQuestionsToDelete.Any())
            {
                var projectTransportationQuestionIDList = projectTransportationQuestionsToDelete.Select(x => x.ProjectTransportationQuestionID).ToList();
                projectTransportationQuestions.Where(x => projectTransportationQuestionIDList.Contains(x.ProjectTransportationQuestionID)).Delete();
            }
        }

        public static void DeleteProjectTransportationQuestion(this IQueryable<ProjectTransportationQuestion> projectTransportationQuestions, int projectTransportationQuestionID)
        {
            DeleteProjectTransportationQuestion(projectTransportationQuestions, new List<int> { projectTransportationQuestionID });
        }

        public static void DeleteProjectTransportationQuestion(this IQueryable<ProjectTransportationQuestion> projectTransportationQuestions, ProjectTransportationQuestion projectTransportationQuestionToDelete)
        {
            DeleteProjectTransportationQuestion(projectTransportationQuestions, new List<ProjectTransportationQuestion> { projectTransportationQuestionToDelete });
        }
    }
}