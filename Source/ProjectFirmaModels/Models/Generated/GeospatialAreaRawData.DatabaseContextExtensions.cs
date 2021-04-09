//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[GeospatialAreaRawData]
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
        public static GeospatialAreaRawData GetGeospatialAreaRawData(this IQueryable<GeospatialAreaRawData> geospatialAreaRawDatas, int geospatialAreaRawDataID)
        {
            var geospatialAreaRawData = geospatialAreaRawDatas.SingleOrDefault(x => x.GeospatialAreaRawDataID == geospatialAreaRawDataID);
            Check.RequireNotNullThrowNotFound(geospatialAreaRawData, "GeospatialAreaRawData", geospatialAreaRawDataID);
            return geospatialAreaRawData;
        }

    }
}