//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ThresholdReportingCategory]
using System.Collections.Generic;
using System.Linq;
using EntityFramework.Extensions;
using ProjectFirma.Web.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static ThresholdReportingCategory GetThresholdReportingCategory(this IQueryable<ThresholdReportingCategory> thresholdReportingCategories, int thresholdReportingCategoryID)
        {
            var thresholdReportingCategory = thresholdReportingCategories.SingleOrDefault(x => x.ThresholdReportingCategoryID == thresholdReportingCategoryID);
            Check.RequireNotNullThrowNotFound(thresholdReportingCategory, "ThresholdReportingCategory", thresholdReportingCategoryID);
            return thresholdReportingCategory;
        }

        public static void DeleteThresholdReportingCategory(this IQueryable<ThresholdReportingCategory> thresholdReportingCategories, List<int> thresholdReportingCategoryIDList)
        {
            if(thresholdReportingCategoryIDList.Any())
            {
                thresholdReportingCategories.Where(x => thresholdReportingCategoryIDList.Contains(x.ThresholdReportingCategoryID)).Delete();
            }
        }

        public static void DeleteThresholdReportingCategory(this IQueryable<ThresholdReportingCategory> thresholdReportingCategories, ICollection<ThresholdReportingCategory> thresholdReportingCategoriesToDelete)
        {
            if(thresholdReportingCategoriesToDelete.Any())
            {
                var thresholdReportingCategoryIDList = thresholdReportingCategoriesToDelete.Select(x => x.ThresholdReportingCategoryID).ToList();
                thresholdReportingCategories.Where(x => thresholdReportingCategoryIDList.Contains(x.ThresholdReportingCategoryID)).Delete();
            }
        }

        public static void DeleteThresholdReportingCategory(this IQueryable<ThresholdReportingCategory> thresholdReportingCategories, int thresholdReportingCategoryID)
        {
            DeleteThresholdReportingCategory(thresholdReportingCategories, new List<int> { thresholdReportingCategoryID });
        }

        public static void DeleteThresholdReportingCategory(this IQueryable<ThresholdReportingCategory> thresholdReportingCategories, ThresholdReportingCategory thresholdReportingCategoryToDelete)
        {
            DeleteThresholdReportingCategory(thresholdReportingCategories, new List<ThresholdReportingCategory> { thresholdReportingCategoryToDelete });
        }
    }
}