//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ThresholdEvaluationPeriod]
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
        public static ThresholdEvaluationPeriod GetThresholdEvaluationPeriod(this IQueryable<ThresholdEvaluationPeriod> thresholdEvaluationPeriods, int thresholdEvaluationPeriodID)
        {
            var thresholdEvaluationPeriod = thresholdEvaluationPeriods.SingleOrDefault(x => x.ThresholdEvaluationPeriodID == thresholdEvaluationPeriodID);
            Check.RequireNotNullThrowNotFound(thresholdEvaluationPeriod, "ThresholdEvaluationPeriod", thresholdEvaluationPeriodID);
            return thresholdEvaluationPeriod;
        }

        public static void DeleteThresholdEvaluationPeriod(this IQueryable<ThresholdEvaluationPeriod> thresholdEvaluationPeriods, List<int> thresholdEvaluationPeriodIDList)
        {
            if(thresholdEvaluationPeriodIDList.Any())
            {
                thresholdEvaluationPeriods.Where(x => thresholdEvaluationPeriodIDList.Contains(x.ThresholdEvaluationPeriodID)).Delete();
            }
        }

        public static void DeleteThresholdEvaluationPeriod(this IQueryable<ThresholdEvaluationPeriod> thresholdEvaluationPeriods, ICollection<ThresholdEvaluationPeriod> thresholdEvaluationPeriodsToDelete)
        {
            if(thresholdEvaluationPeriodsToDelete.Any())
            {
                var thresholdEvaluationPeriodIDList = thresholdEvaluationPeriodsToDelete.Select(x => x.ThresholdEvaluationPeriodID).ToList();
                thresholdEvaluationPeriods.Where(x => thresholdEvaluationPeriodIDList.Contains(x.ThresholdEvaluationPeriodID)).Delete();
            }
        }

        public static void DeleteThresholdEvaluationPeriod(this IQueryable<ThresholdEvaluationPeriod> thresholdEvaluationPeriods, int thresholdEvaluationPeriodID)
        {
            DeleteThresholdEvaluationPeriod(thresholdEvaluationPeriods, new List<int> { thresholdEvaluationPeriodID });
        }

        public static void DeleteThresholdEvaluationPeriod(this IQueryable<ThresholdEvaluationPeriod> thresholdEvaluationPeriods, ThresholdEvaluationPeriod thresholdEvaluationPeriodToDelete)
        {
            DeleteThresholdEvaluationPeriod(thresholdEvaluationPeriods, new List<ThresholdEvaluationPeriod> { thresholdEvaluationPeriodToDelete });
        }
    }
}