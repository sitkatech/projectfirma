/*-----------------------------------------------------------------------
<copyright file="TaxonomyTrunkController.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
using ProjectFirma.Web.Views.Map;
using ProjectFirma.Web.Views.PerformanceMeasure;
using ProjectFirma.Web.Views.Shared;
using ProjectFirma.Web.Views.Shared.ProjectLocationControls;
using ProjectFirma.Web.Views.Shared.SortOrder;
using ProjectFirmaModels.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Detail = ProjectFirma.Web.Views.TaxonomyTrunk.Detail;
using DetailViewData = ProjectFirma.Web.Views.TaxonomyTrunk.DetailViewData;
using Edit = ProjectFirma.Web.Views.TaxonomyTrunk.Edit;
using EditViewData = ProjectFirma.Web.Views.TaxonomyTrunk.EditViewData;
using EditViewModel = ProjectFirma.Web.Views.TaxonomyTrunk.EditViewModel;
using Index = ProjectFirma.Web.Views.TaxonomyTrunk.Index;
using IndexGridSpec = ProjectFirma.Web.Views.TaxonomyTrunk.IndexGridSpec;
using IndexViewData = ProjectFirma.Web.Views.TaxonomyTrunk.IndexViewData;

namespace ProjectFirma.Web.Controllers
{
    public class TaxonomyTrunkController : FirmaBaseController
    {
        [TaxonomyTrunkViewFeature]
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
            var firmaPage = FirmaPageTypeEnum.TaxonomyTrunkList.GetFirmaPage();
            var viewData = new IndexViewData(CurrentFirmaSession, firmaPage);
            return RazorView<Index, IndexViewData>(viewData);
        }

        [TaxonomyTrunkViewFeature]
        public GridJsonNetJObjectResult<TaxonomyTrunk> IndexGridJsonData()
        {
            var gridSpec = new IndexGridSpec(CurrentFirmaSession);
            var taxonomyTrunks = HttpRequestStorage.DatabaseEntities.TaxonomyTrunks.ToList().SortByOrderThenName().ToList();
            var gridJsonNetJObjectResult = new GridJsonNetJObjectResult<TaxonomyTrunk>(taxonomyTrunks, gridSpec);
            return gridJsonNetJObjectResult;
        }

        [TaxonomyTrunkViewFeature]
        public ViewResult Detail(TaxonomyTrunkPrimaryKey taxonomyTrunkPrimaryKey)
        {
            var taxonomyTrunk = taxonomyTrunkPrimaryKey.EntityObject;
            var taxonomyTrunkProjects = taxonomyTrunk.GetAssociatedProjects(CurrentPerson).ToList();

            var projectMapCustomization = new ProjectMapCustomization(ProjectLocationFilterType.TaxonomyTrunk,
                new List<int> {taxonomyTrunk.TaxonomyTrunkID}, ProjectColorByType.ProjectStage);
            var projectLocationsLayerGeoJson =
                new LayerGeoJson($"{FieldDefinitionEnum.ProjectLocation.ToType().GetFieldDefinitionLabel()}",
                    taxonomyTrunkProjects.MappedPointsToGeoJsonFeatureCollection(true, true), "red", 1,
                    LayerInitialVisibility.Show);
            var projectLocationsMapInitJson = new ProjectLocationsMapInitJson(projectLocationsLayerGeoJson,
                projectMapCustomization, "TaxonomyTrunkProjectMap", false);

            var projectLocationsMapViewData = new ProjectLocationsMapViewData(projectLocationsMapInitJson.MapDivID,
                ProjectColorByType.ProjectStage.GetDisplayNameFieldDefinition(), MultiTenantHelpers.GetTopLevelTaxonomyTiers(),
                CurrentPerson.CanViewProposals());

            var associatePerformanceMeasureTaxonomyLevel =
                MultiTenantHelpers.GetAssociatePerformanceMeasureTaxonomyLevel();
            var canHaveAssociatedPerformanceMeasures = associatePerformanceMeasureTaxonomyLevel == TaxonomyLevel.Trunk;
            var taxonomyTierPerformanceMeasures = taxonomyTrunk.GetTaxonomyTierPerformanceMeasures();
            var relatedPerformanceMeasuresViewData = new RelatedPerformanceMeasuresViewData(
                associatePerformanceMeasureTaxonomyLevel, true, taxonomyTierPerformanceMeasures,
                canHaveAssociatedPerformanceMeasures);
            List<PerformanceMeasureChartViewData> performanceMeasureChartViewDatas = null;
            if (canHaveAssociatedPerformanceMeasures)
            {
                performanceMeasureChartViewDatas = taxonomyTierPerformanceMeasures.Select(x =>
                    new PerformanceMeasureChartViewData(x.Key, CurrentFirmaSession, false, new List<Project>())).ToList();
            }

            var taxonomyLevel = MultiTenantHelpers.GetTaxonomyLevel();
            var projectCustomDefaultGridConfigurations = HttpRequestStorage.DatabaseEntities.ProjectCustomGridConfigurations.Where(x => x.IsEnabled && x.ProjectCustomGridTypeID == ProjectCustomGridType.Default.ProjectCustomGridTypeID).OrderBy(x => x.SortOrder).ToList();
            var viewData = new DetailViewData(CurrentFirmaSession, taxonomyTrunk, projectLocationsMapInitJson,
                projectLocationsMapViewData, canHaveAssociatedPerformanceMeasures, relatedPerformanceMeasuresViewData,
                performanceMeasureChartViewDatas, taxonomyLevel, projectCustomDefaultGridConfigurations);
            return RazorView<Detail, DetailViewData>(viewData);
        }

        [HttpGet]
        [TaxonomyTrunkManageFeature]
        public PartialViewResult New()
        {
            var viewModel = new EditViewModel();
            return ViewEdit(viewModel);
        }

        [HttpPost]
        [TaxonomyTrunkManageFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult New(EditViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return ViewEdit(viewModel);
            }

            var taxonomyTrunk = new TaxonomyTrunk(string.Empty);
            viewModel.UpdateModel(taxonomyTrunk, CurrentFirmaSession);
            HttpRequestStorage.DatabaseEntities.AllTaxonomyTrunks.Add(taxonomyTrunk);

            HttpRequestStorage.DatabaseEntities.SaveChanges();
            SetMessageForDisplay(
                $"New {FieldDefinitionEnum.TaxonomyTrunk.ToType().GetFieldDefinitionLabel()} {taxonomyTrunk.GetDisplayNameAsUrl()} successfully created!");
            return new ModalDialogFormJsonResult();
        }

        [HttpGet]
        [TaxonomyTrunkManageFeature]
        public PartialViewResult Edit(TaxonomyTrunkPrimaryKey taxonomyTrunkPrimaryKey)

        {
            var taxonomyTrunk = taxonomyTrunkPrimaryKey.EntityObject;
            var viewModel = new EditViewModel(taxonomyTrunk);
            return ViewEdit(viewModel);
        }

        [HttpPost]
        [TaxonomyTrunkManageFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult Edit(TaxonomyTrunkPrimaryKey taxonomyTrunkPrimaryKey, EditViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return ViewEdit(viewModel);
            }

            var taxonomyTrunk = taxonomyTrunkPrimaryKey.EntityObject;
            viewModel.UpdateModel(taxonomyTrunk, CurrentFirmaSession);
            return new ModalDialogFormJsonResult();
        }

        private PartialViewResult ViewEdit(EditViewModel viewModel)
        {
            var viewData = new EditViewData();
            return RazorPartialView<Edit, EditViewData, EditViewModel>(viewData, viewModel);
        }

        [HttpGet]
        [TaxonomyTrunkManageFeature]
        public PartialViewResult DeleteTaxonomyTrunk(TaxonomyTrunkPrimaryKey taxonomyTrunkPrimaryKey)
        {
            var taxonomyTrunk = taxonomyTrunkPrimaryKey.EntityObject;
            var viewModel = new ConfirmDialogFormViewModel(taxonomyTrunk.TaxonomyTrunkID);
            return ViewDeleteTaxonomyTrunk(taxonomyTrunk, viewModel);
        }

        private PartialViewResult ViewDeleteTaxonomyTrunk(TaxonomyTrunk taxonomyTrunk,
            ConfirmDialogFormViewModel viewModel)
        {
            var canDelete = !taxonomyTrunk.HasDependentObjects() &&
                            HttpRequestStorage.DatabaseEntities.TaxonomyTrunks.Count() > 1;
            var taxonomyTrunkDisplayName = FieldDefinitionEnum.TaxonomyTrunk.ToType().GetFieldDefinitionLabel();
            var confirmMessage = canDelete
                ? string.Format("Are you sure you want to delete this {0} '{1}'?", taxonomyTrunkDisplayName,
                    taxonomyTrunk.GetDisplayName())
                : ConfirmDialogFormViewData.GetStandardCannotDeleteMessage(taxonomyTrunkDisplayName,
                    SitkaRoute<TaxonomyTrunkController>.BuildLinkFromExpression(x => x.Detail(taxonomyTrunk), "here"));

            var viewData = new ConfirmDialogFormViewData(confirmMessage, canDelete);
            return RazorPartialView<ConfirmDialogForm, ConfirmDialogFormViewData, ConfirmDialogFormViewModel>(viewData,
                viewModel);
        }

        [HttpPost]
        [TaxonomyTrunkManageFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult DeleteTaxonomyTrunk(TaxonomyTrunkPrimaryKey taxonomyTrunkPrimaryKey,
            ConfirmDialogFormViewModel viewModel)
        {
            var taxonomyTrunk = taxonomyTrunkPrimaryKey.EntityObject;
            if (!ModelState.IsValid)
            {
                return ViewDeleteTaxonomyTrunk(taxonomyTrunk, viewModel);
            }

            taxonomyTrunk.DeleteFull(HttpRequestStorage.DatabaseEntities);
            return new ModalDialogFormJsonResult();
        }

        [TaxonomyTrunkManageFeature]
        public PartialViewResult EditSortOrder()
        {
            var taxonomyTrunks = HttpRequestStorage.DatabaseEntities.TaxonomyTrunks;
            var viewModel = new EditSortOrderViewModel();
            return ViewEditSortOrder(taxonomyTrunks, viewModel);
        }

        private PartialViewResult ViewEditSortOrder(IEnumerable<TaxonomyTrunk> taxonomyTrunks, EditSortOrderViewModel viewModel)
        {
            var viewData = new EditSortOrderViewData(new List<IHaveASortOrder>(taxonomyTrunks), FieldDefinitionEnum.TaxonomyTrunk.ToType().GetFieldDefinitionLabelPluralized());
            return RazorPartialView<EditSortOrder, EditSortOrderViewData, EditSortOrderViewModel>(viewData, viewModel);
        }

        [HttpPost]
        [TaxonomyTrunkManageFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult EditSortOrder(EditSortOrderViewModel viewModel)
        {
            var taxonomyTrunks = HttpRequestStorage.DatabaseEntities.TaxonomyTrunks;

            if (!ModelState.IsValid)
            {
                return ViewEditSortOrder(taxonomyTrunks, viewModel);
            }

            viewModel.UpdateModel(new List<IHaveASortOrder>(taxonomyTrunks));
            SetMessageForDisplay(
                $"Successfully Updated {FieldDefinitionEnum.TaxonomyTrunk.ToType().GetFieldDefinitionLabel()} Sort Order");
            return new ModalDialogFormJsonResult();
        }

        [TaxonomyTrunkManageFeature]
        public PartialViewResult EditChildrenSortOrder(TaxonomyTrunkPrimaryKey taxonomyTrunkPrimaryKey)
        {
            var taxonomyBranches = taxonomyTrunkPrimaryKey.EntityObject.TaxonomyBranches;
            var viewModel = new EditSortOrderViewModel();
            return ViewEditChildrenSortOrder(taxonomyBranches, viewModel);
        }

        private PartialViewResult ViewEditChildrenSortOrder(ICollection<TaxonomyBranch> taxonomyBranches,
            EditSortOrderViewModel viewModel)
        {
            var viewData = new EditSortOrderViewData(new List<IHaveASortOrder>(taxonomyBranches), FieldDefinitionEnum.TaxonomyTrunk.ToType().GetFieldDefinitionLabelPluralized());
            return RazorPartialView<EditSortOrder, EditSortOrderViewData, EditSortOrderViewModel>(viewData, viewModel);
        }

        [HttpPost]
        [TaxonomyTrunkManageFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult EditChildrenSortOrder(TaxonomyTrunkPrimaryKey taxonomyTrunkPrimaryKey, EditSortOrderViewModel viewModel)
        {
            var taxonomyBranches = taxonomyTrunkPrimaryKey.EntityObject.TaxonomyBranches;

            if (!ModelState.IsValid)
            {
                return ViewEditChildrenSortOrder(taxonomyBranches, viewModel);
            }

            viewModel.UpdateModel(new List<IHaveASortOrder>(taxonomyBranches));
            SetMessageForDisplay($"Successfully Updated {FieldDefinitionEnum.TaxonomyTrunk.ToType().GetFieldDefinitionLabel()} Sort Order");
            return new ModalDialogFormJsonResult();
        }
    }
}
