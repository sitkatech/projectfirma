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
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using ProjectFirma.Web.Views.Project;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Security;
using ProjectFirma.Web.Security.Shared;
using ProjectFirma.Web.Views.Shared;
using ProjectFirma.Web.Views.GeospatialArea;
using LtInfo.Common.MvcResults;
using Detail = ProjectFirma.Web.Views.GeospatialArea.Detail;
using DetailViewData = ProjectFirma.Web.Views.GeospatialArea.DetailViewData;
using Index = ProjectFirma.Web.Views.GeospatialArea.Index;
using IndexGridSpec = ProjectFirma.Web.Views.GeospatialArea.IndexGridSpec;
using IndexViewData = ProjectFirma.Web.Views.GeospatialArea.IndexViewData;

namespace ProjectFirma.Web.Controllers
{
    public class GeospatialAreaController : FirmaBaseController
    {
        [GeospatialAreaViewFeature]
        public ViewResult Index(GeospatialAreaTypePrimaryKey geospatialAreaTypePrimaryKey)
        {
            var geospatialAreaType = geospatialAreaTypePrimaryKey.EntityObject;
            var layerGeoJsons = new List<LayerGeoJson>();
            if (MultiTenantHelpers.HasGeospatialAreaMapServiceUrl())
            {
                layerGeoJsons = new List<LayerGeoJson>
                {
                    GeospatialArea.GetGeospatialAreaWmsLayerGeoJson(geospatialAreaType, "#59ACFF", 0.2m, LayerInitialVisibility.Show)
                };
            } else
            {
                var geospatialAreas = geospatialAreaType.GeospatialAreas.OrderBy(x => x.GeospatialAreaName).ToList();
                if (geospatialAreas.Any())
                {
                    layerGeoJsons.Add(new LayerGeoJson("GeospatialArea",
                        geospatialAreas.ToGeoJsonFeatureCollection(), "#59ACFF", 0.2m,
                        LayerInitialVisibility.Show));
                }
            }

            var mapInitJson = new MapInitJson("geospatialAreaIndex", 10, layerGeoJsons, BoundingBox.MakeNewDefaultBoundingBox());

            var viewData = new IndexViewData(CurrentPerson, geospatialAreaType, mapInitJson);
            return RazorView<Index, IndexViewData>(viewData);
        }

        [GeospatialAreaViewFeature]
        public GridJsonNetJObjectResult<GeospatialArea> IndexGridJsonData(GeospatialAreaTypePrimaryKey geospatialAreaTypePrimaryKey)
        {
            var geospatialAreaType = geospatialAreaTypePrimaryKey.EntityObject;
            var gridSpec = new IndexGridSpec(CurrentPerson, geospatialAreaType);
            var geospatialAreas = geospatialAreaType.GeospatialAreas.OrderBy(x => x.GeospatialAreaName).ToList();
            var gridJsonNetJObjectResult = new GridJsonNetJObjectResult<GeospatialArea>(geospatialAreas, gridSpec);
            return gridJsonNetJObjectResult;
        }

        [GeospatialAreaViewFeature]
        public ViewResult Detail(GeospatialAreaPrimaryKey geospatialAreaPrimaryKey)
        {
            var geospatialArea = geospatialAreaPrimaryKey.EntityObject;
            var mapDivID = $"geospatialArea_{geospatialArea.GeospatialAreaID}_Map";

            var associatedProjects = geospatialArea.GetAssociatedProjects(CurrentPerson);
            var layers = GeospatialArea.GetGeospatialAreaAndAssociatedProjectLayers(geospatialArea, associatedProjects);
            var mapInitJson = new MapInitJson(mapDivID, 10, layers, new BoundingBox(geospatialArea.GeospatialAreaFeature));

            var projectFundingSourceExpenditures = associatedProjects.SelectMany(x => x.ProjectFundingSourceExpenditures);
            var organizationTypes = HttpRequestStorage.DatabaseEntities.OrganizationTypes.ToList();

            const string chartTitle = "Reported Expenditures By Organization Type";
            var chartContainerID = chartTitle.Replace(" ", "");
            var googleChart = projectFundingSourceExpenditures.ToGoogleChart(x => x.FundingSource.Organization.OrganizationType.OrganizationTypeName,
                organizationTypes.Select(x => x.OrganizationTypeName).ToList(),
                x => x.FundingSource.Organization.OrganizationType.OrganizationTypeName,
                chartContainerID,
                chartTitle);

            var viewGoogleChartViewData = new ViewGoogleChartViewData(googleChart, chartTitle, 405, true);

            var performanceMeasures = associatedProjects
                .SelectMany(x => x.PerformanceMeasureActuals)
                .Select(x => x.PerformanceMeasure).Distinct()
                .OrderBy(x => x.PerformanceMeasureDisplayName)
                .ToList();

            var viewData = new DetailViewData(CurrentPerson, geospatialArea, mapInitJson, viewGoogleChartViewData, performanceMeasures);
            return RazorView<Detail, DetailViewData>(viewData);
        }

        [HttpGet]
        [GeospatialAreaManageFeature]
        public PartialViewResult DeleteGeospatialArea(GeospatialAreaPrimaryKey geospatialAreaPrimaryKey)
        {
            var geospatialArea = geospatialAreaPrimaryKey.EntityObject;
            var viewModel = new ConfirmDialogFormViewModel(geospatialArea.GeospatialAreaID);
            return ViewDeleteGeospatialArea(geospatialArea, viewModel);
        }

        private PartialViewResult ViewDeleteGeospatialArea(GeospatialArea geospatialArea, ConfirmDialogFormViewModel viewModel)
        {
            var canDelete = !geospatialArea.HasDependentObjects();
            var confirmMessage = canDelete
                ? $"Are you sure you want to delete this {geospatialArea.GeospatialAreaType.GeospatialAreaTypeName} '{geospatialArea.GeospatialAreaName}'?"
                : ConfirmDialogFormViewData.GetStandardCannotDeleteMessage($"{geospatialArea.GeospatialAreaType.GeospatialAreaTypeDefinition}", SitkaRoute<GeospatialAreaController>.BuildLinkFromExpression(x => x.Detail(geospatialArea), "here"));

            var viewData = new ConfirmDialogFormViewData(confirmMessage, canDelete);
            return RazorPartialView<ConfirmDialogForm, ConfirmDialogFormViewData, ConfirmDialogFormViewModel>(viewData, viewModel);
        }

        [HttpPost]
        [GeospatialAreaManageFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult DeleteGeospatialArea(GeospatialAreaPrimaryKey geospatialAreaPrimaryKey, ConfirmDialogFormViewModel viewModel)
        {
            var geospatialArea = geospatialAreaPrimaryKey.EntityObject;
            if (!ModelState.IsValid)
            {
                return ViewDeleteGeospatialArea(geospatialArea, viewModel);
            }
            geospatialArea.DeleteGeospatialArea();
            return new ModalDialogFormJsonResult();
        }

        [GeospatialAreaViewFeature]
        public GridJsonNetJObjectResult<Project> ProjectsGridJsonData(GeospatialAreaPrimaryKey geospatialAreaPrimaryKey)
        {
            var gridSpec = new BasicProjectInfoGridSpec(CurrentPerson, false);
            var projectGeospatialAreas = geospatialAreaPrimaryKey.EntityObject.GetAssociatedProjects(CurrentPerson);
            var gridJsonNetJObjectResult = new GridJsonNetJObjectResult<Project>(projectGeospatialAreas, gridSpec);
            return gridJsonNetJObjectResult;
        }
        
        [AnonymousUnclassifiedFeature]
        public PartialViewResult MapTooltip(GeospatialAreaPrimaryKey geospatialAreaPrimaryKey)
        {
            var viewData = new MapTooltipViewData(CurrentPerson, geospatialAreaPrimaryKey.EntityObject);
            return RazorPartialView<MapTooltip, MapTooltipViewData>(viewData);
        }
    }
}
