/*-----------------------------------------------------------------------
<copyright file="SimpleAccomplishmentsDashboardViewData.cs" company="Tahoe Regional Planning Agency and Environmental Science Associates">
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

using System;
using System.Collections.Generic;
using System.Linq;
using ProjectFirma.Web.Controllers;
using ProjectFirmaModels.Models;
using LtInfo.Common;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Security;

namespace ProjectFirma.Web.Views.Results
{
    public class SimpleAccomplishmentsDashboardViewData : FirmaViewData
    {
        public List<ProjectFirmaModels.Models.PerformanceMeasureGroup> PerformanceMeasureGroups { get; }
        public Dictionary<ProjectFirmaModels.Models.PerformanceMeasureGroup, List<Tuple<double, MeasurementUnitType>>> PerformanceMeasureGroupsAndMeasurementUnitTypeTotals { get; }
        public bool HasSitkaAdminPermissions { get; set; }

        public SimpleAccomplishmentsDashboardViewData(FirmaSession currentFirmaSession, ProjectFirmaModels.Models.FirmaPage firmaPage,
            List<ProjectFirmaModels.Models.PerformanceMeasureGroup> performanceMeasureGroups) : base(currentFirmaSession, firmaPage)
        {
            PageTitle = FieldDefinitionEnum.AccomplishmentDashboardMenu.ToType().GetFieldDefinitionLabel();
            PerformanceMeasureGroups = performanceMeasureGroups;

            PerformanceMeasureGroupsAndMeasurementUnitTypeTotals =
                new Dictionary<ProjectFirmaModels.Models.PerformanceMeasureGroup,
                    List<Tuple<double, MeasurementUnitType>>>();
            foreach (var group in performanceMeasureGroups)
            {
                PerformanceMeasureGroupsAndMeasurementUnitTypeTotals.Add(group, new List<Tuple<double, MeasurementUnitType>>());
                var pmsByUnit = group.PerformanceMeasures.GroupBy(x => x.MeasurementUnitType).OrderBy(x => x.Key.MeasurementUnitTypeDisplayName);
                foreach (var unitAndPms in pmsByUnit)
                {
                    var unit = unitAndPms.Key;
                    var reported = Math.Round(unitAndPms.Sum(x =>
                        x.GetReportedPerformanceMeasureValues(currentFirmaSession).Sum(y => y.GetReportedValue() ?? 0)));
                    PerformanceMeasureGroupsAndMeasurementUnitTypeTotals[group].Add(new Tuple<double, MeasurementUnitType>(reported, unit));
                }
            }

            HasSitkaAdminPermissions = new SitkaAdminFeature().HasPermissionByFirmaSession(currentFirmaSession);
        }
    }
}
