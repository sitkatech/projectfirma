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
using System.Globalization;
using System.Linq;
using System.Web.Mvc;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;
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

        //[EvaluationManageFeature]
        [FirmaAdminFeature]
        public ViewResult Index()
        {

            var viewData = new IndexViewData(CurrentFirmaSession);
            return RazorView<Index, IndexViewData>(viewData);
        }

        [FirmaAdminFeature]
        public GridJsonNetJObjectResult<Evaluation> IndexGridJsonData()
        {
            var gridSpec = new IndexGridSpec(CurrentFirmaSession);
            var evaluations = HttpRequestStorage.DatabaseEntities.Evaluations.ToList();
            var gridJsonNetJObjectResult = new GridJsonNetJObjectResult<Evaluation>(evaluations, gridSpec);
            return gridJsonNetJObjectResult;
        }


        [HttpGet]
        [FirmaAdminFeature]
        public PartialViewResult New()
        {
            var viewModel = new EditViewModel();
            return ViewEdit(viewModel);
        }

        [HttpPost]
        [FirmaAdminFeature]
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
        [FirmaAdminFeature]
        public PartialViewResult Edit(EvaluationPrimaryKey evaluationPrimaryKey)
        {
            var evaluation = evaluationPrimaryKey.EntityObject;
            var viewModel = new EditViewModel(evaluation);
            return ViewEdit(viewModel);
        }

        [HttpPost]
        [FirmaAdminFeature]
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
            var evaluationStatuses = HttpRequestStorage.DatabaseEntities.EvaluationStatuses.ToSelectListWithEmptyFirstRow(v => v.EvaluationStatusID.ToString(), t => t.EvaluationStatusDisplayName);
            var evaluationVisibilities = HttpRequestStorage.DatabaseEntities.EvaluationVisibilities.ToSelectListWithEmptyFirstRow(v => v.EvaluationVisibilityID.ToString(), t => t.EvaluationVisibilityDisplayName);
            var viewData = new EditViewData(evaluationStatuses.ToList(), evaluationVisibilities.ToList());
            return RazorPartialView<Edit, EditViewData, EditViewModel>(viewData, viewModel);
        }



        [HttpGet]
        [FirmaAdminFeature]
        public PartialViewResult Delete(EvaluationPrimaryKey evaluationPrimaryKey)
        {
            var evaluation = evaluationPrimaryKey.EntityObject;
            var viewModel = new ConfirmDialogFormViewModel(evaluation.EvaluationID);
            return ViewDelete(evaluation, viewModel);
        }

        [HttpPost]
        [FirmaAdminFeature]
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
            //need to check for evals with connected data before deleting. prevent delete if eval has been run
            var hasNoAssociations = false;//!evaluation.
            var confirmMessage = hasNoAssociations
                ? $"<p>Are you sure you want to delete {FieldDefinitionEnum.Evaluation.ToType().GetFieldDefinitionLabel()} \"{evaluation.EvaluationName}\"?</p>"
                : String.Format(
                    "<p>Are you sure you want to delete {0} \"{1}\"?</p><p>Deleting this {0} will <strong>delete all associated evaluation data</strong>, and this action cannot be undone. Click {2} to review.</p>",
                    FieldDefinitionEnum.Evaluation.ToType().GetFieldDefinitionLabel(),
                    evaluation.EvaluationName,
                    SitkaRoute<EvaluationController>.BuildLinkFromExpression(x => x.Detail(evaluation), "here"));

            var viewData = new ConfirmDialogFormViewData(confirmMessage);
            return RazorPartialView<ConfirmDialogForm, ConfirmDialogFormViewData, ConfirmDialogFormViewModel>(viewData, viewModel);
        }


        [FirmaAdminFeature]
        public ViewResult Detail(EvaluationPrimaryKey evaluationPrimaryKey)
        {
            var evaluation = evaluationPrimaryKey.EntityObject;
            //todo: TK need to fix permissions
            //var canManageEvaluations = new FirmaAdminFeature().HasPermissionByFirmaSession(CurrentFirmaSession);
            //var isAdmin = new FirmaAdminFeature().HasPermissionByFirmaSession(CurrentFirmaSession);


            var viewData = new DetailViewData(CurrentFirmaSession, evaluation);
            return RazorView<Detail, DetailViewData>(viewData);
        }



        [HttpGet]
        [EvaluationManageFeature]
        public PartialViewResult EditEvaluationCriterion(EvaluationPrimaryKey evaluationPrimaryKey)
        {
            var evaluation = evaluationPrimaryKey.EntityObject;
            var viewModel = new EditEvaluationCriterionViewModel(evaluation);
            return ViewEditEvaluationCriterion(viewModel);
        }

        [HttpPost]
        [EvaluationManageFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult EditEvaluationCriterion(EvaluationPrimaryKey evaluationPrimaryKey, EditEvaluationCriterionViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return ViewEditEvaluationCriterion(viewModel);
            }

            var evaluation = evaluationPrimaryKey.EntityObject;
            viewModel.UpdateModel(evaluation);

            SetMessageForDisplay(
                $"Successfully updated {FieldDefinitionEnum.Evaluation.ToType().GetFieldDefinitionLabel()} '{evaluation.EvaluationName}'!");
            return new ModalDialogFormJsonResult();
        }

        private PartialViewResult ViewEditEvaluationCriterion(EditEvaluationCriterionViewModel viewModel)
        {
            var viewData = new EditEvaluationCriterionViewData();
            return RazorPartialView<EditEvaluationCriterion, EditEvaluationCriterionViewData, EditEvaluationCriterionViewModel>(viewData, viewModel);
        }



    }
}
