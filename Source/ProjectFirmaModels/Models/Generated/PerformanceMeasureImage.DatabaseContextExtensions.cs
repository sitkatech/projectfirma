//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[PerformanceMeasureImage]
using System.Collections.Generic;
using System.Linq;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static PerformanceMeasureImage GetPerformanceMeasureImage(this IQueryable<PerformanceMeasureImage> performanceMeasureImages, int performanceMeasureImageID)
        {
            var performanceMeasureImage = performanceMeasureImages.SingleOrDefault(x => x.PerformanceMeasureImageID == performanceMeasureImageID);
            Check.RequireNotNullThrowNotFound(performanceMeasureImage, "PerformanceMeasureImage", performanceMeasureImageID);
            return performanceMeasureImage;
        }

    }
}