/*-----------------------------------------------------------------------
<copyright file="AssessmentController.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
Copyright (c) Tahoe Regional Planning Agency and Sitka Technology Group. All rights reserved.
<author>Sitka Technology Group</author>
</copyright>

<license>
This program is free software: you can redistribute it and/or modify
it under the terms of the GNU Affero General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU Affero General Public License <http://www.gnu.org/licenses/> for more details.

Source code is available upon request via <support@sitkatech.com>.
</license>
-----------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using ProjectFirma.Web.Security;
using ProjectFirma.Web.Views.Assessment;
using ProjectFirmaModels.Models;
using LtInfo.Common;
using LtInfo.Common.ExcelWorkbookUtilities;
using LtInfo.Common.MvcResults;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.Controllers
{
    public class AssessmentController : FirmaBaseController
    {
        [AssessmentManageFeature]
        public ViewResult Manage()
        {
            var goals = HttpRequestStorage.DatabaseEntities.AssessmentGoals.ToList();
            var viewData = new ManageViewData(CurrentFirmaSession, goals);
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
            viewModel.UpdateModel(goal, CurrentFirmaSession);
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
            viewModel.UpdateModel(subGoal, CurrentFirmaSession);
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
            viewModel.UpdateModel(question, CurrentFirmaSession);
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
            viewModel.UpdateModel(question, CurrentFirmaSession);
            HttpRequestStorage.DatabaseEntities.AllAssessmentQuestions.Add(question);
            return new ModalDialogFormJsonResult();
        }

        private PartialViewResult ViewNewQuestion(NewQuestionViewModel viewModel)
        {
            var subGoalsGroup = HttpRequestStorage.DatabaseEntities.AssessmentSubGoals.ToList().ToGroupedSelectList();
            var viewData = new NewQuestionViewData(CurrentFirmaSession, subGoalsGroup);
            return RazorPartialView<NewQuestion, NewQuestionViewData, NewQuestionViewModel>(viewData, viewModel);
        }

        [ProjectsViewFullListFeature]
        public ExcelResult IndexExcelDownload()
        {
            var projects = HttpRequestStorage.DatabaseEntities.Projects.ToList().GetActiveProjectsAndProposals(CurrentPerson.CanViewProposals());

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
            return new ExcelResult(excelWorkbook, $" Assessment as of {DateTime.Now.ToStringDateTime()}");
        }
    }
}
