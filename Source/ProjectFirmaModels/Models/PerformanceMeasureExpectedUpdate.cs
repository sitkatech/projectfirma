using System;
using System.Collections.Generic;
using System.Linq;
using LtInfo.Common.Views;

namespace ProjectFirmaModels.Models
{
    public partial class PerformanceMeasureExpectedUpdate : IPerformanceMeasureValue
    {
        public string GetPerformanceMeasureSubcategoriesAsString()
        {
            if (PerformanceMeasure.HasRealSubcategories())
            {
                return PerformanceMeasureExpectedSubcategoryOptionUpdates.Any()
                    ? String.Join("\r\n",
                        PerformanceMeasureExpectedSubcategoryOptionUpdates.OrderBy(x =>
                                x.PerformanceMeasureSubcategory.PerformanceMeasureSubcategoryDisplayName)
                            .Select(x =>
                                $"{x.PerformanceMeasureSubcategory.PerformanceMeasureSubcategoryDisplayName}: {x.PerformanceMeasureSubcategoryOption.PerformanceMeasureSubcategoryOptionName}"))
                    : ViewUtilities.NoneString;
            }

            return string.Empty;
        }

        public List<IPerformanceMeasureValueSubcategoryOption> GetPerformanceMeasureSubcategoryOptions()
        {
            return new List<IPerformanceMeasureValueSubcategoryOption>(PerformanceMeasureExpectedSubcategoryOptionUpdates.ToList());
        }

        public double? GetReportedValue()
        {
            return ExpectedValue;
        }
    }
}