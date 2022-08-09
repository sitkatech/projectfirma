//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[PerformanceMeasureGroup]
using System.Collections.Generic;
using System.Linq;
using CodeFirstStoreFunctions;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static PerformanceMeasureGroup GetPerformanceMeasureGroup(this IQueryable<PerformanceMeasureGroup> performanceMeasureGroups, int performanceMeasureGroupID)
        {
            var performanceMeasureGroup = performanceMeasureGroups.SingleOrDefault(x => x.PerformanceMeasureGroupID == performanceMeasureGroupID);
            Check.RequireNotNullThrowNotFound(performanceMeasureGroup, "PerformanceMeasureGroup", performanceMeasureGroupID);
            return performanceMeasureGroup;
        }

    }
}