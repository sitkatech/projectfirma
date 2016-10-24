using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using ProjectFirma.Web.Security;
using ProjectFirma.Web.Views.ProjectTransportationQuestion;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Models;
using LtInfo.Common;
using LtInfo.Common.MvcResults;

namespace ProjectFirma.Web.Controllers
{
    public class ProjectTransportationQuestionController : LakeTahoeInfoBaseController
    {
        [HttpGet]
        [ProjectEditFeature]
        public PartialViewResult EditTransportationAssessment(ProjectPrimaryKey projectPrimaryKey)
        {
            var project = projectPrimaryKey.EntityObject;
            var projectTransportationQuestionSimples = GetProjectTransportationQuestionSimples(project);

            var viewModel = new EditTransportationAssessmentViewModel(projectTransportationQuestionSimples);
            return ViewEditTransportationAssessment(project, viewModel);
        }

        public static List<ProjectTransportationQuestionSimple> GetProjectTransportationQuestionSimples(Project project)
        {
            var allQuestionsAsSimples =
                HttpRequestStorage.DatabaseEntities.TransportationQuestions.ToList().Select(x => new ProjectTransportationQuestionSimple(x, project)).ToList();

            var answeredQuestions = project.ProjectTransportationQuestions.ToList();

            foreach (var question in allQuestionsAsSimples)
            {
                var matchedQuestionOrNull = answeredQuestions.SingleOrDefault(answeredQuestion => answeredQuestion.TransportationQuestionID == question.TransportationQuestionID);
                question.Answer = matchedQuestionOrNull == null ? null : matchedQuestionOrNull.Answer;
            }
            return allQuestionsAsSimples;
        }


        [HttpPost]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        [ProjectEditFeature]
        public ActionResult EditTransportationAssessment(ProjectPrimaryKey projectPrimaryKey, EditTransportationAssessmentViewModel viewModel)
        {
            var project = projectPrimaryKey.EntityObject;
            if (!ModelState.IsValid)
            {
                return ViewEditTransportationAssessment(project, viewModel);
            }

            viewModel.UpdateModel(project);
            SetMessageForDisplay("Transportation Assessment succesfully saved.");
            return new ModalDialogFormJsonResult();
        }

        private PartialViewResult ViewEditTransportationAssessment(Project project, EditTransportationAssessmentViewModel viewModel)
        {
            var transportationGoals = HttpRequestStorage.DatabaseEntities.TransportationGoals.ToList();
            var viewData = new EditTransportationAssessmentViewData(CurrentPerson, project, transportationGoals);
            return RazorPartialView<EditTransportationAssessment, EditTransportationAssessmentViewData, EditTransportationAssessmentViewModel>(viewData, viewModel);
        }
        
    }
}