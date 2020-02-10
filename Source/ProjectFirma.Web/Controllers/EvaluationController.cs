/*-----------------------------------------------------------------------
<copyright file="EvaluationController.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Mvc;
using LtInfo.Common.MvcResults;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Security;
using ProjectFirma.Web.Security.Shared;
using ProjectFirma.Web.Views.Evaluation;
using ProjectFirma.Web.Views.Shared;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Controllers
{
    public class EvaluationController : FirmaBaseController
    {

        [EvaluationViewFeature]
        public ViewResult Index()
        {
            var firmaPage = FirmaPageTypeEnum.EvaluationList.GetFirmaPage();
            var viewData = new IndexViewData(CurrentFirmaSession, firmaPage);
            return RazorView<Index, IndexViewData>(viewData);
        }

        [EvaluationViewFeature]
        public GridJsonNetJObjectResult<Evaluation> IndexGridJsonData()
        {
            var gridSpec = new IndexGridSpec(CurrentFirmaSession);
            var evaluations = HttpRequestStorage.DatabaseEntities.Evaluations.ToList();
            var gridJsonNetJObjectResult = new GridJsonNetJObjectResult<Evaluation>(evaluations, gridSpec);
            return gridJsonNetJObjectResult;
        }

        [EvaluationViewFeature]
        public GridJsonNetJObjectResult<EvaluationCriteria> EvaluationCriteriaGridJsonData(EvaluationPrimaryKey evaluationPrimaryKey)
        {
            var gridSpec = new EvaluationCriteriaGridSpec(CurrentFirmaSession);
            var evaluation = evaluationPrimaryKey.EntityObject;
            var evaluationCriteria = evaluation.EvaluationCriterias.ToList();
            var gridJsonNetJObjectResult = new GridJsonNetJObjectResult<EvaluationCriteria>(evaluationCriteria, gridSpec);
            return gridJsonNetJObjectResult;
        }


        [HttpGet]
        [EvaluationViewFeature]
        public PartialViewResult New()
        {
            var viewModel = new EditViewModel();
            return ViewEdit(viewModel);
        }

        [HttpPost]
        [EvaluationViewFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult New(EditViewModel viewModel)
        {
            Check.EnsureNotNull(CurrentFirmaSession.PersonID, "Missing PersonID");
            if (!ModelState.IsValid)
            {
                return ViewEdit(viewModel);
            }

            var evaluation = new Evaluation(viewModel.EvaluationVisibilityID, viewModel.EvaluationStatusID, CurrentFirmaSession.PersonID.Value, viewModel.EvaluationName, viewModel.EvaluationDefinition, DateTime.Now);

            viewModel.UpdateModel(evaluation, CurrentFirmaSession);
            HttpRequestStorage.DatabaseEntities.AllEvaluations.Add(evaluation);
            HttpRequestStorage.DatabaseEntities.SaveChanges();
            SetMessageForDisplay($"{FieldDefinitionEnum.Evaluation.ToType().GetFieldDefinitionLabel()} {evaluation.EvaluationName} successfully created.");

            return new ModalDialogFormJsonResult();
        }

        [HttpGet]
        [EvaluationManageFeature]
        public PartialViewResult Edit(EvaluationPrimaryKey evaluationPrimaryKey)
        {
            var evaluation = evaluationPrimaryKey.EntityObject;
            var viewModel = new EditViewModel(evaluation);
            return ViewEdit(viewModel);
        }

        [HttpPost]
        [EvaluationManageFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult Edit(EvaluationPrimaryKey evaluationPrimaryKey, EditViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return ViewEdit(viewModel);
            }
            var evaluation = evaluationPrimaryKey.EntityObject;
            viewModel.UpdateModel(evaluation, CurrentFirmaSession);
            return new ModalDialogFormJsonResult();
        }

        private PartialViewResult ViewEdit(EditViewModel viewModel)
        {
            var evaluationStatuses = EvaluationStatus.All.ToSelectListWithEmptyFirstRow(v => v.EvaluationStatusID.ToString(), t => t.EvaluationStatusDisplayName);
            var evaluationVisibilities = EvaluationVisibility.All.ToSelectListWithEmptyFirstRow(v => v.EvaluationVisibilityID.ToString(), t => t.EvaluationVisibilityDisplayName);

            var firmaPage = FirmaPageTypeEnum.CreateEvaluationInstructions.GetFirmaPage();
            var viewData = new EditViewData(CurrentFirmaSession, firmaPage, evaluationStatuses.ToList(), evaluationVisibilities.ToList());
            return RazorPartialView<Edit, EditViewData, EditViewModel>(viewData, viewModel);
        }



        [HttpGet]
        [EvaluationManageFeature]
        public PartialViewResult Delete(EvaluationPrimaryKey evaluationPrimaryKey)
        {
            var evaluation = evaluationPrimaryKey.EntityObject;
            var viewModel = new ConfirmDialogFormViewModel(evaluation.EvaluationID);
            return ViewDelete(evaluation, viewModel);
        }

        [HttpPost]
        [EvaluationManageFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult Delete(EvaluationPrimaryKey evaluationPrimaryKey, ConfirmDialogFormViewModel viewModel)
        {
            var evaluation = evaluationPrimaryKey.EntityObject;
            if (!ModelState.IsValid)
            {
                return ViewDelete(evaluation, viewModel);
            }

            evaluation.DeleteFull(HttpRequestStorage.DatabaseEntities);
            SetMessageForDisplay($"Successfully deleted {FieldDefinitionEnum.Evaluation.ToType().GetFieldDefinitionLabel()} '{evaluation.EvaluationName}'!");
            return new ModalDialogFormJsonResult();
        }

        private PartialViewResult ViewDelete(Evaluation evaluation, ConfirmDialogFormViewModel viewModel)
        {
            var canDelete = evaluation.CanDelete();
            var confirmMessage = canDelete
                ? $"<p>Are you sure you want to delete {FieldDefinitionEnum.Evaluation.ToType().GetFieldDefinitionLabel()} \"{evaluation.EvaluationName}\"?</p>"
                : ConfirmDialogFormViewData.GetStandardCannotDeleteMessage(FieldDefinitionEnum.Evaluation.ToType().GetFieldDefinitionLabel());

            var viewData = new ConfirmDialogFormViewData(confirmMessage, canDelete);
            return RazorPartialView<ConfirmDialogForm, ConfirmDialogFormViewData, ConfirmDialogFormViewModel>(viewData, viewModel);
        }


        [EvaluationManageFeature]
        public ViewResult Detail(EvaluationPrimaryKey evaluationPrimaryKey)
        {
            var evaluation = evaluationPrimaryKey.EntityObject;
            var viewData = new DetailViewData(CurrentFirmaSession, evaluation);
            return RazorView<Detail, DetailViewData>(viewData);
        }




        [HttpGet]
        [EvaluationManageFeature]
        public PartialViewResult NewEvaluationCriteria(EvaluationPrimaryKey evaluationPrimaryKey)
        {
            var viewModel = new EditEvaluationCriteriaViewModel();
            return ViewEditEvaluationCriteria(viewModel);
        }

        [HttpPost]
        [EvaluationManageFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult NewEvaluationCriteria(EvaluationPrimaryKey evaluationPrimaryKey, EditEvaluationCriteriaViewModel viewModel)
        {

            if (!ModelState.IsValid)
            {
                return ViewEditEvaluationCriteria(viewModel);
            }

            var evaluation = evaluationPrimaryKey.EntityObject;

            var evaluationCriteria = new EvaluationCriteria(evaluation, viewModel.EvaluationCriteriaName, viewModel.EvaluationCriteriaDefinition);

            if (viewModel.EvaluationCriteriaValueSimples.Count > 0)
            {
                evaluationCriteria.EvaluationCriteriaValues = viewModel.EvaluationCriteriaValueSimples.Select(x => new EvaluationCriteriaValue(evaluationCriteria, x.EvaluationCriteriaValueRating, x.EvaluationCriteriaValueDescription){SortOrder = x.SortOrder}).ToList();
            }
            

            HttpRequestStorage.DatabaseEntities.AllEvaluationCriterias.Add(evaluationCriteria);
            HttpRequestStorage.DatabaseEntities.SaveChanges();

            SetMessageForDisplay($"{FieldDefinitionEnum.EvaluationCriteria.ToType().GetFieldDefinitionLabel()} {evaluationCriteria.EvaluationCriteriaName} successfully created.");

            return new ModalDialogFormJsonResult();
        }

        [HttpGet]
        [EvaluationCriteriaManageFeature]
        public PartialViewResult EditEvaluationCriteria(EvaluationCriteriaPrimaryKey evaluationCriteriaPrimaryKey)
        {
            var evaluationCriteria = evaluationCriteriaPrimaryKey.EntityObject;
            var viewModel = new EditEvaluationCriteriaViewModel(evaluationCriteria);
            return ViewEditEvaluationCriteria(viewModel);
        }

        [HttpPost]
        [EvaluationCriteriaManageFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult EditEvaluationCriteria(EvaluationCriteriaPrimaryKey evaluationCriteriaPrimaryKey, EditEvaluationCriteriaViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return ViewEditEvaluationCriteria(viewModel);
            }

            var evaluationCriteria = evaluationCriteriaPrimaryKey.EntityObject;
            viewModel.UpdateModel(evaluationCriteria);

            SetMessageForDisplay(
                $"Successfully updated {FieldDefinitionEnum.EvaluationCriteria.ToType().GetFieldDefinitionLabel()} '{evaluationCriteria.EvaluationCriteriaName}'!");
            return new ModalDialogFormJsonResult();
        }

        private PartialViewResult ViewEditEvaluationCriteria(EditEvaluationCriteriaViewModel viewModel)
        {
            var firmaPage = FirmaPageTypeEnum.CreateEvaluationCriteriaInstructions.GetFirmaPage();
            var viewData = new EditEvaluationCriteriaViewData(CurrentFirmaSession, firmaPage);
            return RazorPartialView<EditEvaluationCriteria, EditEvaluationCriteriaViewData, EditEvaluationCriteriaViewModel>(viewData, viewModel);
        }

        [HttpGet]
        [EvaluationCriteriaManageFeature]
        public PartialViewResult DeleteEvaluationCriteria(EvaluationCriteriaPrimaryKey evaluationCriteriaPrimaryKey)
        {
            var evaluationCriteria = evaluationCriteriaPrimaryKey.EntityObject;
            var viewModel = new ConfirmDialogFormViewModel(evaluationCriteria.EvaluationCriteriaID);
            return ViewDeleteEvaluationCriteria(evaluationCriteria, viewModel);
        }

        [HttpPost]
        [EvaluationCriteriaManageFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult DeleteEvaluationCriteria(EvaluationCriteriaPrimaryKey evaluationCriteriaPrimaryKey, ConfirmDialogFormViewModel viewModel)
        {
            var evaluationCriteria = evaluationCriteriaPrimaryKey.EntityObject;
            if (!ModelState.IsValid)
            {
                return ViewDeleteEvaluationCriteria(evaluationCriteria, viewModel);
            }

            evaluationCriteria.DeleteFull(HttpRequestStorage.DatabaseEntities);
            SetMessageForDisplay($"Successfully deleted {FieldDefinitionEnum.EvaluationCriteria.ToType().GetFieldDefinitionLabel()} '{evaluationCriteria.EvaluationCriteriaName}'!");
            return new ModalDialogFormJsonResult();
        }

        private PartialViewResult ViewDeleteEvaluationCriteria(EvaluationCriteria evaluationCriteria, ConfirmDialogFormViewModel viewModel)
        {
            bool canDelete = evaluationCriteria.CanDelete();
            var confirmMessage = canDelete
                ? $"<p>Are you sure you want to delete {FieldDefinitionEnum.EvaluationCriteria.ToType().GetFieldDefinitionLabel()} \"{evaluationCriteria.EvaluationCriteriaName}\"?</p>"
                : ConfirmDialogFormViewData.GetStandardCannotDeleteMessage(FieldDefinitionEnum.EvaluationCriteria.ToType().GetFieldDefinitionLabel());

            var viewData = new ConfirmDialogFormViewData(confirmMessage, canDelete);
            return RazorPartialView<ConfirmDialogForm, ConfirmDialogFormViewData, ConfirmDialogFormViewModel>(viewData, viewModel);
        }

        [HttpGet]
        [AnonymousUnclassifiedFeature]
        public ContentResult EvaluationCriteriaDefinition(EvaluationCriteriaPrimaryKey evaluationCriteriaPrimaryKey)
        {
            return Content(evaluationCriteriaPrimaryKey.EntityObject.EvaluationCriteriaDefinition);
        }





        [HttpGet]
        [EvaluationManageFeature]
        public PartialViewResult AddProjectEvaluation(EvaluationPrimaryKey evaluationPrimaryKey)
        {
            var evaluation = evaluationPrimaryKey.EntityObject;
            var viewModel = new AddProjectEvaluationViewModel(evaluation);
            return ViewAddProjectEvaluation(viewModel, evaluation);
        }

        [HttpPost]
        [EvaluationManageFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult AddProjectEvaluation(EvaluationPrimaryKey evaluationPrimaryKey, AddProjectEvaluationViewModel viewModel)
        {
            var evaluation = evaluationPrimaryKey.EntityObject;
            if (!ModelState.IsValid)
            {
                return ViewAddProjectEvaluation(viewModel, evaluation);
            }

            
            viewModel.UpdateModel(CurrentFirmaSession, evaluation);

            SetMessageForDisplay($"Successfully added projects to this {FieldDefinitionEnum.EvaluationPortfolio.ToType().GetFieldDefinitionLabel()}.");

            return new ModalDialogFormJsonResult();
        }

        private PartialViewResult ViewAddProjectEvaluation(AddProjectEvaluationViewModel viewModel, Evaluation evaluation)
        {
            var selectedProjectIDs = viewModel.ProjectIDs ?? new List<int>();
            var allProjects = HttpRequestStorage.DatabaseEntities.Projects.ToList();
            var projectsThatAreNotSelectedAlready = allProjects.Where(x => !selectedProjectIDs.Contains(x.ProjectID)).ToList();
            var projectIDsThatAreNotSelectedAlready = projectsThatAreNotSelectedAlready.Select(x => x.ProjectID).ToList();
            var projectSimples = projectsThatAreNotSelectedAlready.Select(x => new ProjectSimple(x)).ToList();

            var taxonomyLeaves = HttpRequestStorage.DatabaseEntities.TaxonomyLeafs.Where(x => x.Projects.Any(y => projectIDsThatAreNotSelectedAlready.Contains(y.ProjectID))).ToList();
            var taxonomyLeafSimples = taxonomyLeaves.Select(x => new TaxonomyTierSimple(x)).OrderBy(x => x.DisplayName).ToList();

            var taxonomyBranches = taxonomyLeaves.Select(x => x.TaxonomyBranch).Distinct();
            var taxonomyBranchSimples = taxonomyBranches.Select(x => new TaxonomyTierSimple(x)).OrderBy(x => x.DisplayName).ToList();

            var taxonomyTrunk = taxonomyBranches.Select(x => x.TaxonomyTrunk).Distinct();
            var taxonomyTrunkSimples = taxonomyTrunk.Select(x => new TaxonomyTierSimple(x)).OrderBy(x => x.DisplayName).ToList();

            var taxonomyLevel = MultiTenantHelpers.GetTaxonomyLevel();

            var projectStages = ProjectStage.All.Select(x => new ProjectStageSimple(x)).ToList();

            var angularViewData = new AddProjectEvaluationViewDataForAngular(taxonomyTrunkSimples, taxonomyBranchSimples, taxonomyLeafSimples, projectSimples, taxonomyLevel, projectStages);

            var firmaPage = FirmaPageTypeEnum.AddProjectToEvaluationPortfolioInstructions.GetFirmaPage();
            var viewData = new AddProjectEvaluationViewData(CurrentFirmaSession, angularViewData, evaluation, firmaPage);
            return RazorPartialView<AddProjectEvaluation, AddProjectEvaluationViewData, AddProjectEvaluationViewModel>(viewData, viewModel);
        }

        [EvaluationManageFeature]
        public GridJsonNetJObjectResult<ProjectEvaluation> EvaluationPortfolioGridJsonData(EvaluationPrimaryKey evaluationPrimaryKey)
        {
            var evaluation = evaluationPrimaryKey.EntityObject;
            var gridSpec = new EvaluationPortfolioGridSpec(CurrentFirmaSession, evaluation);
            var projectEvaluations = evaluation.ProjectEvaluations.ToList();
            var gridJsonNetJObjectResult = new GridJsonNetJObjectResult<ProjectEvaluation>(projectEvaluations, gridSpec);
            return gridJsonNetJObjectResult;
        }





        [HttpGet]
        [ProjectEvaluationManageFeature]
        public PartialViewResult EditProjectEvaluation(ProjectEvaluationPrimaryKey projectEvaluationPrimaryKey)
        {
            var projectEvaluation = projectEvaluationPrimaryKey.EntityObject;

            if (projectEvaluation.Evaluation.EvaluationStatusID == (int)EvaluationStatusEnum.InProgress)
            {
                var viewModel = new EditProjectEvaluationViewModel(projectEvaluation);
                return ViewEditProjectEvaluation(viewModel, projectEvaluation);
            }
            else
            {
                var confirmMessage = $"{FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabelPluralized()} can only be evaluated when the {FieldDefinitionEnum.EvaluationStatus.ToType().GetFieldDefinitionLabel()} is {EvaluationStatus.InProgress.EvaluationStatusDisplayName}";

                var viewData = new ConfirmDialogFormViewData(confirmMessage, false);
                var viewModel = new ConfirmDialogFormViewModel(projectEvaluation.ProjectEvaluationID);
                return RazorPartialView<ConfirmDialogForm, ConfirmDialogFormViewData, ConfirmDialogFormViewModel>(viewData, viewModel);
            }
            
            
        }

        [HttpPost]
        [ProjectEvaluationManageFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult EditProjectEvaluation(ProjectEvaluationPrimaryKey projectEvaluationPrimaryKey, EditProjectEvaluationViewModel viewModel)
        {
            var projectEvaluation = projectEvaluationPrimaryKey.EntityObject;
            if (!ModelState.IsValid)
            {
                return ViewEditProjectEvaluation(viewModel, projectEvaluation);
            }


            viewModel.UpdateModel(CurrentFirmaSession, projectEvaluation);

            SetMessageForDisplay($"Successfully updated the {FieldDefinitionEnum.ProjectEvaluation.ToType().GetFieldDefinitionLabel()} for {projectEvaluation.Project.GetDisplayName()}.");

            return new ModalDialogFormJsonResult();
        }

        private PartialViewResult ViewEditProjectEvaluation(EditProjectEvaluationViewModel viewModel, ProjectEvaluation projectEvaluation)
        {
            var evaluationCriteriaSimples = projectEvaluation.Evaluation.EvaluationCriterias.Select(x => new EvaluationCriteriaSimple(x)).ToList();
            var viewData = new EditProjectEvaluationViewData(projectEvaluation, evaluationCriteriaSimples);
            return RazorPartialView<EditProjectEvaluation, EditProjectEvaluationViewData, EditProjectEvaluationViewModel>(viewData, viewModel);
        }


        [HttpGet]
        [ProjectEvaluationManageFeature]
        public PartialViewResult DeleteProjectEvaluation(ProjectEvaluationPrimaryKey projectEvaluationCriteriaPrimaryKey)
        {
            var projectEvaluation = projectEvaluationCriteriaPrimaryKey.EntityObject;
            var viewModel = new ConfirmDialogFormViewModel(projectEvaluation.ProjectEvaluationID);
            return ViewDeleteProjectEvaluation(projectEvaluation, viewModel);
        }

        [HttpPost]
        [ProjectEvaluationManageFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult DeleteProjectEvaluation(ProjectEvaluationPrimaryKey projectEvaluationCriteriaPrimaryKey, ConfirmDialogFormViewModel viewModel)
        {
            var projectEvaluation = projectEvaluationCriteriaPrimaryKey.EntityObject;
            if (!ModelState.IsValid)
            {
                return ViewDeleteProjectEvaluation(projectEvaluation, viewModel);
            }

            var projectNameForDeletedEvaluation = projectEvaluation.Project.GetDisplayName();
            projectEvaluation.DeleteFull(HttpRequestStorage.DatabaseEntities);
            SetMessageForDisplay($"Successfully deleted {FieldDefinitionEnum.ProjectEvaluation.ToType().GetFieldDefinitionLabel()} for {FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()} '{projectNameForDeletedEvaluation}'!");
            return new ModalDialogFormJsonResult();
        }

        private PartialViewResult ViewDeleteProjectEvaluation(ProjectEvaluation projectEvaluation, ConfirmDialogFormViewModel viewModel)
        {
            var canDelete = projectEvaluation.CanDelete();
            var confirmMessage = canDelete
                ? $"<p>Are you sure you want to delete {FieldDefinitionEnum.ProjectEvaluation.ToType().GetFieldDefinitionLabel()} for {FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()} \"{projectEvaluation.Project.GetDisplayName()}\"?</p>"
                : ConfirmDialogFormViewData.GetStandardCannotDeleteMessage(FieldDefinitionEnum.ProjectEvaluation.ToType().GetFieldDefinitionLabel());

            var viewData = new ConfirmDialogFormViewData(confirmMessage, canDelete);
            return RazorPartialView<ConfirmDialogForm, ConfirmDialogFormViewData, ConfirmDialogFormViewModel>(viewData, viewModel);
        }

    }
}
