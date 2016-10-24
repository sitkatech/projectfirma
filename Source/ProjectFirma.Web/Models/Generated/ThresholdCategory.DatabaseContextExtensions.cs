//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ThresholdCategory]
using System.Collections.Generic;
using System.Linq;
using EntityFramework.Extensions;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static ThresholdCategory GetThresholdCategory(this IQueryable<ThresholdCategory> thresholdCategories, int thresholdCategoryID)
        {
            var thresholdCategory = thresholdCategories.SingleOrDefault(x => x.ThresholdCategoryID == thresholdCategoryID);
            Check.RequireNotNullThrowNotFound(thresholdCategory, "ThresholdCategory", thresholdCategoryID);
            return thresholdCategory;
        }

        public static void DeleteThresholdCategory(this IQueryable<ThresholdCategory> thresholdCategories, List<int> thresholdCategoryIDList)
        {
            if(thresholdCategoryIDList.Any())
            {
                thresholdCategories.Where(x => thresholdCategoryIDList.Contains(x.ThresholdCategoryID)).Delete();
            }
        }

        public static void DeleteThresholdCategory(this IQueryable<ThresholdCategory> thresholdCategories, ICollection<ThresholdCategory> thresholdCategoriesToDelete)
        {
            if(thresholdCategoriesToDelete.Any())
            {
                var thresholdCategoryIDList = thresholdCategoriesToDelete.Select(x => x.ThresholdCategoryID).ToList();
                thresholdCategories.Where(x => thresholdCategoryIDList.Contains(x.ThresholdCategoryID)).Delete();
            }
        }

        public static void DeleteThresholdCategory(this IQueryable<ThresholdCategory> thresholdCategories, int thresholdCategoryID)
        {
            DeleteThresholdCategory(thresholdCategories, new List<int> { thresholdCategoryID });
        }

        public static void DeleteThresholdCategory(this IQueryable<ThresholdCategory> thresholdCategories, ThresholdCategory thresholdCategoryToDelete)
        {
            DeleteThresholdCategory(thresholdCategories, new List<ThresholdCategory> { thresholdCategoryToDelete });
        }
    }
}