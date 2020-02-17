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
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Security;
using ProjectFirma.Web.Views.Map;
using ProjectFirma.Web.Views.PerformanceMeasure;
using ProjectFirma.Web.Views.ProjectCustomGrid;
using ProjectFirma.Web.Views.Shared;
using ProjectFirma.Web.Views.Shared.ProjectLocationControls;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Views.Classification
{
    public class DetailViewData : FirmaViewData
    {
        public ProjectFirmaModels.Models.Classification Classification { get; }
        public string EditClassificationUrl { get; }
        public string IndexUrl { get; }
        public bool UserHasClassificationManagePermissions { get; }

        public ProjectCustomGridSpec ProjectCustomDefaultGridSpec { get; }
        public string ProjectCustomDefaultGridName { get; }
        public string ProjectCustomDefaultGridDataUrl { get; }

        public string ClassificationDisplayName { get; }
        public string ClassificationDisplayNamePluralized { get; }

        public ProjectLocationsMapViewData ProjectLocationsMapViewData { get; }
        public ProjectLocationsMapInitJson ProjectLocationsMapInitJson { get; }
        public ViewGoogleChartViewData ViewGoogleChartViewData { get; }
        public List<PerformanceMeasureChartViewData> PerformanceMeasureChartViewDatas { get; }

        public DetailViewData(FirmaSession currentFirmaSession,
                            ProjectFirmaModels.Models.Classification classification,
                            ProjectLocationsMapViewData projectLocationsMapViewData,
                            ProjectLocationsMapInitJson projectLocationsMapInitJson, ViewGoogleChartViewData viewGoogleChartViewData,
                            List<ProjectFirmaModels.Models.PerformanceMeasure> performanceMeasures,
                            List<ProjectCustomGridConfiguration> projectCustomDefaultGridConfigurations)
                            : base(currentFirmaSession)
        {
            Classification = classification;
            ProjectLocationsMapViewData = projectLocationsMapViewData;
            ProjectLocationsMapInitJson = projectLocationsMapInitJson;
            ViewGoogleChartViewData = viewGoogleChartViewData;
            PageTitle = ClassificationSystemModelExtensions.GetClassificationSystemNamePluralized(classification.ClassificationSystem);
            EditClassificationUrl = SitkaRoute<ClassificationController>.BuildUrlFromExpression(c => c.Edit(classification));
            IndexUrl = SitkaRoute<ProgramInfoController>.BuildUrlFromExpression(c => c.ClassificationSystem(classification.ClassificationSystem));

            UserHasClassificationManagePermissions = new FirmaAdminFeature().HasPermissionByFirmaSession(currentFirmaSession);
            ClassificationDisplayNamePluralized = ClassificationSystemModelExtensions.GetClassificationSystemNamePluralized(classification.ClassificationSystem);
            ClassificationDisplayName = classification.ClassificationSystem.ClassificationSystemName;

            ProjectCustomDefaultGridSpec = new ProjectCustomGridSpec(currentFirmaSession, projectCustomDefaultGridConfigurations, ProjectCustomGridType.Default.ToEnum) { ObjectNameSingular = $"{FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()}", ObjectNamePlural = $"{FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabelPluralized()}", SaveFiltersInCookie = true };

            ProjectCustomDefaultGridName = "classificationProjectListGrid";
            ProjectCustomDefaultGridDataUrl = SitkaRoute<ProjectCustomGridController>.BuildUrlFromExpression(tc => tc.ClassificationProjectsGridJsonData(classification));

            PerformanceMeasureChartViewDatas = performanceMeasures.Select(x => classification.GetPerformanceMeasureChartViewData(x, CurrentFirmaSession)).ToList();
        }
    }
}
