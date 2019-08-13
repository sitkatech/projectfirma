/*-----------------------------------------------------------------------
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

using System.Collections.Generic;
using System.Linq;
using ProjectFirma.Web.Views.Project;
using ProjectFirma.Web.Views.Results;
using ProjectFirma.Web.Controllers;
using ProjectFirmaModels.Models;
using ProjectFirma.Web.Security;
using LtInfo.Common;
using LtInfo.Common.Mvc;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Views.PerformanceMeasure;
using ProjectFirma.Web.Views.Shared;

namespace ProjectFirma.Web.Views.GeospatialArea
{
    public class DetailViewData : FirmaViewData
    {
        public readonly ProjectFirmaModels.Models.GeospatialArea GeospatialArea;
        public readonly string GeospatialAreaTypeName;
        public readonly string GeospatialAreaTypeNamePluralized;
        public readonly bool UserHasGeospatialAreaManagePermissions;
        public readonly string IndexUrl;
        public readonly BasicProjectInfoGridSpec BasicProjectInfoGridSpec;
        public readonly string BasicProjectInfoGridName;
        public readonly string BasicProjectInfoGridDataUrl;
        public readonly MapInitJson MapInitJson;
        public readonly ViewGoogleChartViewData ViewGoogleChartViewData;
        public readonly List<PerformanceMeasureChartViewData> PerformanceMeasureChartViewDatas;
        public ViewPageContentViewData GeospatialAreaDescriptionViewPageContentViewData { get; }

        public DetailViewData(Person currentPerson, ProjectFirmaModels.Models.GeospatialArea geospatialArea, MapInitJson mapInitJson, ViewGoogleChartViewData viewGoogleChartViewData, List<ProjectFirmaModels.Models.PerformanceMeasure> performanceMeasures) : base(currentPerson)
        {
            GeospatialArea = geospatialArea;
            MapInitJson = mapInitJson;
            ViewGoogleChartViewData = viewGoogleChartViewData;
            PageTitle = geospatialArea.GeospatialAreaName;
            GeospatialAreaTypeName = geospatialArea.GeospatialAreaType.GeospatialAreaTypeName;
            GeospatialAreaTypeNamePluralized = geospatialArea.GeospatialAreaType.GeospatialAreaTypeNamePluralized;
            EntityName = $"{GeospatialAreaTypeName}";
            UserHasGeospatialAreaManagePermissions = new GeospatialAreaManageFeature().HasPermissionByPerson(currentPerson);
            IndexUrl = SitkaRoute<GeospatialAreaController>.BuildUrlFromExpression(x => x.Index(geospatialArea.GeospatialAreaType));

            BasicProjectInfoGridName = "geospatialAreaProjectListGrid";
            BasicProjectInfoGridSpec = new BasicProjectInfoGridSpec(CurrentPerson, false)
            {
                ObjectNameSingular = $"{FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()} in this {GeospatialAreaTypeName}",
                ObjectNamePlural = $"{FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabelPluralized()} in this {GeospatialAreaTypeName}",
                SaveFiltersInCookie = true
            };
          
            BasicProjectInfoGridDataUrl = SitkaRoute<GeospatialAreaController>.BuildUrlFromExpression(tc => tc.ProjectsGridJsonData(geospatialArea));

            PerformanceMeasureChartViewDatas = performanceMeasures.Select(x=>geospatialArea.GetPerformanceMeasureChartViewData(x, CurrentPerson)).ToList();

            GeospatialAreaDescriptionViewPageContentViewData = new ViewPageContentViewData(geospatialArea, currentPerson);
        }

        
    }
}
