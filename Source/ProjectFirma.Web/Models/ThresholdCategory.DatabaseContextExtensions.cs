using System.Linq;
using LtInfo.Common.DesignByContract;

namespace ProjectFirma.Web.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static ThresholdCategory GetThresholdCategoryByThresholdCategoryeName(this IQueryable<ThresholdCategory> thresholdCategories, string thresholdCategoryName)
        {
            var thresholdCategory = thresholdCategories.SingleOrDefault(x => x.ThresholdCategoryName == thresholdCategoryName);
            Check.RequireNotNullThrowNotFound(thresholdCategory, "Threshold Category", thresholdCategoryName);
            return thresholdCategory;
        }
    }
}