/*-----------------------------------------------------------------------
<copyright file="ProjectAssessmentQuestionController.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using ProjectFirma.Web.Security;
using ProjectFirma.Web.Views.ProjectAssessmentQuestion;
using ProjectFirmaModels.Models;
using LtInfo.Common;
using LtInfo.Common.MvcResults;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Controllers
{
    public class ProjectAssessmentQuestionController : FirmaBaseController
    {
        [HttpGet]
        [ProjectEditAsAdminFeature]
        public PartialViewResult EditAssessment(ProjectPrimaryKey projectPrimaryKey)
        {
            var project = projectPrimaryKey.EntityObject;
            var projectAssessmentQuestionSimples = GetProjectAssessmentQuestionSimples(project);

            var viewModel = new EditAssessmentViewModel(projectAssessmentQuestionSimples);
            return ViewEditAssessment(project, viewModel);
        }

        public static List<ProjectAssessmentQuestionSimple> GetProjectAssessmentQuestionSimples(Project project)
        {
            var allQuestionsAsSimples = HttpRequestStorage.DatabaseEntities.AssessmentQuestions.ToList().Select(x => new ProjectAssessmentQuestionSimple(x, project)).ToList();

            var answeredQuestions = project.ProjectAssessmentQuestions.ToList();

            foreach (var question in allQuestionsAsSimples)
            {
                var matchedQuestionOrNull = answeredQuestions.SingleOrDefault(answeredQuestion => answeredQuestion.AssessmentQuestionID == question.AssessmentQuestionID);
                question.Answer = matchedQuestionOrNull?.Answer;
            }
            return allQuestionsAsSimples;
        }


        [HttpPost]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        [ProjectEditAsAdminFeature]
        public ActionResult EditAssessment(ProjectPrimaryKey projectPrimaryKey, EditAssessmentViewModel viewModel)
        {
            var project = projectPrimaryKey.EntityObject;
            if (!ModelState.IsValid)
            {
                return ViewEditAssessment(project, viewModel);
            }

            viewModel.UpdateModel(project);
            SetMessageForDisplay(" Assessment successfully saved.");
            return new ModalDialogFormJsonResult();
        }

        private PartialViewResult ViewEditAssessment(Project project, EditAssessmentViewModel viewModel)
        {
            var assessmentGoals = HttpRequestStorage.DatabaseEntities.AssessmentGoals.ToList();
            var viewData = new EditAssessmentViewData(CurrentFirmaSession, project, assessmentGoals);
            return RazorPartialView<EditAssessment, EditAssessmentViewData, EditAssessmentViewModel>(viewData, viewModel);
        }
        
    }
}
