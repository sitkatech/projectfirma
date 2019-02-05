//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[PerformanceMeasureSubcategory]
using System.Collections.Generic;
using System.Linq;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static PerformanceMeasureSubcategory GetPerformanceMeasureSubcategory(this IQueryable<PerformanceMeasureSubcategory> performanceMeasureSubcategories, int performanceMeasureSubcategoryID)
        {
            var performanceMeasureSubcategory = performanceMeasureSubcategories.SingleOrDefault(x => x.PerformanceMeasureSubcategoryID == performanceMeasureSubcategoryID);
            Check.RequireNotNullThrowNotFound(performanceMeasureSubcategory, "PerformanceMeasureSubcategory", performanceMeasureSubcategoryID);
            return performanceMeasureSubcategory;
        }

    }
}