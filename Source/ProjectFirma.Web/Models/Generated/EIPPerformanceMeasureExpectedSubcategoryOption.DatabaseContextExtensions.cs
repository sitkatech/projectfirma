//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[EIPPerformanceMeasureExpectedSubcategoryOption]
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
        public static EIPPerformanceMeasureExpectedSubcategoryOption GetEIPPerformanceMeasureExpectedSubcategoryOption(this IQueryable<EIPPerformanceMeasureExpectedSubcategoryOption> eIPPerformanceMeasureExpectedSubcategoryOptions, int eIPPerformanceMeasureExpectedSubcategoryOptionID)
        {
            var eIPPerformanceMeasureExpectedSubcategoryOption = eIPPerformanceMeasureExpectedSubcategoryOptions.SingleOrDefault(x => x.EIPPerformanceMeasureExpectedSubcategoryOptionID == eIPPerformanceMeasureExpectedSubcategoryOptionID);
            Check.RequireNotNullThrowNotFound(eIPPerformanceMeasureExpectedSubcategoryOption, "EIPPerformanceMeasureExpectedSubcategoryOption", eIPPerformanceMeasureExpectedSubcategoryOptionID);
            return eIPPerformanceMeasureExpectedSubcategoryOption;
        }

        public static void DeleteEIPPerformanceMeasureExpectedSubcategoryOption(this IQueryable<EIPPerformanceMeasureExpectedSubcategoryOption> eIPPerformanceMeasureExpectedSubcategoryOptions, List<int> eIPPerformanceMeasureExpectedSubcategoryOptionIDList)
        {
            if(eIPPerformanceMeasureExpectedSubcategoryOptionIDList.Any())
            {
                eIPPerformanceMeasureExpectedSubcategoryOptions.Where(x => eIPPerformanceMeasureExpectedSubcategoryOptionIDList.Contains(x.EIPPerformanceMeasureExpectedSubcategoryOptionID)).Delete();
            }
        }

        public static void DeleteEIPPerformanceMeasureExpectedSubcategoryOption(this IQueryable<EIPPerformanceMeasureExpectedSubcategoryOption> eIPPerformanceMeasureExpectedSubcategoryOptions, ICollection<EIPPerformanceMeasureExpectedSubcategoryOption> eIPPerformanceMeasureExpectedSubcategoryOptionsToDelete)
        {
            if(eIPPerformanceMeasureExpectedSubcategoryOptionsToDelete.Any())
            {
                var eIPPerformanceMeasureExpectedSubcategoryOptionIDList = eIPPerformanceMeasureExpectedSubcategoryOptionsToDelete.Select(x => x.EIPPerformanceMeasureExpectedSubcategoryOptionID).ToList();
                eIPPerformanceMeasureExpectedSubcategoryOptions.Where(x => eIPPerformanceMeasureExpectedSubcategoryOptionIDList.Contains(x.EIPPerformanceMeasureExpectedSubcategoryOptionID)).Delete();
            }
        }

        public static void DeleteEIPPerformanceMeasureExpectedSubcategoryOption(this IQueryable<EIPPerformanceMeasureExpectedSubcategoryOption> eIPPerformanceMeasureExpectedSubcategoryOptions, int eIPPerformanceMeasureExpectedSubcategoryOptionID)
        {
            DeleteEIPPerformanceMeasureExpectedSubcategoryOption(eIPPerformanceMeasureExpectedSubcategoryOptions, new List<int> { eIPPerformanceMeasureExpectedSubcategoryOptionID });
        }

        public static void DeleteEIPPerformanceMeasureExpectedSubcategoryOption(this IQueryable<EIPPerformanceMeasureExpectedSubcategoryOption> eIPPerformanceMeasureExpectedSubcategoryOptions, EIPPerformanceMeasureExpectedSubcategoryOption eIPPerformanceMeasureExpectedSubcategoryOptionToDelete)
        {
            DeleteEIPPerformanceMeasureExpectedSubcategoryOption(eIPPerformanceMeasureExpectedSubcategoryOptions, new List<EIPPerformanceMeasureExpectedSubcategoryOption> { eIPPerformanceMeasureExpectedSubcategoryOptionToDelete });
        }
    }
}