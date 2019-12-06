//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[GeospatialAreaPerformanceMeasurePerformanceMeasureTargetValueType]
using System.Collections.Generic;
using System.Linq;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static GeospatialAreaPerformanceMeasurePerformanceMeasureTargetValueType GetGeospatialAreaPerformanceMeasurePerformanceMeasureTargetValueType(this IQueryable<GeospatialAreaPerformanceMeasurePerformanceMeasureTargetValueType> geospatialAreaPerformanceMeasurePerformanceMeasureTargetValueTypes, int geospatialAreaPerformanceMeasurePerformanceMeasureTargetValueTypeID)
        {
            var geospatialAreaPerformanceMeasurePerformanceMeasureTargetValueType = geospatialAreaPerformanceMeasurePerformanceMeasureTargetValueTypes.SingleOrDefault(x => x.GeospatialAreaPerformanceMeasurePerformanceMeasureTargetValueTypeID == geospatialAreaPerformanceMeasurePerformanceMeasureTargetValueTypeID);
            Check.RequireNotNullThrowNotFound(geospatialAreaPerformanceMeasurePerformanceMeasureTargetValueType, "GeospatialAreaPerformanceMeasurePerformanceMeasureTargetValueType", geospatialAreaPerformanceMeasurePerformanceMeasureTargetValueTypeID);
            return geospatialAreaPerformanceMeasurePerformanceMeasureTargetValueType;
        }

    }
}