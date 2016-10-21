using System.Linq;
using LtInfo.Common.DesignByContract;

namespace ProjectFirma.Web.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static ThresholdReportingCategory GetThresholdReportingCategoryByThresholdReportingCategoryName(this IQueryable<ThresholdReportingCategory> thresholdReportingCategories, string thresholdReportingCategoryName)
        {
            var thresholdReportingCategory = thresholdReportingCategories.SingleOrDefault(x => x.ThresholdReportingCategoryName == thresholdReportingCategoryName);
            Check.RequireNotNullThrowNotFound(thresholdReportingCategory, "Threshold Reporting Category", thresholdReportingCategoryName);
            return thresholdReportingCategory;
        }
    }
}