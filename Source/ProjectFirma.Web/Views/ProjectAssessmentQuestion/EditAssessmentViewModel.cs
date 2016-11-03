using System.Collections.Generic;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Views.ProjectAssessmentQuestion
{
    public class EditAssessmentViewModel : FormViewModel
    {
        public List<ProjectAssessmentQuestionSimple> ProjectAssessmentQuestionSimples { get; set; }

        /// <summary>
        /// Needed by the ModelBinder
        /// </summary>
        public EditAssessmentViewModel()
        {
            
        }

       public EditAssessmentViewModel(List<ProjectAssessmentQuestionSimple> projectAssessmentQuestionSimples)
        {
            ProjectAssessmentQuestionSimples = projectAssessmentQuestionSimples;
        }   
 

        public void UpdateModel(Models.Project project)
        {
            HttpRequestStorage.DatabaseEntities.ProjectAssessmentQuestions.RemoveRange(project.ProjectAssessmentQuestions);
            foreach (var simple in ProjectAssessmentQuestionSimples)
            {
                project.ProjectAssessmentQuestions.Add(new Models.ProjectAssessmentQuestion(simple));
            }                       
        }
    }
}