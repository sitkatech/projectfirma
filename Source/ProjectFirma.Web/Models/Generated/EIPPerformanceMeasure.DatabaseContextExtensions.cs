//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[EIPPerformanceMeasure]
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
        public static EIPPerformanceMeasure GetEIPPerformanceMeasure(this IQueryable<EIPPerformanceMeasure> eIPPerformanceMeasures, int eIPPerformanceMeasureID)
        {
            var eIPPerformanceMeasure = eIPPerformanceMeasures.SingleOrDefault(x => x.EIPPerformanceMeasureID == eIPPerformanceMeasureID);
            Check.RequireNotNullThrowNotFound(eIPPerformanceMeasure, "EIPPerformanceMeasure", eIPPerformanceMeasureID);
            return eIPPerformanceMeasure;
        }

        public static void DeleteEIPPerformanceMeasure(this IQueryable<EIPPerformanceMeasure> eIPPerformanceMeasures, List<int> eIPPerformanceMeasureIDList)
        {
            if(eIPPerformanceMeasureIDList.Any())
            {
                eIPPerformanceMeasures.Where(x => eIPPerformanceMeasureIDList.Contains(x.EIPPerformanceMeasureID)).Delete();
            }
        }

        public static void DeleteEIPPerformanceMeasure(this IQueryable<EIPPerformanceMeasure> eIPPerformanceMeasures, ICollection<EIPPerformanceMeasure> eIPPerformanceMeasuresToDelete)
        {
            if(eIPPerformanceMeasuresToDelete.Any())
            {
                var eIPPerformanceMeasureIDList = eIPPerformanceMeasuresToDelete.Select(x => x.EIPPerformanceMeasureID).ToList();
                eIPPerformanceMeasures.Where(x => eIPPerformanceMeasureIDList.Contains(x.EIPPerformanceMeasureID)).Delete();
            }
        }

        public static void DeleteEIPPerformanceMeasure(this IQueryable<EIPPerformanceMeasure> eIPPerformanceMeasures, int eIPPerformanceMeasureID)
        {
            DeleteEIPPerformanceMeasure(eIPPerformanceMeasures, new List<int> { eIPPerformanceMeasureID });
        }

        public static void DeleteEIPPerformanceMeasure(this IQueryable<EIPPerformanceMeasure> eIPPerformanceMeasures, EIPPerformanceMeasure eIPPerformanceMeasureToDelete)
        {
            DeleteEIPPerformanceMeasure(eIPPerformanceMeasures, new List<EIPPerformanceMeasure> { eIPPerformanceMeasureToDelete });
        }
    }
}