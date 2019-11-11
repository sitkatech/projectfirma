/*-----------------------------------------------------------------------
<copyright file="TaxonomyBranchController.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
using ProjectFirma.Web.Views.Project;
using ProjectFirma.Web.Views.Shared.ProjectLocationControls;
using ProjectFirma.Web.Views.Shared;
using LtInfo.Common.Mvc;
using LtInfo.Common.MvcResults;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Views.PerformanceMeasure;
using ProjectFirma.Web.Views.Shared.SortOrder;
using DetailViewData = ProjectFirma.Web.Views.TaxonomyBranch.DetailViewData;
using Edit = ProjectFirma.Web.Views.TaxonomyBranch.Edit;
using EditViewData = ProjectFirma.Web.Views.TaxonomyBranch.EditViewData;
using EditViewModel = ProjectFirma.Web.Views.TaxonomyBranch.EditViewModel;
using Index = ProjectFirma.Web.Views.TaxonomyBranch.Index;
using IndexGridSpec = ProjectFirma.Web.Views.TaxonomyBranch.IndexGridSpec;
using IndexViewData = ProjectFirma.Web.Views.TaxonomyBranch.IndexViewData;
using Summary = ProjectFirma.Web.Views.TaxonomyBranch.Detail;

namespace ProjectFirma.Web.Controllers
{
    public class TaxonomyBranchController : FirmaBaseController
    {
        [TaxonomyBranchViewFeature]
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
            var firmaPage = FirmaPageTypeEnum.TaxonomyBranchList.GetFirmaPage();
            var viewData = new IndexViewData(CurrentFirmaSession, firmaPage);
            return RazorView<Index, IndexViewData>(viewData);
        }

        [TaxonomyBranchViewFeature]
        public GridJsonNetJObjectResult<TaxonomyBranch> IndexGridJsonData()
        {
            var gridSpec = new IndexGridSpec(CurrentFirmaSession);
            var taxonomyBranches = HttpRequestStorage.DatabaseEntities.TaxonomyBranches.ToList().OrderTaxonomyBranches().ToList();
            var gridJsonNetJObjectResult = new GridJsonNetJObjectResult<TaxonomyBranch>(taxonomyBranches, gridSpec);
            return gridJsonNetJObjectResult;
        }

        [TaxonomyBranchViewFeature]
        public ViewResult Detail(TaxonomyBranchPrimaryKey taxonomyBranchPrimaryKey)
        {
            var taxonomyBranch = taxonomyBranchPrimaryKey.EntityObject;
            var taxonomyBranchProjects = taxonomyBranch.GetAssociatedProjects(CurrentFirmaSession.Person).ToList();

            var projectMapCustomization = new ProjectMapCustomization(ProjectLocationFilterType.TaxonomyBranch, new List<int> {taxonomyBranch.TaxonomyBranchID}, ProjectColorByType.ProjectStage);
            var projectLocationsLayerGeoJson = new LayerGeoJson($"{FieldDefinitionEnum.ProjectLocation.ToType().GetFieldDefinitionLabel()}", taxonomyBranchProjects.MappedPointsToGeoJsonFeatureCollection(true, true), "red", 1, LayerInitialVisibility.Show);
            var projectLocationsMapInitJson = new ProjectLocationsMapInitJson(projectLocationsLayerGeoJson, projectMapCustomization, "TaxonomyBranchProjectMap");
            var projectLocationsMapViewData = new ProjectLocationsMapViewData(projectLocationsMapInitJson.MapDivID, ProjectColorByType.ProjectStage.GetDisplayNameFieldDefinition(), MultiTenantHelpers.GetTopLevelTaxonomyTiers(), CurrentPerson.CanViewProposals());

            var associatePerformanceMeasureTaxonomyLevel = MultiTenantHelpers.GetAssociatePerformanceMeasureTaxonomyLevel();
            var canHaveAssociatedPerformanceMeasures = associatePerformanceMeasureTaxonomyLevel == TaxonomyLevel.Branch;
            var taxonomyTierPerformanceMeasures = taxonomyBranch.GetTaxonomyTierPerformanceMeasures();
            var relatedPerformanceMeasuresViewData = new RelatedPerformanceMeasuresViewData(associatePerformanceMeasureTaxonomyLevel, true, taxonomyTierPerformanceMeasures, canHaveAssociatedPerformanceMeasures);
            List<PerformanceMeasureChartViewData> performanceMeasureChartViewDatas = null;
            if (canHaveAssociatedPerformanceMeasures)
            {
                performanceMeasureChartViewDatas = taxonomyTierPerformanceMeasures.Select(x => new PerformanceMeasureChartViewData(x.Key, CurrentFirmaSession, false, new List<Project>())).ToList();
            }

            var taxonomyLevel = MultiTenantHelpers.GetTaxonomyLevel();
            var projectCustomDefaultGridConfigurations = HttpRequestStorage.DatabaseEntities.ProjectCustomGridConfigurations.Where(x => x.IsEnabled && x.ProjectCustomGridTypeID == ProjectCustomGridType.Default.ProjectCustomGridTypeID).OrderBy(x => x.SortOrder).ToList();
            var viewData = new DetailViewData(CurrentFirmaSession, taxonomyBranch, projectLocationsMapInitJson, projectLocationsMapViewData, canHaveAssociatedPerformanceMeasures, relatedPerformanceMeasuresViewData, performanceMeasureChartViewDatas, taxonomyLevel, projectCustomDefaultGridConfigurations);
            return RazorView<Summary, DetailViewData>(viewData);
        }

        [HttpGet]
        [TaxonomyBranchManageFeature]
        public PartialViewResult New()
        {
            var viewModel = new EditViewModel();
            return ViewNew(viewModel);
        }

        [HttpPost]
        [TaxonomyBranchManageFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult New(EditViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return ViewNew(viewModel);
            }
            var taxonomyBranch = new TaxonomyBranch(viewModel.TaxonomyTrunkID, string.Empty);
            viewModel.UpdateModel(taxonomyBranch, CurrentFirmaSession);
            HttpRequestStorage.DatabaseEntities.AllTaxonomyBranches.Add(taxonomyBranch);

            HttpRequestStorage.DatabaseEntities.SaveChanges();
            SetMessageForDisplay(string.Format("New {0} {1} successfully created!", FieldDefinitionEnum.TaxonomyBranch.ToType().GetFieldDefinitionLabel(), taxonomyBranch.GetDisplayNameAsUrl()));
            return new ModalDialogFormJsonResult();
        }

        [HttpGet]
        [TaxonomyBranchManageFeature]
        public PartialViewResult Edit(TaxonomyBranchPrimaryKey taxonomyBranchPrimaryKey)
        {
            var taxonomyBranch = taxonomyBranchPrimaryKey.EntityObject;
            var viewModel = new EditViewModel(taxonomyBranch);
            return ViewEdit(viewModel, taxonomyBranch.TaxonomyTrunk.GetDisplayName());
        }

        [HttpPost]
        [TaxonomyBranchManageFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult Edit(TaxonomyBranchPrimaryKey taxonomyBranchPrimaryKey, EditViewModel viewModel)
        {
            var taxonomyBranch = taxonomyBranchPrimaryKey.EntityObject;
            if (!ModelState.IsValid)
            {
                return ViewEdit(viewModel, taxonomyBranch.TaxonomyTrunk.GetDisplayName());
            }
            viewModel.UpdateModel(taxonomyBranch, CurrentFirmaSession);
            return new ModalDialogFormJsonResult();
        }

        private PartialViewResult ViewNew(EditViewModel viewModel)
        {
            return ViewEdit(viewModel, string.Empty);
        }

        private PartialViewResult ViewEdit(EditViewModel viewModel, string taxonomyTrunkDisplayName)
        {
            var taxonomyTrunks = HttpRequestStorage.DatabaseEntities.TaxonomyTrunks.ToList()
                .OrderBy(x => x.GetDisplayName())
                .ToSelectList(x => x.TaxonomyTrunkID.ToString(CultureInfo.InvariantCulture), x => x.GetDisplayName());
            var viewData = new EditViewData(taxonomyTrunks, taxonomyTrunkDisplayName);
            return RazorPartialView<Edit, EditViewData, EditViewModel>(viewData, viewModel);
        }

        [HttpGet]
        [TaxonomyBranchManageFeature]
        public PartialViewResult DeleteTaxonomyBranch(TaxonomyBranchPrimaryKey taxonomyBranchPrimaryKey)
        {
            var taxonomyBranch = taxonomyBranchPrimaryKey.EntityObject;
            var viewModel = new ConfirmDialogFormViewModel(taxonomyBranch.TaxonomyBranchID);
            return ViewDeleteTaxonomyBranch(taxonomyBranch, viewModel);
        }

        private PartialViewResult ViewDeleteTaxonomyBranch(TaxonomyBranch taxonomyBranch, ConfirmDialogFormViewModel viewModel)
        {
            var canDelete = !taxonomyBranch.HasDependentObjects() && HttpRequestStorage.DatabaseEntities.TaxonomyBranches.Count() > 1;
            var taxonomyBranchDisplayName = FieldDefinitionEnum.TaxonomyBranch.ToType().GetFieldDefinitionLabel();
            var confirmMessage = canDelete
                ? string.Format("Are you sure you want to delete this {0} '{1}'?", taxonomyBranchDisplayName, taxonomyBranch.GetDisplayName())
                : ConfirmDialogFormViewData.GetStandardCannotDeleteMessage(taxonomyBranchDisplayName, SitkaRoute<TaxonomyBranchController>.BuildLinkFromExpression(x => x.Detail(taxonomyBranch), "here"));

            var viewData = new ConfirmDialogFormViewData(confirmMessage, canDelete);
            return RazorPartialView<ConfirmDialogForm, ConfirmDialogFormViewData, ConfirmDialogFormViewModel>(viewData, viewModel);
        }

        [HttpPost]
        [TaxonomyBranchManageFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult DeleteTaxonomyBranch(TaxonomyBranchPrimaryKey taxonomyBranchPrimaryKey, ConfirmDialogFormViewModel viewModel)
        {
            var taxonomyBranch = taxonomyBranchPrimaryKey.EntityObject;
            if (!ModelState.IsValid)
            {
                return ViewDeleteTaxonomyBranch(taxonomyBranch, viewModel);
            }
            taxonomyBranch.DeleteFull(HttpRequestStorage.DatabaseEntities);
            return new ModalDialogFormJsonResult();
        }

        [TaxonomyBranchManageFeature]
        public PartialViewResult EditSortOrder()
        {
            var taxonomyBranches = HttpRequestStorage.DatabaseEntities.TaxonomyBranches;
            var viewModel = new EditSortOrderViewModel();
            return ViewEditSortOrder(taxonomyBranches, viewModel);
        }

        private PartialViewResult ViewEditSortOrder(IEnumerable<TaxonomyBranch> taxonomyBranches, EditSortOrderViewModel viewModel)
        {
            var viewData = new EditSortOrderViewData(new List<IHaveASortOrder>(taxonomyBranches), FieldDefinitionEnum.TaxonomyBranch.ToType().GetFieldDefinitionLabelPluralized());
            return RazorPartialView<EditSortOrder, EditSortOrderViewData, EditSortOrderViewModel>(viewData, viewModel);
        }

        [HttpPost]
        [TaxonomyBranchManageFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult EditSortOrder(EditSortOrderViewModel viewModel)
        {
            var taxonomyBranches = HttpRequestStorage.DatabaseEntities.TaxonomyBranches;

            if (!ModelState.IsValid)
            {
                return ViewEditSortOrder(taxonomyBranches, viewModel);
            }

            viewModel.UpdateModel(new List<IHaveASortOrder>(taxonomyBranches));
            SetMessageForDisplay($"Successfully Updated {FieldDefinitionEnum.TaxonomyBranch.ToType().GetFieldDefinitionLabel()} Sort Order");
            return new ModalDialogFormJsonResult();
        }

        [TaxonomyBranchManageFeature]
        public PartialViewResult EditChildrenSortOrder(TaxonomyBranchPrimaryKey taxonomyBranchPrimaryKey)
        {
            var taxonomyLeafs = taxonomyBranchPrimaryKey.EntityObject.TaxonomyLeafs;
            var viewModel = new EditSortOrderViewModel();
            return ViewEditChildrenSortOrder(taxonomyLeafs, viewModel);
        }

        private PartialViewResult ViewEditChildrenSortOrder(ICollection<TaxonomyLeaf> taxonomyLeafss, EditSortOrderViewModel viewModel)
        {
            var viewData = new EditSortOrderViewData(new List<IHaveASortOrder>(taxonomyLeafss), FieldDefinitionEnum.TaxonomyBranch.ToType().GetFieldDefinitionLabelPluralized());
            return RazorPartialView<EditSortOrder, EditSortOrderViewData, EditSortOrderViewModel>(viewData, viewModel);
        }

        [HttpPost]
        [TaxonomyBranchManageFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult EditChildrenSortOrder(TaxonomyBranchPrimaryKey taxonomyBranchPrimaryKey, EditSortOrderViewModel viewModel)
        {
            var taxonomyLeafs = taxonomyBranchPrimaryKey.EntityObject.TaxonomyLeafs;

            if (!ModelState.IsValid)
            {
                return ViewEditChildrenSortOrder(taxonomyLeafs, viewModel);
            }

            viewModel.UpdateModel(new List<IHaveASortOrder>(taxonomyLeafs));
            SetMessageForDisplay($"Successfully Updated {FieldDefinitionEnum.TaxonomyBranch.ToType().GetFieldDefinitionLabel()} Sort Order");
            return new ModalDialogFormJsonResult();
        }
    }
}
