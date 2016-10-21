using System.Collections.Generic;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Areas.EIP.Views.ProjectTransportationQuestion
{
    public class EditTransportationAssessmentViewModel : FormViewModel
    {
        public List<ProjectTransportationQuestionSimple> ProjectTransportationQuestionSimples { get; set; }

        /// <summary>
        /// Needed by the ModelBinder
        /// </summary>
        public EditTransportationAssessmentViewModel()
        {
            
        }

       public EditTransportationAssessmentViewModel(List<ProjectTransportationQuestionSimple> projectTransportationQuestionSimples)
        {
            ProjectTransportationQuestionSimples = projectTransportationQuestionSimples;
        }   
 

        public void UpdateModel(Models.Project project)
        {
            HttpRequestStorage.DatabaseEntities.ProjectTransportationQuestions.RemoveRange(project.ProjectTransportationQuestions);
            foreach (var simple in ProjectTransportationQuestionSimples)
            {
                project.ProjectTransportationQuestions.Add(new Models.ProjectTransportationQuestion(simple));
            }                       
        }
    }
}