﻿/*-----------------------------------------------------------------------
<copyright file="DetailViewData.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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

using System;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Security;
using ProjectFirma.Web.Views.PerformanceMeasure;
using ProjectFirma.Web.Views.ProjectCustomGrid;
using ProjectFirma.Web.Views.Shared;
using ProjectFirmaModels.Models;
using System.Collections.Generic;
using System.Linq;

namespace ProjectFirma.Web.Views.GeospatialArea
{
    public class DetailViewData : FirmaViewData
    {
        public ProjectFirmaModels.Models.GeospatialArea GeospatialArea { get; }
        public string GeospatialAreaTypeName { get; }
        public string GeospatialAreaTypeNamePluralized { get; }
        public bool UserHasGeospatialAreaManagePermissions { get; }
        public string IndexUrl { get; }

        public ProjectCustomGridSpec ProjectCustomDefaultGridSpec { get; }
        public string ProjectCustomDefaultGridName { get; }
        public string ProjectCustomDefaultGridDataUrl { get; }

        public MapInitJson MapInitJson { get; }
        public ViewGoogleChartViewData ViewGoogleChartViewData { get; }
        public List<PerformanceMeasureChartViewData> PerformanceMeasureChartViewDatas { get; }
        public ViewPageContentViewData GeospatialAreaDescriptionViewPageContentViewData { get; }

        public DetailViewData(FirmaSession currentFirmaSession, ProjectFirmaModels.Models.GeospatialArea geospatialArea, 
                            MapInitJson mapInitJson, ViewGoogleChartViewData viewGoogleChartViewData, 
                            List<ProjectFirmaModels.Models.PerformanceMeasure> performanceMeasures,
                            List<ProjectCustomGridConfiguration> projectCustomDefaultGridConfigurations) : base(currentFirmaSession)
        {
            GeospatialArea = geospatialArea;
            MapInitJson = mapInitJson;
            ViewGoogleChartViewData = viewGoogleChartViewData;
            PageTitle = geospatialArea.GeospatialAreaName;
            GeospatialAreaTypeName = geospatialArea.GeospatialAreaType.GeospatialAreaTypeName;
            GeospatialAreaTypeNamePluralized = geospatialArea.GeospatialAreaType.GeospatialAreaTypeNamePluralized;
            EntityName = $"{GeospatialAreaTypeName}";
            UserHasGeospatialAreaManagePermissions = new GeospatialAreaManageFeature().HasPermissionByFirmaSession(currentFirmaSession);
            IndexUrl = SitkaRoute<GeospatialAreaController>.BuildUrlFromExpression(x => x.Index(geospatialArea.GeospatialAreaType));
            var projectDetails = HttpRequestStorage.DatabaseEntities.vProjectDetails.ToDictionary(x => x.ProjectID);
            ProjectCustomDefaultGridSpec = new ProjectCustomGridSpec(currentFirmaSession, projectCustomDefaultGridConfigurations, ProjectCustomGridType.Default.ToEnum, projectDetails, currentFirmaSession.Tenant) { ObjectNameSingular = $"{FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()}", ObjectNamePlural = $"{FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabelPluralized()}", SaveFiltersInCookie = true };

            ProjectCustomDefaultGridName = "geospatialAreaProjectListGrid";
            ProjectCustomDefaultGridDataUrl = SitkaRoute<ProjectCustomGridController>.BuildUrlFromExpression(tc => tc.GeospatialAreaProjectsGridJsonData(geospatialArea));

            PerformanceMeasureChartViewDatas = performanceMeasures.Select(x=>geospatialArea.GetPerformanceMeasureChartViewData(x, currentFirmaSession)).ToList();

            GeospatialAreaDescriptionViewPageContentViewData = new ViewPageContentViewData(geospatialArea, currentFirmaSession);
        }

        
    }
}
