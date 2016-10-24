//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[IndicatorSubcategory]
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
        public static IndicatorSubcategory GetIndicatorSubcategory(this IQueryable<IndicatorSubcategory> indicatorSubcategories, int indicatorSubcategoryID)
        {
            var indicatorSubcategory = indicatorSubcategories.SingleOrDefault(x => x.IndicatorSubcategoryID == indicatorSubcategoryID);
            Check.RequireNotNullThrowNotFound(indicatorSubcategory, "IndicatorSubcategory", indicatorSubcategoryID);
            return indicatorSubcategory;
        }

        public static void DeleteIndicatorSubcategory(this IQueryable<IndicatorSubcategory> indicatorSubcategories, List<int> indicatorSubcategoryIDList)
        {
            if(indicatorSubcategoryIDList.Any())
            {
                indicatorSubcategories.Where(x => indicatorSubcategoryIDList.Contains(x.IndicatorSubcategoryID)).Delete();
            }
        }

        public static void DeleteIndicatorSubcategory(this IQueryable<IndicatorSubcategory> indicatorSubcategories, ICollection<IndicatorSubcategory> indicatorSubcategoriesToDelete)
        {
            if(indicatorSubcategoriesToDelete.Any())
            {
                var indicatorSubcategoryIDList = indicatorSubcategoriesToDelete.Select(x => x.IndicatorSubcategoryID).ToList();
                indicatorSubcategories.Where(x => indicatorSubcategoryIDList.Contains(x.IndicatorSubcategoryID)).Delete();
            }
        }

        public static void DeleteIndicatorSubcategory(this IQueryable<IndicatorSubcategory> indicatorSubcategories, int indicatorSubcategoryID)
        {
            DeleteIndicatorSubcategory(indicatorSubcategories, new List<int> { indicatorSubcategoryID });
        }

        public static void DeleteIndicatorSubcategory(this IQueryable<IndicatorSubcategory> indicatorSubcategories, IndicatorSubcategory indicatorSubcategoryToDelete)
        {
            DeleteIndicatorSubcategory(indicatorSubcategories, new List<IndicatorSubcategory> { indicatorSubcategoryToDelete });
        }
    }
}