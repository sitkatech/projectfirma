//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[IndicatorSubcategoryOption]
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
        public static IndicatorSubcategoryOption GetIndicatorSubcategoryOption(this IQueryable<IndicatorSubcategoryOption> indicatorSubcategoryOptions, int indicatorSubcategoryOptionID)
        {
            var indicatorSubcategoryOption = indicatorSubcategoryOptions.SingleOrDefault(x => x.IndicatorSubcategoryOptionID == indicatorSubcategoryOptionID);
            Check.RequireNotNullThrowNotFound(indicatorSubcategoryOption, "IndicatorSubcategoryOption", indicatorSubcategoryOptionID);
            return indicatorSubcategoryOption;
        }

        public static void DeleteIndicatorSubcategoryOption(this IQueryable<IndicatorSubcategoryOption> indicatorSubcategoryOptions, List<int> indicatorSubcategoryOptionIDList)
        {
            if(indicatorSubcategoryOptionIDList.Any())
            {
                indicatorSubcategoryOptions.Where(x => indicatorSubcategoryOptionIDList.Contains(x.IndicatorSubcategoryOptionID)).Delete();
            }
        }

        public static void DeleteIndicatorSubcategoryOption(this IQueryable<IndicatorSubcategoryOption> indicatorSubcategoryOptions, ICollection<IndicatorSubcategoryOption> indicatorSubcategoryOptionsToDelete)
        {
            if(indicatorSubcategoryOptionsToDelete.Any())
            {
                var indicatorSubcategoryOptionIDList = indicatorSubcategoryOptionsToDelete.Select(x => x.IndicatorSubcategoryOptionID).ToList();
                indicatorSubcategoryOptions.Where(x => indicatorSubcategoryOptionIDList.Contains(x.IndicatorSubcategoryOptionID)).Delete();
            }
        }

        public static void DeleteIndicatorSubcategoryOption(this IQueryable<IndicatorSubcategoryOption> indicatorSubcategoryOptions, int indicatorSubcategoryOptionID)
        {
            DeleteIndicatorSubcategoryOption(indicatorSubcategoryOptions, new List<int> { indicatorSubcategoryOptionID });
        }

        public static void DeleteIndicatorSubcategoryOption(this IQueryable<IndicatorSubcategoryOption> indicatorSubcategoryOptions, IndicatorSubcategoryOption indicatorSubcategoryOptionToDelete)
        {
            DeleteIndicatorSubcategoryOption(indicatorSubcategoryOptions, new List<IndicatorSubcategoryOption> { indicatorSubcategoryOptionToDelete });
        }
    }
}