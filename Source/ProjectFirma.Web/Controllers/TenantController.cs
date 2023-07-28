﻿/*-----------------------------------------------------------------------
<copyright file="TenantController.cs" company="Tahoe Regional Planning Agency and Environmental Science Associates">
Copyright (c) Tahoe Regional Planning Agency and Environmental Science Associates. All rights reserved.
<author>Environmental Science Associates</author>
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
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web.Mvc;
using GeoJSON.Net.Feature;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.GeoJson;
using LtInfo.Common.Mvc;
using LtInfo.Common.MvcResults;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using ProjectFirmaModels.Models;
using ProjectFirma.Web.Security;
using ProjectFirma.Web.Security.Shared;
using ProjectFirma.Web.Views.Shared;
using ProjectFirma.Web.Views.Tenant;

namespace ProjectFirma.Web.Controllers
{
    public class TenantController : FirmaBaseController
    {
        [SitkaAdminFeature]
        public ViewResult Detail()
        {
            var tenant = HttpRequestStorage.Tenant;
            var tenantAttribute = MultiTenantHelpers.GetTenantAttributeFromCache();
            var editBasicsUrl = new SitkaRoute<TenantController>(c => c.EditBasics()).BuildUrlFromExpression();
            var editBoundingBoxUrl = new SitkaRoute<TenantController>(c => c.EditBoundingBox()).BuildUrlFromExpression();
            var editClassificationSystemsUrl = new SitkaRoute<TenantController>(c => c.EditClassificationSystems()).BuildUrlFromExpression();
            var editTenantLogoUrl = new SitkaRoute<TenantController>(c => c.EditTenantLogo()).BuildUrlFromExpression();
            var deleteTenantStyleSheetFileResourceUrl = new SitkaRoute<TenantController>(c => c.DeleteTenantStyleSheetFileResource()).BuildUrlFromExpression();
            var deleteTenantSquareLogoFileResourceUrl = new SitkaRoute<TenantController>(c => c.DeleteTenantSquareLogoFileResource()).BuildUrlFromExpression();
            var deleteTenantBannerLogoFileResourceUrl = new SitkaRoute<TenantController>(c => c.DeleteTenantBannerLogoFileResource()).BuildUrlFromExpression();
            var boundingBoxLayer = new LayerGeoJson("Bounding Box",
                new FeatureCollection(new List<TenantAttribute> {tenantAttribute}.Select(x => DbGeometryToGeoJsonHelper.FromDbGeometry(x.DefaultBoundingBox)).ToList()),
                FirmaHelpers.DefaultColorRange[0],
                0.8m,
                LayerInitialVisibility.LayerInitialVisibilityEnum.Show);
            var layers = MapInitJson.GetConfiguredGeospatialAreaMapLayers();
            layers.Add(boundingBoxLayer);
            var mapInitJson = new MapInitJson("TenantDetailBoundingBoxMap",
                10,
                layers,
                MapInitJson.GetExternalMapLayerSimples(),
                BoundingBox.MakeBoundingBoxFromLayerGeoJsonList(new List<LayerGeoJson> {boundingBoxLayer}));
            var gridSpec = new DetailGridSpec { ObjectNameSingular = "Tenant", ObjectNamePlural = "Tenants", SaveFiltersInCookie = true };
            var gridName = "Tenants";
            var gridDataUrl = new SitkaRoute<TenantController>(c => c.DetailGridJsonData()).BuildUrlFromExpression();
            var costTypes = HttpRequestStorage.DatabaseEntities.CostTypes.ToList().Count > 0 ? string.Join(", ", HttpRequestStorage.DatabaseEntities.CostTypes.Select(x => x.CostTypeName).ToList()) : null;

            var viewData = new DetailViewData(CurrentFirmaSession,
                tenant,
                tenantAttribute,
                editBasicsUrl,
                editBoundingBoxUrl,
                deleteTenantStyleSheetFileResourceUrl,
                deleteTenantSquareLogoFileResourceUrl,
                deleteTenantBannerLogoFileResourceUrl,
                EditBoundingBoxFormID,
                mapInitJson,
                gridSpec,
                gridName,
                gridDataUrl, 
                editClassificationSystemsUrl,   
                editTenantLogoUrl,
                costTypes);
            return RazorView<Detail, DetailViewData>(viewData);
        }

        [SitkaAdminFeature]
        public GridJsonNetJObjectResult<TenantAttribute> DetailGridJsonData()
        {
            var gridSpec = new DetailGridSpec();
            var tenantAttributes = HttpRequestStorage.DatabaseEntities.AllTenantAttributes.ToList();
            return new GridJsonNetJObjectResult<TenantAttribute>(tenantAttributes, gridSpec);
        }

        [HttpGet]
        [SitkaAdminFeature]
        public PartialViewResult EditBasics()
        {
            var tenant = HttpRequestStorage.Tenant;
            var tenantAttribute = MultiTenantHelpers.GetTenantAttributeFromCache();
            var viewModel = new EditBasicsViewModel(tenant, tenantAttribute);
            return ViewEditBasics(viewModel);
        }

        [HttpPost]
        [SitkaAdminFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult EditBasics(EditBasicsViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return ViewEditBasics(viewModel);
            }

            var tenantAttribute = HttpRequestStorage.DatabaseEntities.AllTenantAttributes.Single(a => a.TenantID == viewModel.TenantID);
            var oldTenantAttributeTaxonomyLevel = tenantAttribute.TaxonomyLevel;
            var oldTenantAttributeAssociatePerformanceMeasureTaxonomyLevelID = tenantAttribute.AssociatePerfomanceMeasureTaxonomyLevelID;
            viewModel.UpdateModel(tenantAttribute, CurrentFirmaSession);
            if (viewModel.BudgetTypeID == BudgetType.AnnualBudgetByCostType.BudgetTypeID)
            {
                var existingCostTypes = HttpRequestStorage.DatabaseEntities.CostTypes.ToList();
                var allCostTypes = HttpRequestStorage.DatabaseEntities.AllCostTypes.Local;

                viewModel.UpdateCostTypes(existingCostTypes, allCostTypes);
            }
            var clearOutTaxonomyLeafPerformanceMeasures = oldTenantAttributeTaxonomyLevel.TaxonomyLevelID != tenantAttribute.TaxonomyLevelID || oldTenantAttributeAssociatePerformanceMeasureTaxonomyLevelID != tenantAttribute.AssociatePerfomanceMeasureTaxonomyLevelID;

            if (clearOutTaxonomyLeafPerformanceMeasures)
            {
                var taxonomyLeafPerformanceMeasures = HttpRequestStorage.DatabaseEntities.TaxonomyLeafPerformanceMeasures.ToList();
                foreach (var taxonomyLeafPerformanceMeasure in taxonomyLeafPerformanceMeasures)
                {                    
                    taxonomyLeafPerformanceMeasure.DeleteFull(HttpRequestStorage.DatabaseEntities);
                }
            }

            // if we are shrinking the number of tiers, we need to collapse child records to hidden parent record(s) named "Default"
            if (oldTenantAttributeTaxonomyLevel.TaxonomyLevelID > tenantAttribute.TaxonomyLevelID)
            {
                var newTaxonomyLevel = TaxonomyLevel.ToType(tenantAttribute.TaxonomyLevelID);
                const string defaultTrunkOrBranchName = "Default";
                if (newTaxonomyLevel == TaxonomyLevel.Branch)
                {
                    // create a new "Default" trunk to move all branches to
                    // ensure that name does not already exist
                    var newTaxonomyTrunkDefault = HttpRequestStorage.DatabaseEntities.TaxonomyTrunks.SingleOrDefault(x =>
                                                      x.TaxonomyTrunkName == defaultTrunkOrBranchName) ?? new TaxonomyTrunk(defaultTrunkOrBranchName);

                    var taxonomyBranches = HttpRequestStorage.DatabaseEntities.TaxonomyBranches.ToList();
                    foreach (var taxonomyBranch in taxonomyBranches)
                    {
                        taxonomyBranch.TaxonomyTrunk = newTaxonomyTrunkDefault;
                    }
                    HttpRequestStorage.DatabaseEntities.SaveChanges();
                    var taxonomyTrunks = HttpRequestStorage.DatabaseEntities.TaxonomyTrunks.Where(x => x.TaxonomyTrunkID != newTaxonomyTrunkDefault.TaxonomyTrunkID).ToList();
                    foreach (var taxonomyTrunk in taxonomyTrunks)
                    {
                        taxonomyTrunk.DeleteFull(HttpRequestStorage.DatabaseEntities);
                    }
                }
                else if (newTaxonomyLevel == TaxonomyLevel.Leaf)
                {
                    var newTaxonomyTrunkDefault = HttpRequestStorage.DatabaseEntities.TaxonomyTrunks.SingleOrDefault(x =>
                                                      x.TaxonomyTrunkName == defaultTrunkOrBranchName) ?? new TaxonomyTrunk(defaultTrunkOrBranchName);
                    var newTaxonomyBranchDefault = HttpRequestStorage.DatabaseEntities.TaxonomyBranches.SingleOrDefault(x =>
                                                       x.TaxonomyBranchName == defaultTrunkOrBranchName) ?? new TaxonomyBranch(newTaxonomyTrunkDefault, defaultTrunkOrBranchName);
                    var taxonomyLeaves = HttpRequestStorage.DatabaseEntities.TaxonomyLeafs.ToList();
                    foreach (var taxonomyLeaf in taxonomyLeaves)
                    {
                        taxonomyLeaf.TaxonomyBranch = newTaxonomyBranchDefault;
                    }
                    HttpRequestStorage.DatabaseEntities.SaveChanges();
                    var taxonomyBranches = HttpRequestStorage.DatabaseEntities.TaxonomyBranches.Where(x => x.TaxonomyBranchID != newTaxonomyBranchDefault.TaxonomyBranchID).ToList();
                    foreach (var taxonomyBranch in taxonomyBranches)
                    {
                        taxonomyBranch.DeleteFull(HttpRequestStorage.DatabaseEntities);
                    }

                    var taxonomyTrunks = HttpRequestStorage.DatabaseEntities.TaxonomyTrunks.Where(x => x.TaxonomyTrunkID != newTaxonomyTrunkDefault.TaxonomyTrunkID).ToList();
                    foreach (var taxonomyTrunk in taxonomyTrunks)
                    {
                        taxonomyTrunk.DeleteFull(HttpRequestStorage.DatabaseEntities);
                    }
                }
            }

            MultiTenantHelpers.ClearTenantAttributeCacheForAllTenants();

            return new ModalDialogFormJsonResult(new SitkaRoute<TenantController>(c => c.Detail()).BuildUrlFromExpression());
        }

        private PartialViewResult ViewEditBasics(EditBasicsViewModel viewModel)
        {
            var adminFeature = new FirmaAdminFeature();
            var tenantPeople = HttpRequestStorage.DatabaseEntities.People.ToList().Where(x => adminFeature.HasPermissionByPerson(x)).ToSelectListWithEmptyFirstRow(x => x.PersonID.ToString(CultureInfo.InvariantCulture), x => x.GetFullNameFirstLast());
            var taxonomyLevels = TaxonomyLevel.All.ToSelectListWithEmptyFirstRow(x => x.TaxonomyLevelID.ToString(CultureInfo.InvariantCulture), x => x.TaxonomyLevelDisplayName);
            var budgetTypeID = viewModel.BudgetTypeID;
            var budgetTypes = BudgetType.All.ToDictionary(x => x.BudgetTypeID, x => x.BudgetTypeDisplayName);
            var disabledBudgetTypeValues = new List<int>() { BudgetType.NoBudget.BudgetTypeID, BudgetType.AnnualBudget.BudgetTypeID };
            var costTypes = HttpRequestStorage.DatabaseEntities.CostTypes.Select(x => x.CostTypeName).ToList();
            // if any projects exist that are not ProjectType.Normal we do not want them to be able to turn off Enable Project Type checkbox
            bool canEditEnableProjectTypeCheckbox = !HttpRequestStorage.DatabaseEntities.Projects.Any(x => x.ProjectCategoryID != (int)ProjectCategoryEnum.Normal);
            var viewData = new EditBasicsViewData(CurrentFirmaSession, tenantPeople, taxonomyLevels, budgetTypeID, budgetTypes, disabledBudgetTypeValues, costTypes, canEditEnableProjectTypeCheckbox);
            return RazorPartialView<EditBasics, EditBasicsViewData, EditBasicsViewModel>(viewData, viewModel);
        }

        [HttpGet]
        [SitkaAdminFeature]
        public PartialViewResult EditTenantLogo()
        {
            var tenant = HttpRequestStorage.Tenant;
            var viewModel = new EditTenantLogoAndStylesheetViewModel(tenant);
            return ViewEditTenantLogo(viewModel);
        }

        [HttpPost]
        [SitkaAdminFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult EditTenantLogo(EditTenantLogoAndStylesheetViewModel andStylesheetViewModel)
        {
            if (!ModelState.IsValid)
            {
                return ViewEditTenantLogo(andStylesheetViewModel);
            }

            var tenantAttribute = HttpRequestStorage.DatabaseEntities.AllTenantAttributes.Single(a => a.TenantID == andStylesheetViewModel.TenantID);

            andStylesheetViewModel.UpdateModel(tenantAttribute, CurrentFirmaSession, HttpRequestStorage.DatabaseEntities);
            MultiTenantHelpers.ClearTenantAttributeCacheForAllTenants();
            return new ModalDialogFormJsonResult(new SitkaRoute<TenantController>(c => c.Detail()).BuildUrlFromExpression());
        }

        private PartialViewResult ViewEditTenantLogo(EditTenantLogoAndStylesheetViewModel andStylesheetViewModel)
        {
            var viewData = new EditTenantLogoAndStylesheetViewData(CurrentFirmaSession);
            return RazorPartialView<EditTenantLogoAndStylesheet, EditTenantLogoAndStylesheetViewData, EditTenantLogoAndStylesheetViewModel>(viewData, andStylesheetViewModel);
        }

        [HttpGet]
        [SitkaAdminFeature]
        public PartialViewResult EditBoundingBox()
        {
            var tenant = HttpRequestStorage.Tenant;
            var tenantAttribute = MultiTenantHelpers.GetTenantAttributeFromCache();
            var viewModel = new EditBoundingBoxViewModel(tenantAttribute);
            return ViewEditBoundingBox(viewModel, tenantAttribute);
        }

        [HttpPost]
        [SitkaAdminFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult EditBoundingBox(EditBoundingBoxViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                var tenant = HttpRequestStorage.Tenant;
                var tenantAttribute = MultiTenantHelpers.GetTenantAttributeFromCache();
                return ViewEditBoundingBox(viewModel, tenantAttribute);
            }

            viewModel.UpdateModel();
            MultiTenantHelpers.ClearTenantAttributeCacheForAllTenants();
            return new ModalDialogFormJsonResult();
        }

        private PartialViewResult ViewEditBoundingBox(EditBoundingBoxViewModel viewModel, TenantAttribute tenantAttribute)
        {
            var boundingBoxLayer = new LayerGeoJson("Bounding Box",
                new FeatureCollection(new List<TenantAttribute> {tenantAttribute}
                    .Select(x => DbGeometryToGeoJsonHelper.FromDbGeometry(x.DefaultBoundingBox)).ToList()),
                FirmaHelpers.DefaultColorRange[0],
                0.8m,
                LayerInitialVisibility.LayerInitialVisibilityEnum.Show);
            var mapInitJson = new MapInitJson("TenantEditBoundingBoxMap", 10, MapInitJson.GetConfiguredGeospatialAreaMapLayers(), MapInitJson.GetExternalMapLayerSimples(), BoundingBox.MakeBoundingBoxFromLayerGeoJsonList(new List<LayerGeoJson> {boundingBoxLayer}));
            var editBoundingBoxUrl = new SitkaRoute<TenantController>(c => c.EditBoundingBox()).BuildUrlFromExpression();

            var viewData = new EditBoundingBoxViewData(mapInitJson, editBoundingBoxUrl, EditBoundingBoxFormID);
            return RazorPartialView<EditBoundingBox, EditBoundingBoxViewData, EditBoundingBoxViewModel>(viewData, viewModel);
        }

        [HttpGet]
        [SitkaAdminFeature]
        public PartialViewResult EditClassificationSystems()
        {
            var tenant = HttpRequestStorage.Tenant;
            var viewModel = new EditClassificationSystemsViewModel(tenant);
            return ViewEditClassificationSystems(viewModel);
        }

        [HttpPost]
        [SitkaAdminFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult EditClassificationSystems(EditClassificationSystemsViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return ViewEditClassificationSystems(viewModel);
            }

            var currentClassificationSystems= MultiTenantHelpers.GetClassificationSystems();
            var allClassificationSystems = HttpRequestStorage.DatabaseEntities.AllClassificationSystems.Local;

            viewModel.UpdateModel(CurrentFirmaSession, currentClassificationSystems, allClassificationSystems);
            MultiTenantHelpers.ClearTenantAttributeCacheForAllTenants();
            return new ModalDialogFormJsonResult(new SitkaRoute<TenantController>(c => c.Detail()).BuildUrlFromExpression());
        }

        private PartialViewResult ViewEditClassificationSystems(EditClassificationSystemsViewModel viewModel)
        {
            var viewData = new EditClassificationSystemsViewData(CurrentFirmaSession);
            return RazorPartialView<EditClassificationSystems, EditClassificationSystemsViewData, EditClassificationSystemsViewModel>(viewData, viewModel);
        }


        [Route("Content/style-{tenantName}.css")]
        [AnonymousUnclassifiedFeature]
        public ActionResult Style(string tenantName)
        {
            var tenant = Tenant.All.SingleOrDefault(t => t.TenantName == tenantName);
            if (tenant == default(Tenant))
            {
                return HttpNotFound();
            }

            var tenantAttribute = MultiTenantHelpers.GetTenantAttributeFromCache();
            var fileResourceInfo = tenantAttribute.TenantStyleSheetFileResourceInfo;

            Check.Assert(fileResourceInfo != null, "Tenant Attribute must have an associated Tenant Style Sheet File Resource.");

            // ReSharper disable once PossibleNullReferenceException -- Check.Assert above covers us here
            return new FileStreamResult(new MemoryStream(fileResourceInfo.FileResourceData.Data), fileResourceInfo.FileResourceMimeType.FileResourceMimeTypeContentTypeName);
        }

        [HttpGet]
        [SitkaAdminFeature]
        public PartialViewResult DeleteTenantBannerLogoFileResource()
        {
            var tenant = HttpRequestStorage.Tenant;
            var tenantAttribute = MultiTenantHelpers.GetTenantAttributeFromCache();
            var viewModel = new ConfirmDialogFormViewModel(tenant.TenantID);
            return ViewDeleteTenantBannerLogoFileResource(viewModel, tenantAttribute);
        }

        [HttpPost]
        [SitkaAdminFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult DeleteTenantBannerLogoFileResource(ConfirmDialogFormViewModel viewModel)
        {
            var tenantAttribute = HttpRequestStorage.DatabaseEntities.AllTenantAttributes.Single(a => a.TenantID == HttpRequestStorage.DatabaseEntities.TenantID);
            if (!ModelState.IsValid)
            {
                return ViewDeleteTenantBannerLogoFileResource(viewModel, tenantAttribute);
            }

            var tenantAttributeTenantBannerLogoFileResource = tenantAttribute.TenantBannerLogoFileResourceInfo;
            var fileResourceDatas = tenantAttribute.TenantBannerLogoFileResourceInfo.FileResourceDatas;
            tenantAttribute.TenantBannerLogoFileResourceInfo.FileResourceDatas = null;
            tenantAttribute.TenantBannerLogoFileResourceInfo = null;
            foreach (var fileResourceData in fileResourceDatas)
            {
                fileResourceData.Delete(HttpRequestStorage.DatabaseEntities);
            }
            tenantAttributeTenantBannerLogoFileResource.Delete(HttpRequestStorage.DatabaseEntities);
            MultiTenantHelpers.ClearTenantAttributeCacheForAllTenants();
            return new ModalDialogFormJsonResult();
        }

        private PartialViewResult ViewDeleteTenantBannerLogoFileResource(ConfirmDialogFormViewModel viewModel, TenantAttribute tenantAttribute)
        {
            var confirmMessage = $"Are you sure you want to delete Tenant Banner Logo for {tenantAttribute.TenantShortDisplayName}?";
            var viewData = new ConfirmDialogFormViewData(confirmMessage);
            return RazorPartialView<ConfirmDialogForm, ConfirmDialogFormViewData, ConfirmDialogFormViewModel>(viewData, viewModel);
        }

        [HttpGet]
        [SitkaAdminFeature]
        public PartialViewResult DeleteTenantSquareLogoFileResource()
        {
            var tenant = HttpRequestStorage.Tenant;
            var tenantAttribute = MultiTenantHelpers.GetTenantAttributeFromCache();
            var viewModel = new ConfirmDialogFormViewModel(tenant.TenantID);
            return ViewDeleteTenantSquareLogoFileResource(viewModel, tenantAttribute);
        }

        [HttpPost]
        [SitkaAdminFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult DeleteTenantSquareLogoFileResource(ConfirmDialogFormViewModel viewModel)
        {
            var tenantAttribute = HttpRequestStorage.DatabaseEntities.AllTenantAttributes.Single(a => a.TenantID == HttpRequestStorage.DatabaseEntities.TenantID);
            if (!ModelState.IsValid)
            {
                return ViewDeleteTenantSquareLogoFileResource(viewModel, tenantAttribute);
            }

            var tenantAttributeTenantSquareLogoFileResource = tenantAttribute.TenantSquareLogoFileResourceInfo;
            var fileResourceDatas = tenantAttribute.TenantSquareLogoFileResourceInfo.FileResourceDatas;
            tenantAttribute.TenantSquareLogoFileResourceInfo.FileResourceDatas = null;
            tenantAttribute.TenantSquareLogoFileResourceInfo = null;
            foreach (var fileResourceData in fileResourceDatas)
            {
                fileResourceData.Delete(HttpRequestStorage.DatabaseEntities);
            }
            tenantAttributeTenantSquareLogoFileResource.Delete(HttpRequestStorage.DatabaseEntities);
            MultiTenantHelpers.ClearTenantAttributeCacheForAllTenants();
            return new ModalDialogFormJsonResult();
        }

        private PartialViewResult ViewDeleteTenantSquareLogoFileResource(ConfirmDialogFormViewModel viewModel, TenantAttribute tenantAttribute)
        {
            var confirmMessage = $"Are you sure you want to delete Tenant Square Logo for {tenantAttribute.TenantShortDisplayName}?";
            var viewData = new ConfirmDialogFormViewData(confirmMessage);
            return RazorPartialView<ConfirmDialogForm, ConfirmDialogFormViewData, ConfirmDialogFormViewModel>(viewData, viewModel);
        }

        [HttpGet]
        [SitkaAdminFeature]
        public PartialViewResult DeleteTenantStyleSheetFileResource()
        {
            var tenant = HttpRequestStorage.Tenant;
            var tenantAttribute = MultiTenantHelpers.GetTenantAttributeFromCache();
            var viewModel = new ConfirmDialogFormViewModel(tenant.TenantID);
            return ViewDeleteTenantStyleSheetFileResource(viewModel, tenantAttribute);
        }

        [HttpPost]
        [SitkaAdminFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult DeleteTenantStyleSheetFileResource(ConfirmDialogFormViewModel viewModel)
        {
            var tenantAttribute = HttpRequestStorage.DatabaseEntities.AllTenantAttributes.Single(a => a.TenantID == HttpRequestStorage.DatabaseEntities.TenantID);
            if (!ModelState.IsValid)
            {
                return ViewDeleteTenantStyleSheetFileResource(viewModel, tenantAttribute);
            }

            var tenantAttributeTenantStyleSheetFileResource = tenantAttribute.TenantStyleSheetFileResourceInfo;
            var fileResourceDatas = tenantAttribute.TenantStyleSheetFileResourceInfo.FileResourceDatas;
            tenantAttribute.TenantStyleSheetFileResourceInfo.FileResourceDatas = null;
            tenantAttribute.TenantStyleSheetFileResourceInfo = null;
            foreach (var fileResourceData in fileResourceDatas)
            {
                fileResourceData.Delete(HttpRequestStorage.DatabaseEntities);
            }
            tenantAttributeTenantStyleSheetFileResource.Delete(HttpRequestStorage.DatabaseEntities);
            MultiTenantHelpers.ClearTenantAttributeCacheForAllTenants();
            return new ModalDialogFormJsonResult();
        }

        private PartialViewResult ViewDeleteTenantStyleSheetFileResource(ConfirmDialogFormViewModel viewModel, TenantAttribute tenantAttribute)
        {
            var confirmMessage = $"Are you sure you want to delete Tenant Style Sheet for {tenantAttribute.TenantShortDisplayName}?";
            var viewData = new ConfirmDialogFormViewData(confirmMessage);
            return RazorPartialView<ConfirmDialogForm, ConfirmDialogFormViewData, ConfirmDialogFormViewModel>(viewData, viewModel);
        }

        private const string EditBoundingBoxFormID = "EditBoundingBoxForm";
    }
}
