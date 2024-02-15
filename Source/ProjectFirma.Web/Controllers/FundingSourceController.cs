﻿/*-----------------------------------------------------------------------
<copyright file="FundingSourceController.cs" company="Tahoe Regional Planning Agency and Environmental Science Associates">
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
using LtInfo.Common.Models;
using LtInfo.Common.Mvc;
using LtInfo.Common.MvcResults;
using MoreLinq;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Security;
using ProjectFirma.Web.Views.FundingSource;
using ProjectFirma.Web.Views.FundingSourceCustomAttributes;
using ProjectFirma.Web.Views.Shared;
using ProjectFirma.Web.Views.Shared.SortOrder;
using ProjectFirmaModels.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Spatial;
using System.Globalization;
using System.Linq;
using System.Web.Mvc;
using GeoJSON.Net.Feature;
using Detail = ProjectFirma.Web.Views.FundingSource.Detail;
using DetailViewData = ProjectFirma.Web.Views.FundingSource.DetailViewData;
using Edit = ProjectFirma.Web.Views.FundingSource.Edit;
using EditViewData = ProjectFirma.Web.Views.FundingSource.EditViewData;
using EditViewModel = ProjectFirma.Web.Views.FundingSource.EditViewModel;
using Index = ProjectFirma.Web.Views.FundingSource.Index;
using IndexGridSpec = ProjectFirma.Web.Views.FundingSource.IndexGridSpec;
using IndexViewData = ProjectFirma.Web.Views.FundingSource.IndexViewData;

namespace ProjectFirma.Web.Controllers
{
    public class FundingSourceController : FirmaBaseController
    {
        [FundingSourceViewFeature]
        public ViewResult Index()
        {
            var firmaPage = FirmaPageTypeEnum.FundingSourcesList.GetFirmaPage();
            var fundingSourceCustomAttributeTypes = HttpRequestStorage.DatabaseEntities.FundingSourceCustomAttributeTypes.ToList();
            var viewData = new IndexViewData(CurrentFirmaSession, firmaPage, fundingSourceCustomAttributeTypes);
            return RazorView<Index, IndexViewData>(viewData);
        }

        [FundingSourceViewFeature]
        public GridJsonNetJObjectResult<FundingSource> IndexGridJsonData()
        {
            var fundingSourceCustomAttributeTypes = HttpRequestStorage.DatabaseEntities.FundingSourceCustomAttributeTypes.ToList();
           
            var gridSpec = new IndexGridSpec(CurrentFirmaSession, fundingSourceCustomAttributeTypes);
            var fundingSources = HttpRequestStorage.DatabaseEntities.FundingSources
                .Include(x => x.Organization)
                .ToList()
                .OrderBy(ht => ht.GetDisplayName()).ToList();
            var gridJsonNetJObjectResult = new GridJsonNetJObjectResult<FundingSource>(fundingSources, gridSpec);
            return gridJsonNetJObjectResult;
        }

        [HttpGet]
        [FundingSourceCreateFeature]
        public PartialViewResult New()
        {
            var viewModel = new EditViewModel
            {
                // If the person is not an admin, we want to default the Funding Source organization to their own Organization
                OrganizationID = new List<Role> {Role.Admin, Role.ESAAdmin}.Any(x => x.RoleID == CurrentPerson.RoleID)
                    ? (int?) null
                    : CurrentPerson.OrganizationID,
                IsActive = true
            };

            return ViewEdit(viewModel);
        }

        [HttpPost]
        [FundingSourceCreateFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult New(EditViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return ViewEdit(viewModel);
            }
            var fundingSource = new FundingSource(
                viewModel.OrganizationID ?? ModelObjectHelpers.NotYetAssignedID, // Should never be null due to View Model validation
                string.Empty,
                true);

            viewModel.UpdateModel(fundingSource, CurrentFirmaSession);
            HttpRequestStorage.DatabaseEntities.AllFundingSources.Add(fundingSource);
            HttpRequestStorage.DatabaseEntities.SaveChanges();
            SetMessageForDisplay($"{FieldDefinitionEnum.FundingSource.ToType().GetFieldDefinitionLabel()} {fundingSource.GetDisplayName()} successfully created.");

            return new ModalDialogFormJsonResult();
        }

        [HttpGet]
        [FundingSourceEditFeature]
        public PartialViewResult Edit(FundingSourcePrimaryKey fundingSourcePrimaryKey)
        {
            var fundingSource = fundingSourcePrimaryKey.EntityObject;
            var viewModel = new EditViewModel(fundingSource);
            return ViewEdit(viewModel);
        }

        [HttpPost]
        [FundingSourceEditFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult Edit(FundingSourcePrimaryKey fundingSourcePrimaryKey, EditViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return ViewEdit(viewModel);
            }
            var fundingSource = fundingSourcePrimaryKey.EntityObject;
            viewModel.UpdateModel(fundingSource, CurrentFirmaSession);
            return new ModalDialogFormJsonResult();
        }

        private PartialViewResult ViewEdit(EditViewModel viewModel)
        {
            var organizationsAsSelectListItems =
                HttpRequestStorage.DatabaseEntities.Organizations.GetActiveOrganizations()
                    .ToSelectListWithEmptyFirstRow(x => x.OrganizationID.ToString(CultureInfo.InvariantCulture), x => x.OrganizationName);
            var viewData = new EditViewData(organizationsAsSelectListItems, CurrentFirmaSession);
            return RazorPartialView<Edit, EditViewData, EditViewModel>(viewData, viewModel);
        }

        [FundingSourceViewFeature]
        public ViewResult Detail(FundingSourcePrimaryKey fundingSourcePrimaryKey)
        {
            var fundingSource = fundingSourcePrimaryKey.EntityObject;
            var taxonomyTrunks = HttpRequestStorage.DatabaseEntities.TaxonomyTrunks.ToList().SortByOrderThenName().ToList();

            const string chartTitle = "Reported Expenditures";
            var chartContainerID = chartTitle.Replace(" ", "");

            // If ProjectFundingSourceExpenditures is empty, ToGoogleChart returns null...
            var googleChart = fundingSource.ProjectFundingSourceExpenditures
                .ToGoogleChart(x => x.Project.TaxonomyLeaf.TaxonomyBranch.TaxonomyTrunk.GetDisplayName(),
                    taxonomyTrunks.Select(x => x.GetDisplayName()).ToList(),
                    x => x.Project.TaxonomyLeaf.TaxonomyBranch.TaxonomyTrunk.GetDisplayName(),
                    chartContainerID,
                    fundingSource.GetDisplayName(),
                    null);

            googleChart?.GoogleChartConfiguration.Legend.SetLegendPosition(GoogleChartLegendPosition.None);

            var projectFundingSourceBudgetGridSpec = new ProjectFundingSourceBudgetGridSpec()
            {
                ObjectNameSingular = $"{FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()}",
                ObjectNamePlural = $"{FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabelPluralized()}",
                SaveFiltersInCookie = true
            };

            var viewGoogleChartViewData = new ViewGoogleChartViewData(googleChart, chartTitle, 350, false);

            var fundingSourceCustomAttributeTypes = HttpRequestStorage.DatabaseEntities.FundingSourceCustomAttributeTypes.ToList().Where(x => x.HasViewPermission(CurrentFirmaSession));
            var projectCustomAttributeTypesViewData = new DisplayFundingSourceCustomAttributesViewData(
                fundingSourceCustomAttributeTypes.ToList(),
                new List<FundingSourceCustomAttribute>(fundingSource.FundingSourceCustomAttributes.ToList()));

            var mapInitJson = GetMapInitJson(fundingSource, CurrentFirmaSession);
            var projectLocationsLayerGeoJson = GetProjectLocationsLayerGeoJson(fundingSource, CurrentFirmaSession, out var hasSpatialData);

            var performanceMeasures = fundingSource.GetAssociatedProjects(CurrentFirmaSession).ToList()
                .SelectMany(x => x.PerformanceMeasureActuals)
                .Select(x => x.PerformanceMeasure).Distinct(new HavePrimaryKeyComparer<PerformanceMeasure>())
                .OrderBy(x => x.PerformanceMeasureDisplayName)
                .ToList();

            var viewData = new DetailViewData(CurrentFirmaSession, fundingSource, viewGoogleChartViewData,
                projectFundingSourceBudgetGridSpec, projectCustomAttributeTypesViewData, mapInitJson,
                projectLocationsLayerGeoJson, hasSpatialData, performanceMeasures);

            return RazorView<Detail, DetailViewData>(viewData);
        }

        private static LayerGeoJson GetProjectLocationsLayerGeoJson(FundingSource fundingSource, FirmaSession currentFirmaSession, out bool hasSpatialData)
        {
            var allActiveProjectsAndProposals = fundingSource.GetAssociatedProjects(currentFirmaSession).Where(x => x.ProjectStage.ShouldShowOnMap()).ToList();
            hasSpatialData = false;

            var projectsAsSimpleLocations = allActiveProjectsAndProposals.Where(x => !x.LocationIsPrivate).
                Where(x => x.ProjectLocationSimpleType != ProjectLocationSimpleType.None).ToList();
            hasSpatialData = projectsAsSimpleLocations.Any();
            var projectSimpleLocationsFeatureCollection = new FeatureCollection();
            projectSimpleLocationsFeatureCollection.Features.AddRange(projectsAsSimpleLocations.Select(x =>
            {
                var feature = x.MakePointFeatureWithRelevantProperties(x.GetProjectLocationPoint(true), true, true);
                feature.Properties["FeatureColor"] = "#99b3ff";
                return feature;
            }).ToList());

            // Always return the feature collection - even if empty.
            // SLG - 8/28/2020
            return new LayerGeoJson($"Mapped {FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabelPluralized()}", projectSimpleLocationsFeatureCollection, "blue", 1, LayerInitialVisibility.LayerInitialVisibilityEnum.Show);
        }

        private static MapInitJson GetMapInitJson(FundingSource fundingSource, FirmaSession currentFirmaSession)
        {
            var layers = new List<LayerGeoJson>();
            var dbGeometries = new List<DbGeometry>();

            layers.AddRange(MapInitJson.GetConfiguredGeospatialAreaMapLayers());

            var allActiveProjectsAndProposals = fundingSource.GetAssociatedProjects(currentFirmaSession).Where(x => x.ProjectStage.ShouldShowOnMap()).ToList();

            var filteredProjects = allActiveProjectsAndProposals.Where(x => x.ProjectLocationSimpleType != ProjectLocationSimpleType.None).ToList();

            dbGeometries.AddRange(filteredProjects.Where(currentFirmaSession.UserCanViewPrivateLocations).Select(p => p.GetProjectLocationPoint(true)));

            var boundingBox = new BoundingBox(dbGeometries);

            return new MapInitJson($"fundingSource_{fundingSource.FundingSourceID}_Map", 10, layers, MapInitJson.GetExternalMapLayerSimples(), boundingBox);
        }

        [HttpGet]
        [FundingSourceDeleteFeature]
        public PartialViewResult DeleteFundingSource(FundingSourcePrimaryKey fundingSourcePrimaryKey)
        {
            var fundingSource = fundingSourcePrimaryKey.EntityObject;
            var viewModel = new ConfirmDialogFormViewModel(fundingSource.FundingSourceID);
            return ViewDeleteFundingSource(fundingSource, viewModel);
        }

        private PartialViewResult ViewDeleteFundingSource(FundingSource fundingSource, ConfirmDialogFormViewModel viewModel)
        {
            var numberOfProjectsAssociated = fundingSource.GetAssociatedProjects(CurrentFirmaSession).Count;
            var confirmMessage = numberOfProjectsAssociated > 0 ?
                $"This {FieldDefinitionEnum.FundingSource.ToType().GetFieldDefinitionLabel()} is associated with {numberOfProjectsAssociated} Projects. Deleting the Funding Source will delete all associated expenditure records. Are you sure you wish to delete {FieldDefinitionEnum.FundingSource.ToType().GetFieldDefinitionLabel()} '{fundingSource.FundingSourceName}'?" :
                $"Are you sure you wish to delete {FieldDefinitionEnum.FundingSource.ToType().GetFieldDefinitionLabel()} '{fundingSource.FundingSourceName}'?";

            var viewData = new ConfirmDialogFormViewData(confirmMessage);
            return RazorPartialView<ConfirmDialogForm, ConfirmDialogFormViewData, ConfirmDialogFormViewModel>(viewData, viewModel);
        }

        [HttpPost]
        [FundingSourceDeleteFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult DeleteFundingSource(FundingSourcePrimaryKey fundingSourcePrimaryKey, ConfirmDialogFormViewModel viewModel)
        {
            var fundingSource = fundingSourcePrimaryKey.EntityObject;
            var name = fundingSource.GetDisplayName();
            if (!ModelState.IsValid)
            {
                return ViewDeleteFundingSource(fundingSource, viewModel);
            }

            fundingSource.DeleteFull(HttpRequestStorage.DatabaseEntities);

            SetMessageForDisplay($"{FieldDefinitionEnum.FundingSource.ToType().GetFieldDefinitionLabel()} {name} successfully deleted.");
            return new ModalDialogFormJsonResult();
        }

        [FundingSourceViewFeature]
        public GridJsonNetJObjectResult<ProjectCalendarYearExpenditure> ProjectCalendarYearExpendituresGridJsonData(FundingSourcePrimaryKey fundingSourcePrimaryKey)
        {
            var fundingSource = fundingSourcePrimaryKey.EntityObject;
            var projectFundingSourceExpenditures = fundingSource.ProjectFundingSourceExpenditures.ToList();
            var calendarYearRangeForExpenditures =
                projectFundingSourceExpenditures.CalculateCalendarYearRangeForExpenditures(fundingSource);
            var gridSpec = new ProjectCalendarYearExpendituresGridSpec(calendarYearRangeForExpenditures);
            var projectFundingSources = ProjectCalendarYearExpenditure.CreateFromProjectsAndCalendarYears(projectFundingSourceExpenditures,
                calendarYearRangeForExpenditures);
            var gridJsonNetJObjectResult = new GridJsonNetJObjectResult<ProjectCalendarYearExpenditure>(projectFundingSources, gridSpec);
            return gridJsonNetJObjectResult;
        }

        [FundingSourceViewFeature]
        public GridJsonNetJObjectResult<ProjectFundingSourceBudget> ProjectFundingSourceBudgetGridJsonData(FundingSourcePrimaryKey fundingSourcePrimaryKey)
        {
            var fundingSource = fundingSourcePrimaryKey.EntityObject;
            var projectFundingSourceBudgets = new List<ProjectFundingSourceBudget>();
            fundingSource.ProjectFundingSourceBudgets.GroupBy(x => x.ProjectID).ForEach(grouping =>
            {
                ProjectFundingSourceBudget aggregateProjectFundingSourceBudget = null;
                grouping.ForEach(x =>
                {
                    if (aggregateProjectFundingSourceBudget == null)
                    {
                        aggregateProjectFundingSourceBudget = x;
                    }
                    else
                    {
                        aggregateProjectFundingSourceBudget.SecuredAmount += x.SecuredAmount;
                        aggregateProjectFundingSourceBudget.TargetedAmount += x.TargetedAmount;
                    }
                });
                projectFundingSourceBudgets.Add(aggregateProjectFundingSourceBudget);
            });
            var gridSpec = new ProjectFundingSourceBudgetGridSpec();
            var gridJsonNetJObjectResult = new GridJsonNetJObjectResult<ProjectFundingSourceBudget>(projectFundingSourceBudgets, gridSpec);
            return gridJsonNetJObjectResult;
        }
    }
}
