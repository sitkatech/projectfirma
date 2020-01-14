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
        public GridJsonNetJObjectResult<EvaluationCriterion> EvaluationCriterionGridJsonData(EvaluationPrimaryKey evaluationPrimaryKey)
        {
            var gridSpec = new EvaluationCriterionGridSpec(CurrentFirmaSession);
            var evaluation = evaluationPrimaryKey.EntityObject;
            var evaluationCriterion = evaluation.EvaluationCriterions.ToList();
            var gridJsonNetJObjectResult = new GridJsonNetJObjectResult<EvaluationCriterion>(evaluationCriterion, gridSpec);
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
        public PartialViewResult NewEvaluationCriterion(EvaluationPrimaryKey evaluationPrimaryKey)
        {
            var viewModel = new EditEvaluationCriterionViewModel();
            return ViewEditEvaluationCriterion(viewModel);
        }

        [HttpPost]
        [EvaluationManageFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult NewEvaluationCriterion(EvaluationPrimaryKey evaluationPrimaryKey, EditEvaluationCriterionViewModel viewModel)
        {

            if (!ModelState.IsValid)
            {
                return ViewEditEvaluationCriterion(viewModel);
            }

            var evaluation = evaluationPrimaryKey.EntityObject;

            var evaluationCriterion = new EvaluationCriterion(evaluation, viewModel.EvaluationCriterionName, viewModel.EvaluationCriterionDefinition);

            if (viewModel.EvaluationCriterionValueSimples.Count > 0)
            {
                evaluationCriterion.EvaluationCriterionValues = viewModel.EvaluationCriterionValueSimples.Select(x => new EvaluationCriterionValue(evaluationCriterion, x.EvaluationCriterionValueRating, x.EvaluationCriterionValueDescription){SortOrder = x.SortOrder}).ToList();
            }
            

            HttpRequestStorage.DatabaseEntities.AllEvaluationCriterions.Add(evaluationCriterion);
            HttpRequestStorage.DatabaseEntities.SaveChanges();

            SetMessageForDisplay($"{FieldDefinitionEnum.EvaluationCriterion.ToType().GetFieldDefinitionLabel()} {evaluationCriterion.EvaluationCriterionName} successfully created.");

            return new ModalDialogFormJsonResult();
        }

        [HttpGet]
        [EvaluationCriterionManageFeature]
        public PartialViewResult EditEvaluationCriterion(EvaluationCriterionPrimaryKey evaluationCriterionPrimaryKey)
        {
            var evaluationCriterion = evaluationCriterionPrimaryKey.EntityObject;
            var viewModel = new EditEvaluationCriterionViewModel(evaluationCriterion);
            return ViewEditEvaluationCriterion(viewModel);
        }

        [HttpPost]
        [EvaluationCriterionManageFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult EditEvaluationCriterion(EvaluationCriterionPrimaryKey evaluationCriterionPrimaryKey, EditEvaluationCriterionViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return ViewEditEvaluationCriterion(viewModel);
            }

            var evaluationCriterion = evaluationCriterionPrimaryKey.EntityObject;
            viewModel.UpdateModel(evaluationCriterion);

            SetMessageForDisplay(
                $"Successfully updated {FieldDefinitionEnum.EvaluationCriterion.ToType().GetFieldDefinitionLabel()} '{evaluationCriterion.EvaluationCriterionName}'!");
            return new ModalDialogFormJsonResult();
        }

        private PartialViewResult ViewEditEvaluationCriterion(EditEvaluationCriterionViewModel viewModel)
        {
            var firmaPage = FirmaPageTypeEnum.CreateEvaluationCriterionInstructions.GetFirmaPage();
            var viewData = new EditEvaluationCriterionViewData(CurrentFirmaSession, firmaPage);
            return RazorPartialView<EditEvaluationCriterion, EditEvaluationCriterionViewData, EditEvaluationCriterionViewModel>(viewData, viewModel);
        }

        [HttpGet]
        [EvaluationCriterionManageFeature]
        public PartialViewResult DeleteEvaluationCriterion(EvaluationCriterionPrimaryKey evaluationCriterionPrimaryKey)
        {
            var evaluationCriterion = evaluationCriterionPrimaryKey.EntityObject;
            var viewModel = new ConfirmDialogFormViewModel(evaluationCriterion.EvaluationCriterionID);
            return ViewDeleteEvaluationCriterion(evaluationCriterion, viewModel);
        }

        [HttpPost]
        [EvaluationCriterionManageFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult DeleteEvaluationCriterion(EvaluationCriterionPrimaryKey evaluationCriterionPrimaryKey, ConfirmDialogFormViewModel viewModel)
        {
            var evaluationCriterion = evaluationCriterionPrimaryKey.EntityObject;
            if (!ModelState.IsValid)
            {
                return ViewDeleteEvaluationCriterion(evaluationCriterion, viewModel);
            }

            evaluationCriterion.DeleteFull(HttpRequestStorage.DatabaseEntities);
            SetMessageForDisplay($"Successfully deleted {FieldDefinitionEnum.EvaluationCriterion.ToType().GetFieldDefinitionLabel()} '{evaluationCriterion.EvaluationCriterionName}'!");
            return new ModalDialogFormJsonResult();
        }

        private PartialViewResult ViewDeleteEvaluationCriterion(EvaluationCriterion evaluationCriterion, ConfirmDialogFormViewModel viewModel)
        {
            bool canDelete = evaluationCriterion.CanDelete();
            var confirmMessage = canDelete
                ? $"<p>Are you sure you want to delete {FieldDefinitionEnum.EvaluationCriterion.ToType().GetFieldDefinitionLabel()} \"{evaluationCriterion.EvaluationCriterionName}\"?</p>"
                : ConfirmDialogFormViewData.GetStandardCannotDeleteMessage(FieldDefinitionEnum.EvaluationCriterion.ToType().GetFieldDefinitionLabel());

            var viewData = new ConfirmDialogFormViewData(confirmMessage, canDelete);
            return RazorPartialView<ConfirmDialogForm, ConfirmDialogFormViewData, ConfirmDialogFormViewModel>(viewData, viewModel);
        }





        [HttpGet]
        [EvaluationManageFeature]
        public PartialViewResult AddProjectEvaluation(EvaluationPrimaryKey evaluationPrimaryKey)
        {
            var viewModel = new AddProjectEvaluationViewModel();
            var evaluation = evaluationPrimaryKey.EntityObject;
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

            var taxonomyLeaves = HttpRequestStorage.DatabaseEntities.TaxonomyLeafs.Where(x => x.Projects.Any()).ToList();
            var taxonomyBranches = HttpRequestStorage.DatabaseEntities.TaxonomyBranches.ToList().Where(x => x.TaxonomyLeafs.Intersect(taxonomyLeaves).Any()).ToList();
            var taxonomyTrunk = HttpRequestStorage.DatabaseEntities.TaxonomyTrunks.ToList().Where(x => x.TaxonomyBranches.Intersect(taxonomyBranches).Any()).ToList();

            var selectedProjectIDs = viewModel.ProjectIDs ?? new List<int>();
            var projectSimples = HttpRequestStorage.DatabaseEntities.Projects.ToList().Where(x => !selectedProjectIDs.Contains(x.ProjectID)).Select(x => new ProjectSimple(x)).ToList();

            var taxonomyLevel = MultiTenantHelpers.GetTaxonomyLevel();

            var angularViewData = new AddProjectEvaluationViewDataForAngular(taxonomyTrunk.Select(x => new TaxonomyTierSimple(x)).ToList(), taxonomyBranches.Select(x => new TaxonomyTierSimple(x)).ToList(), taxonomyLeaves.Select(x => new TaxonomyTierSimple(x)).ToList(), projectSimples, taxonomyLevel);

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
            var evaluationCriterionSimples = projectEvaluation.Evaluation.EvaluationCriterions.Select(x => new EvaluationCriterionSimple(x)).ToList();
            var viewData = new EditProjectEvaluationViewData(projectEvaluation, evaluationCriterionSimples);
            return RazorPartialView<EditProjectEvaluation, EditProjectEvaluationViewData, EditProjectEvaluationViewModel>(viewData, viewModel);
        }


        [HttpGet]
        [ProjectEvaluationManageFeature]
        public PartialViewResult DeleteProjectEvaluation(ProjectEvaluationPrimaryKey projectEvaluationCriterionPrimaryKey)
        {
            var projectEvaluation = projectEvaluationCriterionPrimaryKey.EntityObject;
            var viewModel = new ConfirmDialogFormViewModel(projectEvaluation.ProjectEvaluationID);
            return ViewDeleteProjectEvaluation(projectEvaluation, viewModel);
        }

        [HttpPost]
        [ProjectEvaluationManageFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult DeleteProjectEvaluation(ProjectEvaluationPrimaryKey projectEvaluationCriterionPrimaryKey, ConfirmDialogFormViewModel viewModel)
        {
            var projectEvaluation = projectEvaluationCriterionPrimaryKey.EntityObject;
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
