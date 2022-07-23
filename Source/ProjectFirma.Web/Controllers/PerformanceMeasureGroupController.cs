/*-----------------------------------------------------------------------
<copyright file="PerformanceMeasureController.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
using ProjectFirma.Web.Security;
using ProjectFirma.Web.Common;
using ProjectFirmaModels.Models;
using ProjectFirma.Web.Views.PerformanceMeasureGroup;
using LtInfo.Common.Mvc;
using LtInfo.Common.MvcResults;
using Newtonsoft.Json.Linq;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Views.Shared;
using ProjectFirma.Web.Views.Shared.SortOrder;

namespace ProjectFirma.Web.Controllers
{
    public class PerformanceMeasureGroupController : FirmaBaseController
    {


        [PerformanceMeasureManageFeature]
        public GridJsonNetJObjectResult<PerformanceMeasureGroup> PerformanceMeasureGroupGridJsonData()
        {
            var gridSpec = new PerformanceMeasureGroupGridSpec(CurrentFirmaSession);
            var performanceMeasureGroups = HttpRequestStorage.DatabaseEntities.PerformanceMeasureGroups.ToList();
            var gridJsonNetJObjectResult =
                new GridJsonNetJObjectResult<PerformanceMeasureGroup>(performanceMeasureGroups, gridSpec);
            return gridJsonNetJObjectResult;
        }

        [HttpGet]
        [PerformanceMeasureManageFeature]
        public PartialViewResult Edit(PerformanceMeasureGroupPrimaryKey performanceMeasureGroupPrimaryKey)
        {
            var performanceMeasureGroup = performanceMeasureGroupPrimaryKey.EntityObject;
            var allPerformanceMeasures = HttpRequestStorage.DatabaseEntities.PerformanceMeasures.ToList();
            var viewModel = new EditViewModel(performanceMeasureGroup, allPerformanceMeasures);
            return ViewEdit(viewModel);
        }

        [HttpPost]
        [PerformanceMeasureManageFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult Edit(PerformanceMeasureGroupPrimaryKey performanceMeasureGroupPrimaryKey, EditViewModel viewModel)
        {
            var performanceMeasureGroup = performanceMeasureGroupPrimaryKey.EntityObject;
            if (!ModelState.IsValid)
            {
                return ViewEdit(viewModel);
            }

            viewModel.UpdateModel(performanceMeasureGroup, CurrentFirmaSession, HttpRequestStorage.DatabaseEntities);

            return new ModalDialogFormJsonResult();
        }

        private PartialViewResult ViewEdit(EditViewModel viewModel)
        {
            var performanceMeasuresAsSelectListItems =
                HttpRequestStorage.DatabaseEntities.PerformanceMeasures.OrderBy(x => x.PerformanceMeasureDisplayName).ToList();
            var viewData = new EditViewData(performanceMeasuresAsSelectListItems);
            return RazorPartialView<Edit, EditViewData, EditViewModel>(viewData, viewModel);
        }

        [HttpGet]
        [PerformanceMeasureManageFeature]
        public PartialViewResult New()
        {
            var allPerformanceMeasures = HttpRequestStorage.DatabaseEntities.PerformanceMeasures.ToList();
            var viewModel = new EditViewModel(allPerformanceMeasures);
            return ViewEdit(viewModel);
        }

        [HttpPost]
        [PerformanceMeasureManageFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult New(EditViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return ViewEdit(viewModel);
            }

            var performanceMeasureGroup = new PerformanceMeasureGroup(default(string));
            viewModel.UpdateModel(performanceMeasureGroup, CurrentFirmaSession, HttpRequestStorage.DatabaseEntities);

            HttpRequestStorage.DatabaseEntities.AllPerformanceMeasureGroups.Add(performanceMeasureGroup);
            HttpRequestStorage.DatabaseEntities.SaveChanges();

            var performanceMeasureIDsSubmitted = new List<int>();
            if (viewModel.PerformanceMeasureListbox != null)
            {
                performanceMeasureIDsSubmitted.AddRange(viewModel.PerformanceMeasureListbox.SelectedItems.Select(y => Int32.Parse(y)).ToList());
            }

            var performanceMeasuresToUpdate =
                HttpRequestStorage.DatabaseEntities.PerformanceMeasures.Where(x =>
                    performanceMeasureIDsSubmitted.Contains(x.PerformanceMeasureID));

            foreach (var performanceMeasure in performanceMeasuresToUpdate)
            {
                performanceMeasure.PerformanceMeasureGroupID = performanceMeasureGroup.PerformanceMeasureGroupID;
            }

            SetMessageForDisplay(
                $"New {FieldDefinitionEnum.PerformanceMeasureGroup.ToType().GetFieldDefinitionLabel()} '{performanceMeasureGroup.PerformanceMeasureGroupName}' successfully created!");
            return new ModalDialogFormJsonResult();
        }

        
        [HttpGet]
        [PerformanceMeasureManageFeature]
        public PartialViewResult DeletePerformanceMeasureGroup(PerformanceMeasureGroupPrimaryKey performanceMeasureGroupPrimaryKey)
        {
            var performanceMeasureGroup = performanceMeasureGroupPrimaryKey.EntityObject;
            var viewModel = new ConfirmDialogFormViewModel(performanceMeasureGroup.PerformanceMeasureGroupID);
            return ViewDeletePerformanceMeasureGroup(performanceMeasureGroup, viewModel);
        }

        [HttpPost]
        [PerformanceMeasureManageFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult DeletePerformanceMeasureGroup(PerformanceMeasureGroupPrimaryKey performanceMeasureGroupPrimaryKey,
            ConfirmDialogFormViewModel viewModel)
        {
            var performanceMeasureGroup = performanceMeasureGroupPrimaryKey.EntityObject;
            if (!ModelState.IsValid)
            {
                return ViewDeletePerformanceMeasureGroup(performanceMeasureGroup, viewModel);
            }

            performanceMeasureGroup.DeleteFull(HttpRequestStorage.DatabaseEntities);
            SetMessageForDisplay(
                $"Successfully deleted {MultiTenantHelpers.GetPerformanceMeasureName()} Group '{performanceMeasureGroup.PerformanceMeasureGroupName}'!");
            return new ModalDialogFormJsonResult();
        }

        private PartialViewResult ViewDeletePerformanceMeasureGroup(PerformanceMeasureGroup performanceMeasureGroup,
            ConfirmDialogFormViewModel viewModel)
        {
            var canDelete = !performanceMeasureGroup.HasDependentObjects();
            var confirmMessage = canDelete
                ? $"<p>Are you sure you want to delete {FieldDefinitionEnum.PerformanceMeasureGroup.ToType().GetFieldDefinitionLabel()} \"{performanceMeasureGroup.PerformanceMeasureGroupName}\"?</p>"
                : ConfirmDialogFormViewData.GetStandardCannotDeleteMessage($"{FieldDefinitionEnum.PerformanceMeasureGroup.ToType().GetFieldDefinitionLabel()}");

            var viewData = new ConfirmDialogFormViewData(confirmMessage);
            return RazorPartialView<ConfirmDialogForm, ConfirmDialogFormViewData, ConfirmDialogFormViewModel>(viewData,
                viewModel);
        }
    }
}