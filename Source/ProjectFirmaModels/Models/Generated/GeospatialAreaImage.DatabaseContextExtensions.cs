//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[GeospatialAreaImage]
using System.Collections.Generic;
using System.Linq;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static GeospatialAreaImage GetGeospatialAreaImage(this IQueryable<GeospatialAreaImage> geospatialAreaImages, int geospatialAreaImageID)
        {
            var geospatialAreaImage = geospatialAreaImages.SingleOrDefault(x => x.GeospatialAreaImageID == geospatialAreaImageID);
            Check.RequireNotNullThrowNotFound(geospatialAreaImage, "GeospatialAreaImage", geospatialAreaImageID);
            return geospatialAreaImage;
        }

    }
}