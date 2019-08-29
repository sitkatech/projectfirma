/*-----------------------------------------------------------------------
<copyright file="ClassificationController.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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

using LtInfo.Common.MvcResults;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Security;
using ProjectFirma.Web.Security.Shared;
using ProjectFirma.Web.Views.Classification;
using ProjectFirma.Web.Views.Shared;
using ProjectFirma.Web.Views.Shared.SortOrder;
using ProjectFirmaModels.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Detail = ProjectFirma.Web.Views.Classification.Detail;
using DetailViewData = ProjectFirma.Web.Views.Classification.DetailViewData;
using Index = ProjectFirma.Web.Views.Classification.Index;
using IndexGridSpec = ProjectFirma.Web.Views.Classification.IndexGridSpec;
using IndexViewData = ProjectFirma.Web.Views.Classification.IndexViewData;

namespace ProjectFirma.Web.Controllers
{
    public class ClassificationController : FirmaBaseController
    {
        [FirmaAdminFeature]
        public ViewResult Index(ClassificationSystemPrimaryKey classificationSystemPrimaryKey)
        {
            var classificationSystem = classificationSystemPrimaryKey.EntityObject;
            var viewData = new IndexViewData(CurrentPerson, classificationSystem);
            return RazorView<Index, IndexViewData>(viewData);
        }

        [FirmaAdminFeature]
        public GridJsonNetJObjectResult<Classification> IndexGridJsonData(ClassificationSystemPrimaryKey classificationSystemPrimaryKey)
        {
            var classificationSystem = classificationSystemPrimaryKey.EntityObject;
            var gridSpec = new IndexGridSpec(new FirmaAdminFeature().HasPermissionByPerson(CurrentPerson), classificationSystem);            
            var classifications = classificationSystem.Classifications.SortByOrderThenName().ToList();
            return new GridJsonNetJObjectResult<Classification>(classifications, gridSpec);
        }

        [HttpGet]
        [FirmaAdminFeature]
        public PartialViewResult New(ClassificationSystemPrimaryKey classificationSystemPrimaryKey)
        {
            var classificationSystem = classificationSystemPrimaryKey.EntityObject;
            var viewModel = new EditViewModel();
            return ViewEdit(viewModel, classificationSystem);
        }

        [HttpPost]
        [FirmaAdminFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult New(ClassificationSystemPrimaryKey classificationSystemPrimaryKey, EditViewModel viewModel)
        {
            var classificationSystem = classificationSystemPrimaryKey.EntityObject;

            if (!ModelState.IsValid)
            {
                return ViewEdit(viewModel, classificationSystem);
            }
            
            var classification = new Classification(string.Empty, "#BBBBBB", viewModel.DisplayName, classificationSystem.ClassificationSystemID);
            viewModel.UpdateModel(classification, CurrentPerson);
            HttpRequestStorage.DatabaseEntities.AllClassifications.Add(classification);

            HttpRequestStorage.DatabaseEntities.SaveChanges();
            SetMessageForDisplay(
                $"New {classificationSystem.ClassificationSystemName} {classification.GetDisplayNameAsUrl()} successfully created!");

            return new ModalDialogFormJsonResult();
        }

        [HttpGet]
        [FirmaAdminFeature]
        public PartialViewResult Edit(ClassificationPrimaryKey classificationPrimaryKey)
        {
            var classification = classificationPrimaryKey.EntityObject;
            var viewModel = new EditViewModel(classification);
            return ViewEdit(viewModel, classification.ClassificationSystem);
        }

        [HttpPost]
        [FirmaAdminFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult Edit(ClassificationPrimaryKey classificationPrimaryKey, EditViewModel viewModel)
        {
            var classification = classificationPrimaryKey.EntityObject;
            if (!ModelState.IsValid)
            {
                return ViewEdit(viewModel, classification.ClassificationSystem);
            }
            
            viewModel.UpdateModel(classification, CurrentPerson);
            return new ModalDialogFormJsonResult();
        }

        private PartialViewResult ViewEdit(EditViewModel viewModel, ClassificationSystem classificationSystem)
        {            
            var viewData = new EditViewData(classificationSystem);
            return RazorPartialView<Edit, EditViewData, EditViewModel>(viewData, viewModel);
        }

        [HttpGet]
        [FirmaAdminFeature]
        public PartialViewResult DeleteClassification(ClassificationPrimaryKey classificationPrimaryKey)
        {
            var classification = classificationPrimaryKey.EntityObject;
            var viewModel = new ConfirmDialogFormViewModel(classification.ClassificationID);
            return ViewDeleteClassification(classification, viewModel);
        }

        private PartialViewResult ViewDeleteClassification(Classification classification, ConfirmDialogFormViewModel viewModel)
        {
            var canDelete = !classification.HasDependentObjects();
            var confirmMessage = canDelete
                ? $"Are you sure you want to delete this {classification.ClassificationSystem.ClassificationSystemName} '{classification.DisplayName}'?"
                : ConfirmDialogFormViewData.GetStandardCannotDeleteMessage(classification.ClassificationSystem.ClassificationSystemName, SitkaRoute<ClassificationController>.BuildLinkFromExpression(x => x.Detail(classification), "here"));

            var viewData = new ConfirmDialogFormViewData(confirmMessage, canDelete);
            return RazorPartialView<ConfirmDialogForm, ConfirmDialogFormViewData, ConfirmDialogFormViewModel>(viewData, viewModel);
        }

        [HttpPost]
        [FirmaAdminFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult DeleteClassification(ClassificationPrimaryKey classificationPrimaryKey, ConfirmDialogFormViewModel viewModel)
        {
            var classification = classificationPrimaryKey.EntityObject;
            if (!ModelState.IsValid)
            {
                return ViewDeleteClassification(classification, viewModel);
            }
            classification.DeleteFull(HttpRequestStorage.DatabaseEntities);
            return new ModalDialogFormJsonResult();
        }

        [AnonymousUnclassifiedFeature]
        public ViewResult Detail(ClassificationPrimaryKey classificationPrimaryKey)
        {
            var classification = classificationPrimaryKey.EntityObject;
            var projectCustomDefaultGridConfigurations = HttpRequestStorage.DatabaseEntities.ProjectCustomGridConfigurations.Where(x => x.IsEnabled && x.ProjectCustomGridTypeID == ProjectCustomGridType.Default.ProjectCustomGridTypeID).OrderBy(x => x.SortOrder).ToList();
            var viewData = new DetailViewData(CurrentPerson, classification, projectCustomDefaultGridConfigurations);
            return RazorView<Detail, DetailViewData>(viewData);
        }

        [FirmaAdminFeature]
        public PartialViewResult EditSortOrder(ClassificationSystemPrimaryKey classificationSystemPrimaryKey)
        {
            var classificationSystem = classificationSystemPrimaryKey.EntityObject;
            EditSortOrderViewModel viewModel = new EditSortOrderViewModel();
            return ViewEditSortOrder(classificationSystem, viewModel);
        }

        private PartialViewResult ViewEditSortOrder(ClassificationSystem classificationSystem, EditSortOrderViewModel viewModel)
        {
            EditSortOrderViewData viewData = new EditSortOrderViewData(new List<IHaveASortOrder>(classificationSystem.Classifications), ClassificationSystemModelExtensions.GetClassificationSystemNamePluralized(classificationSystem));
            return RazorPartialView<EditSortOrder, EditSortOrderViewData, EditSortOrderViewModel>(viewData, viewModel);
        }

        [HttpPost]
        [FirmaAdminFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult EditSortOrder(ClassificationSystemPrimaryKey classificationSystemPrimaryKey, EditSortOrderViewModel viewModel)
        {
            
            var classificationSystem = classificationSystemPrimaryKey.EntityObject;
            if (!ModelState.IsValid)
            {
                return ViewEditSortOrder(classificationSystem, viewModel);
            }

            viewModel.UpdateModel(new List<IHaveASortOrder>(classificationSystem.Classifications));
            SetMessageForDisplay("Successfully Updated Classification Sort Order");
            return new ModalDialogFormJsonResult();
        }
    }
}
