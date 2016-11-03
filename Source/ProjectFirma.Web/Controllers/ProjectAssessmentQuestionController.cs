using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using ProjectFirma.Web.Security;
using ProjectFirma.Web.Views.ProjectAssessmentQuestion;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using LtInfo.Common;
using LtInfo.Common.MvcResults;

namespace ProjectFirma.Web.Controllers
{
    public class ProjectAssessmentQuestionController : FirmaBaseController
    {
        [HttpGet]
        [ProjectEditFeature]
        public PartialViewResult EditAssessment(ProjectPrimaryKey projectPrimaryKey)
        {
            var project = projectPrimaryKey.EntityObject;
            var projectAssessmentQuestionSimples = GetProjectAssessmentQuestionSimples(project);

            var viewModel = new EditAssessmentViewModel(projectAssessmentQuestionSimples);
            return ViewEditAssessment(project, viewModel);
        }

        public static List<ProjectAssessmentQuestionSimple> GetProjectAssessmentQuestionSimples(Project project)
        {
            var allQuestionsAsSimples =
                HttpRequestStorage.DatabaseEntities.AssessmentQuestions.ToList().Select(x => new ProjectAssessmentQuestionSimple(x, project)).ToList();

            var answeredQuestions = project.ProjectAssessmentQuestions.ToList();

            foreach (var question in allQuestionsAsSimples)
            {
                var matchedQuestionOrNull = answeredQuestions.SingleOrDefault(answeredQuestion => answeredQuestion.AssessmentQuestionID == question.AssessmentQuestionID);
                question.Answer = matchedQuestionOrNull == null ? null : matchedQuestionOrNull.Answer;
            }
            return allQuestionsAsSimples;
        }


        [HttpPost]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        [ProjectEditFeature]
        public ActionResult EditAssessment(ProjectPrimaryKey projectPrimaryKey, EditAssessmentViewModel viewModel)
        {
            var project = projectPrimaryKey.EntityObject;
            if (!ModelState.IsValid)
            {
                return ViewEditAssessment(project, viewModel);
            }

            viewModel.UpdateModel(project);
            SetMessageForDisplay(" Assessment succesfully saved.");
            return new ModalDialogFormJsonResult();
        }

        private PartialViewResult ViewEditAssessment(Project project, EditAssessmentViewModel viewModel)
        {
            var Goals = HttpRequestStorage.DatabaseEntities.AssessmentGoals.ToList();
            var viewData = new EditAssessmentViewData(CurrentPerson, project, Goals);
            return RazorPartialView<EditAssessment, EditAssessmentViewData, EditAssessmentViewModel>(viewData, viewModel);
        }
        
    }
}