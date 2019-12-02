/*-----------------------------------------------------------------------
<copyright file="GeospatialAreaController.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
using LtInfo.Common.Models;
using LtInfo.Common.MvcResults;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Security;
using ProjectFirma.Web.Security.Shared;
using ProjectFirma.Web.Views.GeospatialArea;
using ProjectFirma.Web.Views.Shared;
using ProjectFirmaModels.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Detail = ProjectFirma.Web.Views.GeospatialArea.Detail;
using DetailViewData = ProjectFirma.Web.Views.GeospatialArea.DetailViewData;
using Index = ProjectFirma.Web.Views.GeospatialArea.Index;
using IndexGridSpec = ProjectFirma.Web.Views.GeospatialArea.IndexGridSpec;
using IndexViewData = ProjectFirma.Web.Views.GeospatialArea.IndexViewData;
using ProjectFirma.Web.Views.GeospatialAreaPerformanceMeasureTarget;

namespace ProjectFirma.Web.Controllers
{
    public class GeospatialAreaPerformanceMeasureTargetController : FirmaBaseController
    {
        [HttpGet]
        [GeospatialAreaPerformanceMeasureTargetManageFeature]
        public PartialViewResult AddGeospatialAreaToPerformanceMeasure(PerformanceMeasurePrimaryKey performanceMeasurePrimaryKey)
        {
            var performanceMeasure = performanceMeasurePrimaryKey.EntityObject;

            var viewModel = new AddGeospatialAreaToPerformanceMeasureViewModel(performanceMeasure);
            return ViewAddGeospatialAreaToPerformanceMeasure(performanceMeasure, viewModel);
        }

        [HttpPost]
        [AttachmentRelationshipTypeManageFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult AddGeospatialAreaToPerformanceMeasure(PerformanceMeasurePrimaryKey performanceMeasurePrimaryKey, AddGeospatialAreaToPerformanceMeasureViewModel viewModel)
        {
            var performanceMeasure = performanceMeasurePrimaryKey.EntityObject;
            if (!ModelState.IsValid)
            {
                return ViewAddGeospatialAreaToPerformanceMeasure(performanceMeasure, viewModel);
            }

            viewModel.UpdateModel(CurrentFirmaSession, performanceMeasure);

            return new ModalDialogFormJsonResult();
        }


        private PartialViewResult ViewAddGeospatialAreaToPerformanceMeasure(PerformanceMeasure performanceMeasure, AddGeospatialAreaToPerformanceMeasureViewModel viewModel)
        {
            var geospatialAreaTypeSimples = HttpRequestStorage.DatabaseEntities.GeospatialAreaTypes.ToList().Select(x => new GeospatialAreaTypeSimple(x)).ToList();

            //build list of geospatial areas and remove any we have already setup a connection to this performance measure
            var geospatialAreaSimples = HttpRequestStorage.DatabaseEntities.GeospatialAreas.ToList().Select(x => new GeospatialAreaSimple(x)).ToList();//todo: probably want this data coming from an AJAX call
            var selectedGeospatialAreas = HttpRequestStorage.DatabaseEntities.GeospatialAreaPerformanceMeasureTargets.Where(x => x.PerformanceMeasureID == performanceMeasure.PerformanceMeasureID).Select(x => x.GeospatialAreaID).ToList();
            var selectedGeospatialAreaSimples = geospatialAreaSimples.Where(x => selectedGeospatialAreas.Contains(x.GeospatialAreaID)).ToList();
            var setToRemove = new HashSet<GeospatialAreaSimple>(selectedGeospatialAreaSimples);
            geospatialAreaSimples.RemoveAll(x => setToRemove.Contains(x));

            var viewDataForAngular = new AddGeospatialAreaToPerformanceMeasureViewDataForAngular(performanceMeasure, geospatialAreaTypeSimples, geospatialAreaSimples);
            var viewData = new AddGeospatialAreaToPerformanceMeasureViewData(performanceMeasure, viewDataForAngular);
            return RazorPartialView<AddGeospatialAreaToPerformanceMeasure, AddGeospatialAreaToPerformanceMeasureViewData, AddGeospatialAreaToPerformanceMeasureViewModel>(viewData, viewModel);
        }

        [HttpGet]
        [GeospatialAreaPerformanceMeasureTargetManageFeature]
        public PartialViewResult Delete(GeospatialAreaPrimaryKey geospatialAreaPrimaryKey)
        {
            throw new NotImplementedException("Delete is not implemented");
        }

        //private PartialViewResult ViewDeleteGeospatialArea(GeospatialArea geospatialArea, ConfirmDialogFormViewModel viewModel)
        //{
        //    var canDelete = !geospatialArea.HasDependentObjects();
        //    var confirmMessage = canDelete
        //        ? $"Are you sure you want to delete this {geospatialArea.GeospatialAreaType.GeospatialAreaTypeName} '{geospatialArea.GeospatialAreaName}'?"
        //        : ConfirmDialogFormViewData.GetStandardCannotDeleteMessage($"{geospatialArea.GeospatialAreaType.GeospatialAreaTypeDefinition}", SitkaRoute<GeospatialAreaController>.BuildLinkFromExpression(x => x.Detail(geospatialArea), "here"));

        //    var viewData = new ConfirmDialogFormViewData(confirmMessage, canDelete);
        //    return RazorPartialView<ConfirmDialogForm, ConfirmDialogFormViewData, ConfirmDialogFormViewModel>(viewData, viewModel);
        //}

        //[HttpPost]
        //[GeospatialAreaManageFeature]
        //[AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        //public ActionResult DeleteGeospatialArea(GeospatialAreaPrimaryKey geospatialAreaPrimaryKey, ConfirmDialogFormViewModel viewModel)
        //{
        //    var geospatialArea = geospatialAreaPrimaryKey.EntityObject;
        //    if (!ModelState.IsValid)
        //    {
        //        return ViewDeleteGeospatialArea(geospatialArea, viewModel);
        //    }
        //    geospatialArea.DeleteFull(HttpRequestStorage.DatabaseEntities);
        //    return new ModalDialogFormJsonResult();
        //}
      

        [HttpGet]
        [GeospatialAreaPerformanceMeasureTargetManageFeature]
        public PartialViewResult Edit(GeospatialAreaPrimaryKey geospatialAreaPrimaryKey)
        {
            throw new NotImplementedException("Edit has not been implemented");
        }

        //[HttpPost]
        //[GeospatialAreaManageFeature]
        //[AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        //public ActionResult EditInDialog(GeospatialAreaTypePrimaryKey customPagePrimaryKey, EditGeospatialAreaTypeIntroTextViewModel viewModel)
        //{
        //    var customPage = customPagePrimaryKey.EntityObject;
        //    if (!ModelState.IsValid)
        //    {
        //        return ViewEditInDialog(viewModel);
        //    }
        //    viewModel.UpdateModel(customPage);
        //    return new ModalDialogFormJsonResult();
        //}

        //private PartialViewResult ViewEditInDialog(EditGeospatialAreaTypeIntroTextViewModel viewModel)
        //{
        //    var ckEditorToolbar = CkEditorExtension.CkEditorToolbar.Minimal;
        //    var viewData = new EditGeospatialAreaTypeIntroTextViewData(ckEditorToolbar);
        //    return RazorPartialView<EditGeospatialAreaTypeIntroText, EditGeospatialAreaTypeIntroTextViewData, EditGeospatialAreaTypeIntroTextViewModel>(viewData, viewModel);
        //}

    }
}
