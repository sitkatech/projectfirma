using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using ProjectFirma.Web.Security;
using ProjectFirma.Web.Views.Assessment;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using LtInfo.Common;
using LtInfo.Common.ExcelWorkbookUtilities;
using LtInfo.Common.MvcResults;

namespace ProjectFirma.Web.Controllers
{
    public class AssessmentController : FirmaBaseController
    {
        [AssessmentManageFeature]
        public ViewResult Manage()
        {
            var goals = HttpRequestStorage.DatabaseEntities.AssessmentGoals.ToList();
            var viewData = new ManageViewData(CurrentPerson, goals);
            return RazorView<Manage, ManageViewData>(viewData);
        }

        [HttpGet]
        [AssessmentManageFeature]
        public PartialViewResult EditGoal(AssessmentGoalPrimaryKey assessmentGoalPrimaryKey)
        {
            var assessmentGoal = assessmentGoalPrimaryKey.EntityObject;
            var viewModel = new EditGoalViewModel(assessmentGoal);
            return ViewEdit(viewModel);
        }

        [HttpPost]
        [AssessmentManageFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult EditGoal(AssessmentGoalPrimaryKey assessmentGoalPrimaryKey, EditGoalViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return ViewEdit(viewModel);
            }
            var goal = assessmentGoalPrimaryKey.EntityObject;
            viewModel.UpdateModel(goal, CurrentPerson);
            return new ModalDialogFormJsonResult();
        }

        private PartialViewResult ViewEdit(EditGoalViewModel viewModel)
        {
            var viewData = new EditGoalViewData();
            return RazorPartialView<EditGoal, EditGoalViewData, EditGoalViewModel>(viewData, viewModel);
        }


        [HttpGet]
        [AssessmentManageFeature]
        public PartialViewResult EditSubGoal(AssessmentSubGoalPrimaryKey assessmentSubGoalPrimaryKey)
        {
            var subGoal = assessmentSubGoalPrimaryKey.EntityObject;
            var viewModel = new EditSubGoalViewModel(subGoal);
            return ViewEditSubGoal(viewModel);
        }

        [HttpPost]
        [AssessmentManageFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult EditSubGoal(AssessmentSubGoalPrimaryKey assessmentSubGoalPrimaryKey, EditSubGoalViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return ViewEditSubGoal(viewModel);
            }
            var subGoal = assessmentSubGoalPrimaryKey.EntityObject;
            viewModel.UpdateModel(subGoal, CurrentPerson);
            return new ModalDialogFormJsonResult();
        }

        private PartialViewResult ViewEditSubGoal(EditSubGoalViewModel viewModel)
        {
            var viewData = new EditSubGoalViewData();
            return RazorPartialView<EditSubGoal, EditSubGoalViewData, EditSubGoalViewModel>(viewData, viewModel);
        }

        [HttpGet]
        [AssessmentManageFeature]
        public PartialViewResult EditQuestion(AssessmentQuestionPrimaryKey assessmentQuestionPrimaryKey)
        {
            var question = assessmentQuestionPrimaryKey.EntityObject;
            var viewModel = new EditQuestionViewModel(question);
            return ViewEditQuestion(viewModel);
        }

        [HttpPost]
        [AssessmentManageFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult EditQuestion(AssessmentQuestionPrimaryKey assessmentQuestionPrimaryKey, EditQuestionViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return ViewEditQuestion(viewModel);
            }
            var question = assessmentQuestionPrimaryKey.EntityObject;
            viewModel.UpdateModel(question, CurrentPerson);
            return new ModalDialogFormJsonResult();
        }

        private PartialViewResult ViewEditQuestion(EditQuestionViewModel viewModel)
        {
            var viewData = new EditQuestionViewData();
            return RazorPartialView<EditQuestion, EditQuestionViewData, EditQuestionViewModel>(viewData, viewModel);
        }

        [HttpGet]
        [AssessmentManageFeature]
        public PartialViewResult NewQuestion()
        {
            var viewModel = new NewQuestionViewModel();
            return ViewNewQuestion(viewModel);
        }

        [HttpPost]
        [AssessmentManageFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult NewQuestion(NewQuestionViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return ViewNewQuestion(viewModel);
            }
            var question = new AssessmentQuestion(viewModel.AssessmentSubGoalID, viewModel.AssessmentQuestionText);
            viewModel.UpdateModel(question, CurrentPerson);
            HttpRequestStorage.DatabaseEntities.AssessmentQuestions.Add(question);
            return new ModalDialogFormJsonResult();
        }

        private PartialViewResult ViewNewQuestion(NewQuestionViewModel viewModel)
        {
            var subGoalsGroup = HttpRequestStorage.DatabaseEntities.AssessmentSubGoals.ToList().ToGroupedSelectList();
            var viewData = new NewQuestionViewData(CurrentPerson, subGoalsGroup);
            return RazorPartialView<NewQuestion, NewQuestionViewData, NewQuestionViewModel>(viewData, viewModel);
        }

        public static List<IProject> GetProjectsForGrid(Func<Project, bool> filterFunction)
        {
            var projects = HttpRequestStorage.DatabaseEntities.Projects.Select(x => (IProject) x);
            var proposedProjects = HttpRequestStorage.DatabaseEntities.ProposedProjects.Select(x => (IProject) x);
            return projects.Union(proposedProjects).ToList();
        }

        [ProjectsViewFullListFeature]
        public ExcelResult IndexExcelDownload()
        {
            var projects = GetProjectsForGrid(null);

            var projectsSpec = new ProjectAssessmentExcelSpec();
            var wsProjects = ExcelWorkbookSheetDescriptorFactory.MakeWorksheet("Projects", projectsSpec, projects);

            var questionsSpec = new QuestionsExcelSpec();
            var wsQuestions = ExcelWorkbookSheetDescriptorFactory.MakeWorksheet("Questions", questionsSpec, HttpRequestStorage.DatabaseEntities.AssessmentQuestions.ToList());

            var workSheets = new List<IExcelWorkbookSheetDescriptor>
            {
                wsProjects,
                wsQuestions
            };

            var wbm = new ExcelWorkbookMaker(workSheets);
            var excelWorkbook = wbm.ToXLWorkbook();
            return new ExcelResult(excelWorkbook, string.Format(" Assessment as of {0}", DateTime.Now.ToStringDateTime()));
        }
    }
}