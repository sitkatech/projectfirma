/*-----------------------------------------------------------------------
<copyright file="PerformanceMeasure.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
using System.Linq;
using LtInfo.Common.DesignByContract;

namespace ProjectFirmaModels.Models
{
    public partial class PerformanceMeasure : IAuditableEntity, IHaveASortOrder
    {
        public string GetAuditDescriptionString() => PerformanceMeasureDisplayName;

        public bool HasRealSubcategories()
        {
            return PerformanceMeasureSubcategories.Any(x => x.PerformanceMeasureSubcategoryOptions.Count > 1);
        }

        public int GetRealSubcategoryCount()
        {
            return HasRealSubcategories() ? PerformanceMeasureSubcategories.Count : 0;
        }

        public string GetDisplayName() => PerformanceMeasureDisplayName;
        public void SetSortOrder(int? value) => PerformanceMeasureSortOrder = value;
        public int? GetSortOrder() => PerformanceMeasureSortOrder;
        public int GetID() => PerformanceMeasureID;

        public PerformanceMeasureTargetValueTypeEnum GetPerformanceMeasureTargetValueType(GeospatialArea geospatialArea)
        {
            bool hasNoTarget = this.GeospatialAreaPerformanceMeasureNoTargets.Any(x => x.GeospatialAreaID == geospatialArea.GeospatialAreaID);
            bool hasOverallTarget = this.GeospatialAreaPerformanceMeasureOverallTargets.Any(x => x.GeospatialAreaID == geospatialArea.GeospatialAreaID);
            bool hasReportingPeriodTarget = this.GeospatialAreaPerformanceMeasureReportingPeriodTargets.Any(x => x.GeospatialAreaID == geospatialArea.GeospatialAreaID);

            // NOTE that the unset case (all false) is NOT yet handled! Need to think about this.
            Check.Ensure((hasNoTarget && !hasOverallTarget && !hasReportingPeriodTarget) ||
                                (!hasNoTarget && hasOverallTarget && !hasReportingPeriodTarget) ||
                                (!hasNoTarget && !hasOverallTarget && hasReportingPeriodTarget)
            );

            if (hasNoTarget)
            {
                return PerformanceMeasureTargetValueTypeEnum.NoTarget;
            }

            if (hasOverallTarget)
            {
                return PerformanceMeasureTargetValueTypeEnum.OverallTarget;
            }

            if (hasReportingPeriodTarget)
            {
                return PerformanceMeasureTargetValueTypeEnum.ReportingPeriodTarget;
            }

            throw(new NotImplementedException("Not expecting to reach here; what's the problem?"));
        }
    }
}
