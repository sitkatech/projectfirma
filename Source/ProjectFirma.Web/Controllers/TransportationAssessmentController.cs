using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using ProjectFirma.Web.Security;
using ProjectFirma.Web.Views.TransportationAssessment;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Models;
using LtInfo.Common;
using LtInfo.Common.ExcelWorkbookUtilities;
using LtInfo.Common.MvcResults;

namespace ProjectFirma.Web.Controllers
{
    public class TransportationAssessmentController : LakeTahoeInfoBaseController
    {
        [TransportationManageFeature]
        public ViewResult Manage()
        {
            var transportationGoals = HttpRequestStorage.DatabaseEntities.TransportationGoals.ToList();

            var viewData = new ManageViewData(CurrentPerson, transportationGoals);
            return RazorView<Manage, ManageViewData>(viewData);
        }

        [HttpGet]
        [TransportationManageFeature]
        public PartialViewResult EditTransportationGoal(TransportationGoalPrimaryKey transportationGoalPrimaryKey)
        {
            var transportationGoal = transportationGoalPrimaryKey.EntityObject;
            var viewModel = new EditTransportationGoalViewModel(transportationGoal);
            return ViewEdit(viewModel);
        }

        [HttpPost]
        [TransportationManageFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult EditTransportationGoal(TransportationGoalPrimaryKey transportationGoalPrimaryKey, EditTransportationGoalViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return ViewEdit(viewModel);
            }
            var transportationGoal = transportationGoalPrimaryKey.EntityObject;
            viewModel.UpdateModel(transportationGoal, CurrentPerson);
            return new ModalDialogFormJsonResult();
        }

        private PartialViewResult ViewEdit(EditTransportationGoalViewModel viewModel)
        {
            var viewData = new EditTransportationGoalViewData();
            return RazorPartialView<EditTransportationGoal, EditTransportationGoalViewData, EditTransportationGoalViewModel>(viewData, viewModel);
        }


        [HttpGet]
        [TransportationManageFeature]
        public PartialViewResult EditTransportationSubGoal(TransportationSubGoalPrimaryKey transportationSubGoalPrimaryKey)
        {
            var transportationSubGoal = transportationSubGoalPrimaryKey.EntityObject;
            var viewModel = new EditTransportationSubGoalViewModel(transportationSubGoal);
            return ViewEditSubGoal(viewModel);
        }

        [HttpPost]
        [TransportationManageFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult EditTransportationSubGoal(TransportationSubGoalPrimaryKey transportationSubGoalPrimaryKey, EditTransportationSubGoalViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return ViewEditSubGoal(viewModel);
            }
            var transportationSubGoal = transportationSubGoalPrimaryKey.EntityObject;
            viewModel.UpdateModel(transportationSubGoal, CurrentPerson);
            return new ModalDialogFormJsonResult();
        }

        private PartialViewResult ViewEditSubGoal(EditTransportationSubGoalViewModel viewModel)
        {
            var viewData = new EditTransportationSubGoalViewData();
            return RazorPartialView<EditTransportationSubGoal, EditTransportationSubGoalViewData, EditTransportationSubGoalViewModel>(viewData, viewModel);
        }

        [HttpGet]
        [TransportationManageFeature]
        public PartialViewResult EditTransportationQuestion(TransportationQuestionPrimaryKey transportationQuestionPrimaryKey)
        {
            var transportationQuestion = transportationQuestionPrimaryKey.EntityObject;
            var viewModel = new EditTransportationQuestionViewModel(transportationQuestion);
            return ViewEditQuestion(viewModel);
        }

        [HttpPost]
        [TransportationManageFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult EditTransportationQuestion(TransportationQuestionPrimaryKey transportationQuestionPrimaryKey, EditTransportationQuestionViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return ViewEditQuestion(viewModel);
            }
            var transportationQuestion = transportationQuestionPrimaryKey.EntityObject;
            viewModel.UpdateModel(transportationQuestion, CurrentPerson);
            return new ModalDialogFormJsonResult();
        }

        private PartialViewResult ViewEditQuestion(EditTransportationQuestionViewModel viewModel)
        {
            var viewData = new EditTransportationQuestionViewData();
            return RazorPartialView<EditTransportationQuestion, EditTransportationQuestionViewData, EditTransportationQuestionViewModel>(viewData, viewModel);
        }

        [HttpGet]
        [TransportationManageFeature]
        public PartialViewResult NewTransportationQuestion()
        {
            var viewModel = new NewTransportationQuestionViewModel();
            return ViewNewTransportationQuestion(viewModel);
        }

        [HttpPost]
        [TransportationManageFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult NewTransportationQuestion(NewTransportationQuestionViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return ViewNewTransportationQuestion(viewModel);
            }
            var transportationQuestion = new TransportationQuestion(viewModel.TransportationSubGoalID, viewModel.TransportationQuestionText);
            viewModel.UpdateModel(transportationQuestion, CurrentPerson);
            HttpRequestStorage.DatabaseEntities.TransportationQuestions.Add(transportationQuestion);
            return new ModalDialogFormJsonResult();
        }

        private PartialViewResult ViewNewTransportationQuestion(NewTransportationQuestionViewModel viewModel)
        {
            var transportationSubGoalsGroup = HttpRequestStorage.DatabaseEntities.TransportationSubGoals.ToList().ToGroupedSelectList();
            var viewData = new NewTransportationQuestionViewData(CurrentPerson, transportationSubGoalsGroup);
            return RazorPartialView<NewTransportationQuestion, NewTransportationQuestionViewData, NewTransportationQuestionViewModel>(viewData, viewModel);
        }

        public static List<IProject> GetProjectsForGrid(Func<Project, bool> filterFunction)
        {
            var projects = HttpRequestStorage.DatabaseEntities.Projects.Where(x => x.TransportationObjectiveID.HasValue).ToList().Select(x => (IProject) x);
            var proposedProjects = HttpRequestStorage.DatabaseEntities.ProposedProjects.Where(x => x.IsTransportationProject).ToList().Select(x => (IProject) x);
            return projects.Union(proposedProjects).ToList();
        }

        [ProjectsViewFullListFeature]
        public ExcelResult IndexExcelDownload()
        {
            var projects = GetProjectsForGrid(null);

            var projectsSpec = new ProjectTransportationAssessmentExcelSpec();
            var wsProjects = ExcelWorkbookSheetDescriptorFactory.MakeWorksheet("Projects", projectsSpec, projects);

            var questionsSpec = new TransportationQuestionsExcelSpec();
            var wsQuestions = ExcelWorkbookSheetDescriptorFactory.MakeWorksheet("Questions", questionsSpec, HttpRequestStorage.DatabaseEntities.TransportationQuestions.ToList());

            var workSheets = new List<IExcelWorkbookSheetDescriptor>
            {
                wsProjects,
                wsQuestions
            };

            var wbm = new ExcelWorkbookMaker(workSheets);
            var excelWorkbook = wbm.ToXLWorkbook();
            return new ExcelResult(excelWorkbook, string.Format("Transportation Assessment as of {0}", DateTime.Now.ToStringDateTime()));
        }


       
    }
}