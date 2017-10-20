/*-----------------------------------------------------------------------
<copyright file="WatershedController.cs" company="Tahoe Regional Planning Agency">
Copyright (c) Tahoe Regional Planning Agency. All rights reserved.
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
using ProjectFirma.Web.Views.Project;
using ProjectFirma.Web.Views.Results;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Security;
using ProjectFirma.Web.Security.Shared;
using ProjectFirma.Web.Views.Shared;
using ProjectFirma.Web.Views.Watershed;
using LtInfo.Common;
using LtInfo.Common.MvcResults;
using Detail = ProjectFirma.Web.Views.Watershed.Detail;
using DetailViewData = ProjectFirma.Web.Views.Watershed.DetailViewData;
using Index = ProjectFirma.Web.Views.Watershed.Index;
using IndexGridSpec = ProjectFirma.Web.Views.Watershed.IndexGridSpec;
using IndexViewData = ProjectFirma.Web.Views.Watershed.IndexViewData;

namespace ProjectFirma.Web.Controllers
{
    public class WatershedController : FirmaBaseController
    {
        [WatershedManageFeature]
        public ViewResult Manage()
        {
            return IndexImpl();
        }
        
        [WatershedViewFeature]
        public ViewResult Index()
        {
            return IndexImpl();
        }

        private ViewResult IndexImpl()
        {
            var firmaPage = FirmaPage.GetFirmaPageByPageType(FirmaPageType.WatershedsList);
            var mapInitJson = new MapInitJson("watershedIndex", 10, new List<LayerGeoJson>{Watershed.GetWatershedWmsLayerGeoJson("#59ACFF", 0.2m, LayerInitialVisibility.Show)}, BoundingBox.MakeNewDefaultBoundingBox());

            var viewData = new IndexViewData(CurrentPerson, firmaPage, mapInitJson);
            return RazorView<Index, IndexViewData>(viewData);
        }

        [WatershedViewFeature]
        public GridJsonNetJObjectResult<Watershed> IndexGridJsonData()
        {
            var gridSpec = new IndexGridSpec();
            var watersheds = HttpRequestStorage.DatabaseEntities.Watersheds.OrderBy(x => x.WatershedName).ToList();
            var gridJsonNetJObjectResult = new GridJsonNetJObjectResult<Watershed>(watersheds, gridSpec);
            return gridJsonNetJObjectResult;
        }

        [HttpGet]
        [WatershedManageFeature]
        public PartialViewResult New()
        {
            var viewModel = new EditViewModel();
            return ViewEdit(viewModel);
        }

        [HttpPost]
        [WatershedManageFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult New(EditViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return ViewEdit(viewModel);
            }
            var watershed = new Watershed(string.Empty);
            viewModel.UpdateModel(watershed, CurrentPerson);
            HttpRequestStorage.DatabaseEntities.AllWatersheds.Add(watershed);
            return new ModalDialogFormJsonResult();
        }

        [HttpGet]
        [WatershedManageFeature]
        public PartialViewResult Edit(WatershedPrimaryKey watershedPrimaryKey)
        {
            var watershed = watershedPrimaryKey.EntityObject;
            var viewModel = new EditViewModel(watershed);
            return ViewEdit(viewModel);
        }

        [HttpPost]
        [WatershedManageFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult Edit(WatershedPrimaryKey watershedPrimaryKey, EditViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return ViewEdit(viewModel);
            }
            var watershed = watershedPrimaryKey.EntityObject;
            viewModel.UpdateModel(watershed, CurrentPerson);
            return new ModalDialogFormJsonResult();
        }

        private PartialViewResult ViewEdit(EditViewModel viewModel)
        {
            var viewData = new EditViewData();
            return RazorPartialView<Edit, EditViewData, EditViewModel>(viewData, viewModel);
        }

        [WatershedViewFeature]
        public ViewResult Detail(WatershedPrimaryKey watershedPrimaryKey)
        {
            var watershed = watershedPrimaryKey.EntityObject;

            var mapDivID = $"watershed_{watershed.WatershedID}_Map";

            List<ProposedProject> watershedAssociatedProposedProjectsToShow;
            if (!IsCurrentUserAnonymous() && MultiTenantHelpers.IncludeProposedProjectsOnMap())
            {
                watershedAssociatedProposedProjectsToShow = watershed.AssociatedProposedProjects;
            }
            else
            {
                watershedAssociatedProposedProjectsToShow = new List<ProposedProject>();
            }

            var layers = Watershed.GetWatershedAndAssociatedProjectLayers(watershed, watershed.AssociatedProjects, watershedAssociatedProposedProjectsToShow);
            var mapInitJson = new MapInitJson(mapDivID, 10, layers, new BoundingBox(watershed.WatershedFeature));

            var projectFundingSourceExpenditures = watershed.AssociatedProjects.SelectMany(x => x.ProjectFundingSourceExpenditures.Where(y => y.FundingSource.Organization.OrganizationTypeID.HasValue));
            var organizationTypes = HttpRequestStorage.DatabaseEntities.OrganizationTypes.ToList();

            const string chartTitle = "Reported Expenditures By Funding Source Sector";
            var chartContainerID = chartTitle.Replace(" ", "");
            var googleChart = projectFundingSourceExpenditures.ToGoogleChart(x => x.FundingSource.Organization.OrganizationType.OrganizationTypeName,
                organizationTypes.Select(x => x.OrganizationTypeName).ToList(),
                x => x.FundingSource.Organization.OrganizationType.OrganizationTypeName,
                chartContainerID,
                chartTitle);

            var viewGoogleChartViewData = new ViewGoogleChartViewData(googleChart, chartTitle, 405, true);

            var performanceMeasures = watershed.ProjectWatersheds.Select(x => x.Project).Distinct().ToList()
                .Where(x => x.ProjectStage.ArePerformanceMeasuresReportable())
                .SelectMany(x => x.PerformanceMeasureActuals)
                .Select(x => x.PerformanceMeasure).Distinct()
                .OrderBy(x => x.PerformanceMeasureDisplayName)
                .ToList();

            var viewData = new DetailViewData(CurrentPerson, watershed, mapInitJson, viewGoogleChartViewData, performanceMeasures);
            return RazorView<Detail, DetailViewData>(viewData);
        }

        [HttpGet]
        [WatershedManageFeature]
        public PartialViewResult DeleteWatershed(WatershedPrimaryKey watershedPrimaryKey)
        {
            var watershed = watershedPrimaryKey.EntityObject;
            var viewModel = new ConfirmDialogFormViewModel(watershed.WatershedID);
            return ViewDeleteWatershed(watershed, viewModel);
        }

        private PartialViewResult ViewDeleteWatershed(Watershed watershed, ConfirmDialogFormViewModel viewModel)
        {
            var canDelete = !watershed.HasDependentObjects();
            var confirmMessage = canDelete
                ? $"Are you sure you want to delete this {FieldDefinition.Watershed.GetFieldDefinitionLabel()} '{watershed.WatershedName}'?"
                : ConfirmDialogFormViewData.GetStandardCannotDeleteMessage($"{FieldDefinition.Watershed.GetFieldDefinitionLabel()}", SitkaRoute<WatershedController>.BuildLinkFromExpression(x => x.Detail(watershed), "here"));

            var viewData = new ConfirmDialogFormViewData(confirmMessage, canDelete);
            return RazorPartialView<ConfirmDialogForm, ConfirmDialogFormViewData, ConfirmDialogFormViewModel>(viewData, viewModel);
        }

        [HttpPost]
        [WatershedManageFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult DeleteWatershed(WatershedPrimaryKey watershedPrimaryKey, ConfirmDialogFormViewModel viewModel)
        {
            var watershed = watershedPrimaryKey.EntityObject;
            if (!ModelState.IsValid)
            {
                return ViewDeleteWatershed(watershed, viewModel);
            }
            watershed.DeleteWatershed();
            return new ModalDialogFormJsonResult();
        }

        [WatershedViewFeature]
        public GridJsonNetJObjectResult<Project> ProjectsGridJsonData(WatershedPrimaryKey watershedPrimaryKey)
        {
            var gridSpec = new BasicProjectInfoGridSpec(CurrentPerson, false);
            var projectWatersheds = watershedPrimaryKey.EntityObject.AssociatedProjects.ToList();
            var gridJsonNetJObjectResult = new GridJsonNetJObjectResult<Project>(projectWatersheds, gridSpec);
            return gridJsonNetJObjectResult;
        }
        
        [AnonymousUnclassifiedFeature]
        public PartialViewResult MapTooltip(WatershedPrimaryKey watershedPrimaryKey)
        {
            var viewData = new MapTooltipViewData(CurrentPerson, watershedPrimaryKey.EntityObject);
            return RazorPartialView<MapTooltip, MapTooltipViewData>(viewData);
        }
    }
}
