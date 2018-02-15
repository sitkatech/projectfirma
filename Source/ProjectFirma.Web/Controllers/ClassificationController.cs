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
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using LtInfo.Common;
using LtInfo.Common.MvcResults;
using ProjectFirma.Web.Security;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Views.Classification;
using ProjectFirma.Web.Views.Project;
using ProjectFirma.Web.Views.Shared;
using DetailViewData = ProjectFirma.Web.Views.Classification.DetailViewData;
using Detail = ProjectFirma.Web.Views.Classification.Detail;
using Index = ProjectFirma.Web.Views.Classification.Index;
using IndexGridSpec = ProjectFirma.Web.Views.Classification.IndexGridSpec;
using IndexViewData = ProjectFirma.Web.Views.Classification.IndexViewData;

namespace ProjectFirma.Web.Controllers
{
    public class ClassificationController : FirmaBaseController
    {
        [PerformanceMeasureViewFeature]
        public ViewResult Index()
        {
            var firmaPage = FirmaPage.GetFirmaPageByPageType(FirmaPageType.ClassificationsList);
            var viewData = new IndexViewData(CurrentPerson, firmaPage, HttpRequestStorage.DatabaseEntities.Classifications.ToList());
            return RazorView<Index, IndexViewData>(viewData);
        }

        [PerformanceMeasureViewFeature]
        public GridJsonNetJObjectResult<Classification> IndexGridJsonData()
        {
            var gridSpec = new IndexGridSpec(new PerformanceMeasureManageFeature().HasPermissionByPerson(CurrentPerson));
            var classifications = HttpRequestStorage.DatabaseEntities.Classifications.ToList().OrderBy(x => x.ClassificationName).ToList();
            return new GridJsonNetJObjectResult<Classification>(classifications, gridSpec);
        }

        [HttpGet]
        [PerformanceMeasureManageFeature]
        public PartialViewResult New()
        {
            var viewModel = new EditViewModel();
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

            var classificationType = HttpRequestStorage.DatabaseEntities.ClassificationTypes.FirstOrDefault();
            var classification = new Classification(viewModel.DisplayName, string.Empty, "#BBBBBB", string.Empty, classificationType);
            viewModel.UpdateModel(classification, CurrentPerson);
            HttpRequestStorage.DatabaseEntities.AllClassifications.Add(classification);

            HttpRequestStorage.DatabaseEntities.SaveChanges();
            SetMessageForDisplay(
                $"New {FieldDefinition.Classification.GetFieldDefinitionLabel()} {classification.GetDisplayNameAsUrl()} successfully created!");

            return new ModalDialogFormJsonResult();
        }

        [HttpGet]
        [PerformanceMeasureManageFeature]
        public PartialViewResult Edit(ClassificationPrimaryKey classificationPrimaryKey)
        {
            var classification = classificationPrimaryKey.EntityObject;
            var viewModel = new EditViewModel(classification);
            return ViewEdit(viewModel);
        }

        [HttpPost]
        [PerformanceMeasureManageFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult Edit(ClassificationPrimaryKey classificationPrimaryKey, EditViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return ViewEdit(viewModel);
            }
            var classification = classificationPrimaryKey.EntityObject;
            viewModel.UpdateModel(classification, CurrentPerson);
            return new ModalDialogFormJsonResult();
        }

        private PartialViewResult ViewEdit(EditViewModel viewModel)
        {
            var viewData = new EditViewData();
            return RazorPartialView<Edit, EditViewData, EditViewModel>(viewData, viewModel);
        }

        [HttpGet]
        [PerformanceMeasureManageFeature]
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
                ? $"Are you sure you want to delete this {FieldDefinition.Classification.GetFieldDefinitionLabel()} '{classification.DisplayName}'?"
                : ConfirmDialogFormViewData.GetStandardCannotDeleteMessage(FieldDefinition.Classification.GetFieldDefinitionLabel(), SitkaRoute<ClassificationController>.BuildLinkFromExpression(x => x.Detail(classification), "here"));

            var viewData = new ConfirmDialogFormViewData(confirmMessage, canDelete);
            return RazorPartialView<ConfirmDialogForm, ConfirmDialogFormViewData, ConfirmDialogFormViewModel>(viewData, viewModel);
        }

        [HttpPost]
        [PerformanceMeasureManageFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult DeleteClassification(ClassificationPrimaryKey classificationPrimaryKey, ConfirmDialogFormViewModel viewModel)
        {
            var classification = classificationPrimaryKey.EntityObject;
            if (!ModelState.IsValid)
            {
                return ViewDeleteClassification(classification, viewModel);
            }
            classification.DeleteClassification();
            return new ModalDialogFormJsonResult();
        }

        [PerformanceMeasureViewFeature]
        public ViewResult Detail(ClassificationPrimaryKey classificationPrimaryKey)
        {
            var classification = classificationPrimaryKey.EntityObject;
            var viewData = new DetailViewData(CurrentPerson, classification);
            return RazorView<Detail, DetailViewData>(viewData);
        }

        [PerformanceMeasureViewFeature]
        public GridJsonNetJObjectResult<Project> ProjectsGridJsonData(ClassificationPrimaryKey classificationPrimaryKey)
        {
            var gridSpec = new BasicProjectInfoGridSpec(CurrentPerson, false);
            var projectClassifications = classificationPrimaryKey.EntityObject.GetAssociatedProjects(CurrentPerson);
            var gridJsonNetJObjectResult = new GridJsonNetJObjectResult<Project>(projectClassifications, gridSpec);
            return gridJsonNetJObjectResult;
        }
    }
}
