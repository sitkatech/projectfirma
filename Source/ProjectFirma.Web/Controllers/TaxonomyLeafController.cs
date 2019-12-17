/*-----------------------------------------------------------------------
<copyright file="TaxonomyLeafController.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
using System.Globalization;
using System.Linq;
using System.Web.Mvc;
using ProjectFirma.Web.Security;
using ProjectFirma.Web.Common;
using ProjectFirmaModels.Models;
using ProjectFirma.Web.Views.Map;
using ProjectFirma.Web.Views.Shared.ProjectLocationControls;
using ProjectFirma.Web.Security.Shared;
using ProjectFirma.Web.Views.Shared;
using LtInfo.Common.Models;
using LtInfo.Common.Mvc;
using LtInfo.Common.MvcResults;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Views.PerformanceMeasure;
using ProjectFirma.Web.Views.Shared.SortOrder;
using ProjectFirma.Web.Views.TaxonomyLeaf;
using DetailViewData = ProjectFirma.Web.Views.TaxonomyLeaf.DetailViewData;
using Edit = ProjectFirma.Web.Views.TaxonomyLeaf.Edit;
using EditViewData = ProjectFirma.Web.Views.TaxonomyLeaf.EditViewData;
using EditViewModel = ProjectFirma.Web.Views.TaxonomyLeaf.EditViewModel;
using Index = ProjectFirma.Web.Views.TaxonomyLeaf.Index;
using IndexGridSpec = ProjectFirma.Web.Views.TaxonomyLeaf.IndexGridSpec;
using IndexViewData = ProjectFirma.Web.Views.TaxonomyLeaf.IndexViewData;
using Summary = ProjectFirma.Web.Views.TaxonomyLeaf.Detail;

namespace ProjectFirma.Web.Controllers
{
    public class TaxonomyLeafController : FirmaBaseController
    {
        [AnonymousUnclassifiedFeature]
        public ViewResult Index()
        {
            return IndexImpl();
        }

        [FirmaAdminFeature]
        public ViewResult Manage()
        {
            return IndexImpl();
        }

        private ViewResult IndexImpl()
        {
            var firmaPage = FirmaPageTypeEnum.TaxonomyLeafList.GetFirmaPage();
            var viewData = new IndexViewData(CurrentFirmaSession, firmaPage);
            return RazorView<Index, IndexViewData>(viewData);
        }

        [AnonymousUnclassifiedFeature]
        public GridJsonNetJObjectResult<TaxonomyLeaf> IndexGridJsonData()
        {
            var gridSpec = new IndexGridSpec(CurrentFirmaSession);
            var taxonomyLeafs = HttpRequestStorage.DatabaseEntities.TaxonomyLeafs.ToList().OrderTaxonomyLeaves().ToList();
            var gridJsonNetJObjectResult = new GridJsonNetJObjectResult<TaxonomyLeaf>(taxonomyLeafs, gridSpec);
            return gridJsonNetJObjectResult;
        }

        [AnonymousUnclassifiedFeature]
        public ViewResult Detail(TaxonomyLeafPrimaryKey taxonomyLeafPrimaryKey)
        {
            var taxonomyLeaf = taxonomyLeafPrimaryKey.EntityObject;
            var currentPersonCanViewProposals = CurrentPerson.CanViewProposals();

            var primaryTaxonomyLeafProjects = taxonomyLeaf.Projects.ToList()
                .GetActiveProjectsAndProposals(currentPersonCanViewProposals)
                .Where(x => x.ProjectStage.ShouldShowOnMap())
                .ToList();
            var secondaryTaxonomyLeafProjects = primaryTaxonomyLeafProjects.Union(
                    taxonomyLeaf.SecondaryProjectTaxonomyLeafs.Select(x => x.Project)
                        .ToList()
                        .GetActiveProjectsAndProposals(currentPersonCanViewProposals)
                        .Where(x => x.ProjectStage.ShouldShowOnMap()))
                .ToList();

            var primaryProjectMapCustomization = new ProjectMapCustomization(ProjectLocationFilterType.TaxonomyLeaf,
                new List<int> {taxonomyLeaf.TaxonomyLeafID}, ProjectColorByType.ProjectStage);
            var secondaryProjectMapCustomization = new ProjectMapCustomization(ProjectLocationFilterType.TaxonomyLeaf,
                secondaryTaxonomyLeafProjects.Select(x => x.TaxonomyLeafID).Union(new List<int> {taxonomyLeaf.TaxonomyLeafID}).ToList(),
                ProjectColorByType.ProjectStage);

            var primaryProjectLocationsLayerGeoJson =
                new LayerGeoJson($"{FieldDefinitionEnum.ProjectLocation.ToType().GetFieldDefinitionLabel()}",
                    primaryTaxonomyLeafProjects.MappedPointsToGeoJsonFeatureCollection(true, false), "red", 1,
                    LayerInitialVisibility.Show);
            var secondaryProjectLocationsLayerGeoJson =
                new LayerGeoJson($"{FieldDefinitionEnum.ProjectLocation.ToType().GetFieldDefinitionLabel()}",
                    secondaryTaxonomyLeafProjects.MappedPointsToGeoJsonFeatureCollection(true, false), "red", 1,
                    LayerInitialVisibility.Show);
            var primaryProjectLocationsMapInitJson = new ProjectLocationsMapInitJson(primaryProjectLocationsLayerGeoJson,
                primaryProjectMapCustomization, "TaxonomyLeafProjectMap", false);
            var secondaryProjectLocationsMapInitJson = new ProjectLocationsMapInitJson(secondaryProjectLocationsLayerGeoJson,
                secondaryProjectMapCustomization, "SecondaryTaxonomyLeafProjectMap", false);
            var primaryProjectLocationsMapViewData = new ProjectLocationsMapViewData(primaryProjectLocationsMapInitJson.MapDivID,
                ProjectColorByType.ProjectStage.GetDisplayNameFieldDefinition(), MultiTenantHelpers.GetTopLevelTaxonomyTiers(),
                CurrentPerson.CanViewProposals());
            var secondaryProjectLocationsMapViewData = new ProjectLocationsMapViewData(secondaryProjectLocationsMapInitJson.MapDivID,
                ProjectColorByType.ProjectStage.GetDisplayNameFieldDefinition(), MultiTenantHelpers.GetTopLevelTaxonomyTiers(),
                CurrentPerson.CanViewProposals());

            var associatePerformanceMeasureTaxonomyLevel =
                MultiTenantHelpers.GetAssociatePerformanceMeasureTaxonomyLevel();
            var canHaveAssociatedPerformanceMeasures = associatePerformanceMeasureTaxonomyLevel == TaxonomyLevel.Leaf;
            var taxonomyTierPerformanceMeasures = taxonomyLeaf.GetTaxonomyTierPerformanceMeasures();
            var relatedPerformanceMeasuresViewData = new RelatedPerformanceMeasuresViewData(
                associatePerformanceMeasureTaxonomyLevel, true, taxonomyTierPerformanceMeasures,
                canHaveAssociatedPerformanceMeasures);

            var taxonomyLevel = MultiTenantHelpers.GetTaxonomyLevel();
            var tenantAttribute = MultiTenantHelpers.GetTenantAttribute();

            var performanceMeasures = taxonomyLeaf.TaxonomyLeafPerformanceMeasures.Select(x => x.PerformanceMeasure)
                .ToList();
            var primaryPerformanceMeasureChartViewDataByPerformanceMeasure = performanceMeasures.ToDictionary(
                x => x.PerformanceMeasureID,
                x => new PerformanceMeasureChartViewData(x, CurrentFirmaSession, false, primaryTaxonomyLeafProjects, $"primary{x.GetJavascriptSafeChartUniqueName()}"));
            var secondaryPerformanceMeasureChartViewDataByPerformanceMeasure = performanceMeasures.ToDictionary(
                x => x.PerformanceMeasureID,
                x => new PerformanceMeasureChartViewData(x, CurrentFirmaSession, false, secondaryTaxonomyLeafProjects, $"secondary{x.GetJavascriptSafeChartUniqueName()}"));

            var projectCustomDefaultGridConfigurations = HttpRequestStorage.DatabaseEntities.ProjectCustomGridConfigurations.Where(x => x.IsEnabled && x.ProjectCustomGridTypeID == ProjectCustomGridType.Default.ProjectCustomGridTypeID).OrderBy(x => x.SortOrder).ToList();

            var viewData = new DetailViewData(CurrentFirmaSession, taxonomyLeaf, primaryProjectLocationsMapInitJson,
                secondaryProjectLocationsMapInitJson, primaryProjectLocationsMapViewData,
                secondaryProjectLocationsMapViewData, canHaveAssociatedPerformanceMeasures,
                relatedPerformanceMeasuresViewData, taxonomyLevel, tenantAttribute, performanceMeasures,
                primaryPerformanceMeasureChartViewDataByPerformanceMeasure,
                secondaryPerformanceMeasureChartViewDataByPerformanceMeasure,
                projectCustomDefaultGridConfigurations);

            return RazorView<Summary, DetailViewData>(viewData);
        }

        [HttpGet]
        [TaxonomyLeafManageFeature]
        public PartialViewResult New()
        {
            var viewModel = new EditViewModel();
            return ViewNew(viewModel);
        }

        [HttpPost]
        [TaxonomyLeafManageFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult New(EditViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return ViewNew(viewModel);
            }

            var taxonomyLeaf = new TaxonomyLeaf(viewModel.TaxonomyBranchID, string.Empty);
            viewModel.UpdateModel(taxonomyLeaf, CurrentFirmaSession);
            HttpRequestStorage.DatabaseEntities.AllTaxonomyLeafs.Add(taxonomyLeaf);
            HttpRequestStorage.DatabaseEntities.SaveChanges();

            // we need to add this new leaf as a TaxonomyLeafPerformanceMeasure record if it's branch or trunk are currently associated to a PM
            var associatePerformanceMeasureTaxonomyLevel = MultiTenantHelpers.GetAssociatePerformanceMeasureTaxonomyLevel();
            if (associatePerformanceMeasureTaxonomyLevel == TaxonomyLevel.Branch)
            {
                var leaves =
                    HttpRequestStorage.DatabaseEntities.TaxonomyLeafs.Where(x =>
                        x.TaxonomyBranchID == taxonomyLeaf.TaxonomyBranchID).Select(x => x.TaxonomyLeafID).ToList();
                var taxonomyLeafPerformanceMeasuresGroupedByPerformanceMeasure = HttpRequestStorage.DatabaseEntities.TaxonomyLeafPerformanceMeasures
                    .Where(x => leaves.Contains(x.TaxonomyLeafID)).ToList().GroupBy(x => x.PerformanceMeasure, new HavePrimaryKeyComparer<PerformanceMeasure>());
                var taxonomyLeafPerformanceMeasures = taxonomyLeafPerformanceMeasuresGroupedByPerformanceMeasure.Select(x =>
                    new TaxonomyLeafPerformanceMeasure(taxonomyLeaf, x.Key));
            }
            else if (associatePerformanceMeasureTaxonomyLevel == TaxonomyLevel.Trunk)
            {
                var taxonomyBranch = HttpRequestStorage.DatabaseEntities.TaxonomyBranches.GetTaxonomyBranch(taxonomyLeaf.TaxonomyBranchID);
                var leaves = taxonomyBranch.TaxonomyTrunk.TaxonomyBranches.SelectMany(x => x.TaxonomyLeafs.Select(y => y.TaxonomyLeafID)).ToList();
                var taxonomyLeafPerformanceMeasuresGroupedByPerformanceMeasure = HttpRequestStorage.DatabaseEntities.TaxonomyLeafPerformanceMeasures
                    .Where(x => leaves.Contains(x.TaxonomyLeafID)).ToList().GroupBy(x => x.PerformanceMeasure, new HavePrimaryKeyComparer<PerformanceMeasure>());
                var taxonomyLeafPerformanceMeasures = taxonomyLeafPerformanceMeasuresGroupedByPerformanceMeasure.Select(x =>
                    new TaxonomyLeafPerformanceMeasure(taxonomyLeaf, x.Key));
            }
            SetMessageForDisplay($"New {FieldDefinitionEnum.TaxonomyLeaf.ToType().GetFieldDefinitionLabel()} {taxonomyLeaf.GetDisplayNameAsUrl()} successfully created!");
            return new ModalDialogFormJsonResult();
        }

        [HttpGet]
        [TaxonomyLeafManageFeature]
        public PartialViewResult Edit(TaxonomyLeafPrimaryKey taxonomyLeafPrimaryKey)
        {
            var taxonomyLeaf = taxonomyLeafPrimaryKey.EntityObject;
            var viewModel = new EditViewModel(taxonomyLeaf);
            return ViewEdit(viewModel, taxonomyLeaf.TaxonomyBranch.GetDisplayName());
        }

        [HttpPost]
        [TaxonomyLeafManageFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult Edit(TaxonomyLeafPrimaryKey taxonomyLeafPrimaryKey, EditViewModel viewModel)
        {
            var taxonomyLeaf = taxonomyLeafPrimaryKey.EntityObject;
            if (!ModelState.IsValid)
            {
                return ViewEdit(viewModel, taxonomyLeaf.TaxonomyBranch.GetDisplayName());
            }

            viewModel.UpdateModel(taxonomyLeaf, CurrentFirmaSession);
            return new ModalDialogFormJsonResult();
        }

        private PartialViewResult ViewNew(EditViewModel viewModel)
        {
            return ViewEdit(viewModel, string.Empty);
        }

        private PartialViewResult ViewEdit(EditViewModel viewModel, string taxonomyBranchDisplayName)
        {
            var taxonomyBranches = HttpRequestStorage.DatabaseEntities.TaxonomyBranches.ToList()
                .OrderBy(x => x.GetDisplayName())
                .ToSelectList(x => x.TaxonomyBranchID.ToString(CultureInfo.InvariantCulture), x => x.GetDisplayName());
            var viewData = new EditViewData(taxonomyBranches, taxonomyBranchDisplayName);
            return RazorPartialView<Edit, EditViewData, EditViewModel>(viewData, viewModel);
        }

        [HttpGet]
        [TaxonomyLeafManageFeature]
        public PartialViewResult DeleteTaxonomyLeaf(TaxonomyLeafPrimaryKey taxonomyLeafPrimaryKey)
        {
            var taxonomyLeaf = taxonomyLeafPrimaryKey.EntityObject;
            var viewModel = new ConfirmDialogFormViewModel(taxonomyLeaf.TaxonomyLeafID);
            return ViewDeleteTaxonomyLeaf(taxonomyLeaf, viewModel);
        }

        private PartialViewResult ViewDeleteTaxonomyLeaf(TaxonomyLeaf taxonomyLeaf,
            ConfirmDialogFormViewModel viewModel)
        {
            var canDelete = !taxonomyLeaf.HasDependentObjects() &&
                            HttpRequestStorage.DatabaseEntities.TaxonomyLeafs.Count() > 1;
            var taxonomyLeafDisplayName = FieldDefinitionEnum.TaxonomyLeaf.ToType().GetFieldDefinitionLabel();
            var confirmMessage = canDelete
                ? string.Format("Are you sure you want to delete this {0} '{1}'?", taxonomyLeafDisplayName,
                    taxonomyLeaf.GetDisplayName())
                : ConfirmDialogFormViewData.GetStandardCannotDeleteMessage(taxonomyLeafDisplayName,
                    SitkaRoute<TaxonomyLeafController>.BuildLinkFromExpression(x => x.Detail(taxonomyLeaf), "here"));

            var viewData = new ConfirmDialogFormViewData(confirmMessage, canDelete);
            return RazorPartialView<ConfirmDialogForm, ConfirmDialogFormViewData, ConfirmDialogFormViewModel>(viewData,
                viewModel);
        }

        [HttpPost]
        [TaxonomyLeafManageFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult DeleteTaxonomyLeaf(TaxonomyLeafPrimaryKey taxonomyLeafPrimaryKey,
            ConfirmDialogFormViewModel viewModel)
        {
            var taxonomyLeaf = taxonomyLeafPrimaryKey.EntityObject;
            if (!ModelState.IsValid)
            {
                return ViewDeleteTaxonomyLeaf(taxonomyLeaf, viewModel);
            }

            taxonomyLeaf.DeleteFull(HttpRequestStorage.DatabaseEntities);
            return new ModalDialogFormJsonResult();
        }

        [TaxonomyLeafViewFeature]
        public GridJsonNetJObjectResult<Project> SecondaryProjectsGridJsonData(TaxonomyLeafPrimaryKey taxonomyLeafPrimaryKey)
        {
            var taxonomyLeaf = taxonomyLeafPrimaryKey.EntityObject;
            var projectTaxonomyLeafs = taxonomyLeaf.GetAssociatedPrimaryAndSecondaryProjects(CurrentFirmaSession);
            var gridSpec = new ProjectForTaxonomyLeafGridSpec(CurrentFirmaSession, true, taxonomyLeaf);
            return new GridJsonNetJObjectResult<Project>(projectTaxonomyLeafs, gridSpec);
        }

        [TaxonomyLeafManageFeature]
        public PartialViewResult EditSortOrder()
        {
            var taxonomyLeafs = HttpRequestStorage.DatabaseEntities.TaxonomyLeafs;
            EditSortOrderViewModel viewModel = new EditSortOrderViewModel();
            return ViewEditSortOrder(taxonomyLeafs, viewModel);
        }

        private PartialViewResult ViewEditSortOrder(IEnumerable<TaxonomyLeaf> taxonomyLeafs,
            EditSortOrderViewModel viewModel)
        {
            EditSortOrderViewData viewData = new EditSortOrderViewData(new List<IHaveASortOrder>(taxonomyLeafs),
                FieldDefinitionEnum.TaxonomyLeaf.ToType().GetFieldDefinitionLabelPluralized());
            return RazorPartialView<EditSortOrder, EditSortOrderViewData, EditSortOrderViewModel>(viewData, viewModel);
        }

        [HttpPost]
        [TaxonomyLeafManageFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult EditSortOrder(EditSortOrderViewModel viewModel)
        {
            var taxonomyLeafs = HttpRequestStorage.DatabaseEntities.TaxonomyLeafs;

            if (!ModelState.IsValid)
            {
                return ViewEditSortOrder(taxonomyLeafs, viewModel);
            }

            viewModel.UpdateModel(new List<IHaveASortOrder>(taxonomyLeafs));
            SetMessageForDisplay(
                $"Successfully Updated {FieldDefinitionEnum.TaxonomyLeaf.ToType().GetFieldDefinitionLabel()} Sort Order");
            return new ModalDialogFormJsonResult();
        }
    }
}
