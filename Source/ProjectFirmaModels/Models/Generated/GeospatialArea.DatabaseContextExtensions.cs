//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[GeospatialArea]
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
        public static GeospatialArea GetGeospatialArea(this IQueryable<GeospatialArea> geospatialAreas, int geospatialAreaID)
        {
            var geospatialArea = geospatialAreas.SingleOrDefault(x => x.GeospatialAreaID == geospatialAreaID);
            Check.RequireNotNullThrowNotFound(geospatialArea, "GeospatialArea", geospatialAreaID);
            return geospatialArea;
        }

    }
}