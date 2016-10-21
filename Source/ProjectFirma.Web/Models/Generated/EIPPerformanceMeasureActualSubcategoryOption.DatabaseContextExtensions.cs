//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[EIPPerformanceMeasureActualSubcategoryOption]
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
        public static EIPPerformanceMeasureActualSubcategoryOption GetEIPPerformanceMeasureActualSubcategoryOption(this IQueryable<EIPPerformanceMeasureActualSubcategoryOption> eIPPerformanceMeasureActualSubcategoryOptions, int eIPPerformanceMeasureActualSubcategoryOptionID)
        {
            var eIPPerformanceMeasureActualSubcategoryOption = eIPPerformanceMeasureActualSubcategoryOptions.SingleOrDefault(x => x.EIPPerformanceMeasureActualSubcategoryOptionID == eIPPerformanceMeasureActualSubcategoryOptionID);
            Check.RequireNotNullThrowNotFound(eIPPerformanceMeasureActualSubcategoryOption, "EIPPerformanceMeasureActualSubcategoryOption", eIPPerformanceMeasureActualSubcategoryOptionID);
            return eIPPerformanceMeasureActualSubcategoryOption;
        }

        public static void DeleteEIPPerformanceMeasureActualSubcategoryOption(this IQueryable<EIPPerformanceMeasureActualSubcategoryOption> eIPPerformanceMeasureActualSubcategoryOptions, List<int> eIPPerformanceMeasureActualSubcategoryOptionIDList)
        {
            if(eIPPerformanceMeasureActualSubcategoryOptionIDList.Any())
            {
                eIPPerformanceMeasureActualSubcategoryOptions.Where(x => eIPPerformanceMeasureActualSubcategoryOptionIDList.Contains(x.EIPPerformanceMeasureActualSubcategoryOptionID)).Delete();
            }
        }

        public static void DeleteEIPPerformanceMeasureActualSubcategoryOption(this IQueryable<EIPPerformanceMeasureActualSubcategoryOption> eIPPerformanceMeasureActualSubcategoryOptions, ICollection<EIPPerformanceMeasureActualSubcategoryOption> eIPPerformanceMeasureActualSubcategoryOptionsToDelete)
        {
            if(eIPPerformanceMeasureActualSubcategoryOptionsToDelete.Any())
            {
                var eIPPerformanceMeasureActualSubcategoryOptionIDList = eIPPerformanceMeasureActualSubcategoryOptionsToDelete.Select(x => x.EIPPerformanceMeasureActualSubcategoryOptionID).ToList();
                eIPPerformanceMeasureActualSubcategoryOptions.Where(x => eIPPerformanceMeasureActualSubcategoryOptionIDList.Contains(x.EIPPerformanceMeasureActualSubcategoryOptionID)).Delete();
            }
        }

        public static void DeleteEIPPerformanceMeasureActualSubcategoryOption(this IQueryable<EIPPerformanceMeasureActualSubcategoryOption> eIPPerformanceMeasureActualSubcategoryOptions, int eIPPerformanceMeasureActualSubcategoryOptionID)
        {
            DeleteEIPPerformanceMeasureActualSubcategoryOption(eIPPerformanceMeasureActualSubcategoryOptions, new List<int> { eIPPerformanceMeasureActualSubcategoryOptionID });
        }

        public static void DeleteEIPPerformanceMeasureActualSubcategoryOption(this IQueryable<EIPPerformanceMeasureActualSubcategoryOption> eIPPerformanceMeasureActualSubcategoryOptions, EIPPerformanceMeasureActualSubcategoryOption eIPPerformanceMeasureActualSubcategoryOptionToDelete)
        {
            DeleteEIPPerformanceMeasureActualSubcategoryOption(eIPPerformanceMeasureActualSubcategoryOptions, new List<EIPPerformanceMeasureActualSubcategoryOption> { eIPPerformanceMeasureActualSubcategoryOptionToDelete });
        }
    }
}