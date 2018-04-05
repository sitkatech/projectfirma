/*-----------------------------------------------------------------------
<copyright file="TaxonomyTierTwoController.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Views.Map;
using ProjectFirma.Web.Views.Project;
using ProjectFirma.Web.Views.Shared.ProjectLocationControls;
using ProjectFirma.Web.Views.Shared;
using LtInfo.Common.Mvc;
using LtInfo.Common.MvcResults;
using ProjectFirma.Web.Views.PerformanceMeasure;
using ProjectFirma.Web.Views.Shared.SortOrder;
using DetailViewData = ProjectFirma.Web.Views.TaxonomyTierTwo.DetailViewData;
using Edit = ProjectFirma.Web.Views.TaxonomyTierTwo.Edit;
using EditViewData = ProjectFirma.Web.Views.TaxonomyTierTwo.EditViewData;
using EditViewModel = ProjectFirma.Web.Views.TaxonomyTierTwo.EditViewModel;
using Index = ProjectFirma.Web.Views.TaxonomyTierTwo.Index;
using IndexGridSpec = ProjectFirma.Web.Views.TaxonomyTierTwo.IndexGridSpec;
using IndexViewData = ProjectFirma.Web.Views.TaxonomyTierTwo.IndexViewData;
using Summary = ProjectFirma.Web.Views.TaxonomyTierTwo.Detail;

namespace ProjectFirma.Web.Controllers
{
    public class TaxonomyTierTwoController : FirmaBaseController
    {
        [TaxonomyTierTwoViewFeature]
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
            var firmaPage = FirmaPage.GetFirmaPageByPageType(FirmaPageType.TaxonomyTierTwoList);
            var viewData = new IndexViewData(CurrentPerson, firmaPage);
            return RazorView<Index, IndexViewData>(viewData);
        }

        [TaxonomyTierTwoViewFeature]
        public GridJsonNetJObjectResult<TaxonomyTierTwo> IndexGridJsonData()
        {
            var gridSpec = new IndexGridSpec(CurrentPerson);
            var taxonomyTierTwos = HttpRequestStorage.DatabaseEntities.TaxonomyTierTwos.ToList().OrderBy(x => x.TaxonomyTierTwoSortOrder).ToList();
            var gridJsonNetJObjectResult = new GridJsonNetJObjectResult<TaxonomyTierTwo>(taxonomyTierTwos, gridSpec);
            return gridJsonNetJObjectResult;
        }

        [TaxonomyTierTwoViewFeature]
        public ViewResult Detail(TaxonomyTierTwoPrimaryKey taxonomyTierTwoPrimaryKey)
        {
            var taxonomyTierTwo = taxonomyTierTwoPrimaryKey.EntityObject;
            var taxonomyTierTwoProjects = taxonomyTierTwo.GetAssociatedProjects(CurrentPerson).ToList();
            var visibleProjectsForUser = new List<IMappableProject>(taxonomyTierTwoProjects);

            var projectMapCustomization = new ProjectMapCustomization(ProjectLocationFilterType.TaxonomyTierTwo, new List<int> {taxonomyTierTwo.TaxonomyTierTwoID}, ProjectColorByType.ProjectStage);
            var projectLocationsLayerGeoJson = new LayerGeoJson($"{FieldDefinition.ProjectLocation.GetFieldDefinitionLabel()}", Project.MappedPointsToGeoJsonFeatureCollection(visibleProjectsForUser, true), "red", 1, LayerInitialVisibility.Show);
            var projectLocationsMapInitJson = new ProjectLocationsMapInitJson(projectLocationsLayerGeoJson, projectMapCustomization, "TaxonomyTierTwoProjectMap");

            var projectLocationsMapViewData = new ProjectLocationsMapViewData(projectLocationsMapInitJson.MapDivID, ProjectColorByType.ProjectStage.DisplayName, MultiTenantHelpers.GetTopLevelTaxonomyTiers(), CurrentPerson.CanViewProposals);

            var performanceMeasureChartViewDatas = taxonomyTierTwo.GetPerformanceMeasures().Select(x => new PerformanceMeasureChartViewData(x,
                    new List<int>(),
                    CurrentPerson,
                    false)).ToList();

            var viewData = new DetailViewData(CurrentPerson, taxonomyTierTwo, projectLocationsMapInitJson, projectLocationsMapViewData, performanceMeasureChartViewDatas);
            return RazorView<Summary, DetailViewData>(viewData);
        }

        [HttpGet]
        [TaxonomyTierTwoManageFeature]
        public PartialViewResult New()
        {
            var viewModel = new EditViewModel();
            return ViewNew(viewModel);
        }

        [HttpPost]
        [TaxonomyTierTwoManageFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult New(EditViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return ViewNew(viewModel);
            }
            var taxonomyTierTwo = new TaxonomyTierTwo(viewModel.TaxonomyTierThreeID, string.Empty);
            viewModel.UpdateModel(taxonomyTierTwo, CurrentPerson);
            HttpRequestStorage.DatabaseEntities.AllTaxonomyTierTwos.Add(taxonomyTierTwo);

            HttpRequestStorage.DatabaseEntities.SaveChanges();
            SetMessageForDisplay(string.Format("New {0} {1} successfully created!", FieldDefinition.TaxonomyTierTwo.GetFieldDefinitionLabel(), taxonomyTierTwo.GetDisplayNameAsUrl()));
            return new ModalDialogFormJsonResult();
        }

        [HttpGet]
        [TaxonomyTierTwoManageFeature]
        public PartialViewResult Edit(TaxonomyTierTwoPrimaryKey taxonomyTierTwoPrimaryKey)
        {
            var taxonomyTierTwo = taxonomyTierTwoPrimaryKey.EntityObject;
            var viewModel = new EditViewModel(taxonomyTierTwo);
            return ViewEdit(viewModel, taxonomyTierTwo.TaxonomyTierThree.DisplayName);
        }

        [HttpPost]
        [TaxonomyTierTwoManageFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult Edit(TaxonomyTierTwoPrimaryKey taxonomyTierTwoPrimaryKey, EditViewModel viewModel)
        {
            var taxonomyTierTwo = taxonomyTierTwoPrimaryKey.EntityObject;
            if (!ModelState.IsValid)
            {
                return ViewEdit(viewModel, taxonomyTierTwo.TaxonomyTierThree.DisplayName);
            }
            viewModel.UpdateModel(taxonomyTierTwo, CurrentPerson);
            return new ModalDialogFormJsonResult();
        }

        private PartialViewResult ViewNew(EditViewModel viewModel)
        {
            return ViewEdit(viewModel, string.Empty);
        }

        private PartialViewResult ViewEdit(EditViewModel viewModel, string taxonomyTierThreeDisplayName)
        {
            var taxonomyTierThrees = HttpRequestStorage.DatabaseEntities.TaxonomyTierThrees.ToList()
                .OrderBy(x => x.DisplayName)
                .ToSelectList(x => x.TaxonomyTierThreeID.ToString(CultureInfo.InvariantCulture), x => x.DisplayName);
            var viewData = new EditViewData(taxonomyTierThrees, taxonomyTierThreeDisplayName);
            return RazorPartialView<Edit, EditViewData, EditViewModel>(viewData, viewModel);
        }

        [HttpGet]
        [TaxonomyTierTwoManageFeature]
        public PartialViewResult DeleteTaxonomyTierTwo(TaxonomyTierTwoPrimaryKey taxonomyTierTwoPrimaryKey)
        {
            var taxonomyTierTwo = taxonomyTierTwoPrimaryKey.EntityObject;
            var viewModel = new ConfirmDialogFormViewModel(taxonomyTierTwo.TaxonomyTierTwoID);
            return ViewDeleteTaxonomyTierTwo(taxonomyTierTwo, viewModel);
        }

        private PartialViewResult ViewDeleteTaxonomyTierTwo(TaxonomyTierTwo taxonomyTierTwo, ConfirmDialogFormViewModel viewModel)
        {
            var canDelete = !taxonomyTierTwo.HasDependentObjects() && HttpRequestStorage.DatabaseEntities.TaxonomyTierTwos.Count() > 1;
            var taxonomyTierTwoDisplayName = FieldDefinition.TaxonomyTierTwo.GetFieldDefinitionLabel();
            var confirmMessage = canDelete
                ? string.Format("Are you sure you want to delete this {0} '{1}'?", taxonomyTierTwoDisplayName, taxonomyTierTwo.DisplayName)
                : ConfirmDialogFormViewData.GetStandardCannotDeleteMessage(taxonomyTierTwoDisplayName, SitkaRoute<TaxonomyTierTwoController>.BuildLinkFromExpression(x => x.Detail(taxonomyTierTwo), "here"));

            var viewData = new ConfirmDialogFormViewData(confirmMessage, canDelete);
            return RazorPartialView<ConfirmDialogForm, ConfirmDialogFormViewData, ConfirmDialogFormViewModel>(viewData, viewModel);
        }

        [HttpPost]
        [TaxonomyTierTwoManageFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult DeleteTaxonomyTierTwo(TaxonomyTierTwoPrimaryKey taxonomyTierTwoPrimaryKey, ConfirmDialogFormViewModel viewModel)
        {
            var taxonomyTierTwo = taxonomyTierTwoPrimaryKey.EntityObject;
            if (!ModelState.IsValid)
            {
                return ViewDeleteTaxonomyTierTwo(taxonomyTierTwo, viewModel);
            }
            taxonomyTierTwo.DeleteTaxonomyTierTwo();
            return new ModalDialogFormJsonResult();
        }

        [TaxonomyTierTwoViewFeature]
        public GridJsonNetJObjectResult<Project> ProjectsGridJsonData(TaxonomyTierTwoPrimaryKey taxonomyTierTwoPrimaryKey)
        {
            var gridSpec = new BasicProjectInfoGridSpec(CurrentPerson, true);
            var projectTaxonomyTierTwos = taxonomyTierTwoPrimaryKey.EntityObject.GetAssociatedProjects(CurrentPerson);
            var gridJsonNetJObjectResult = new GridJsonNetJObjectResult<Project>(projectTaxonomyTierTwos, gridSpec);
            return gridJsonNetJObjectResult;
        }

        [TaxonomyTierTwoManageFeature]
        public PartialViewResult EditSortOrder()
        {
            var taxonomyTierTwos = HttpRequestStorage.DatabaseEntities.TaxonomyTierTwos;
            EditSortOrderViewModel viewModel = new EditSortOrderViewModel();
            return ViewEditSortOrder(taxonomyTierTwos, viewModel);
        }

        private PartialViewResult ViewEditSortOrder(IEnumerable<TaxonomyTierTwo> taxonomyTierTwos, EditSortOrderViewModel viewModel)
        {
            EditSortOrderViewData viewData = new EditSortOrderViewData(new List<IHaveASortOrder>(taxonomyTierTwos), FieldDefinition.TaxonomyTierTwo.GetFieldDefinitionLabelPluralized());
            return RazorPartialView<EditSortOrder, EditSortOrderViewData, EditSortOrderViewModel>(viewData, viewModel);
        }

        [HttpPost]
        [TaxonomyTierTwoManageFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult EditSortOrder(EditSortOrderViewModel viewModel)
        {
            var taxonomyTierTwos = HttpRequestStorage.DatabaseEntities.TaxonomyTierTwos;

            if (!ModelState.IsValid)
            {
                return ViewEditSortOrder(taxonomyTierTwos, viewModel);
            }

            viewModel.UpdateModel(new List<IHaveASortOrder>(taxonomyTierTwos));
            SetMessageForDisplay($"Successfully Updated {FieldDefinition.TaxonomyTierTwo.GetFieldDefinitionLabel()} Sort Order");
            return new ModalDialogFormJsonResult();
        }
    }
}
