using System.Collections.Generic;
using System.Linq;
using ProjectFirma.Web.Common;
using LtInfo.Common.Views;

namespace ProjectFirma.Web.Models
{
    public partial class PerformanceMeasureActual : IAuditableEntity, IPerformanceMeasureValue
    {
        public string ActualValueDisplay
        {
            get { return GetActualValueDisplay(ActualValue, PerformanceMeasure); }
        }

        private static string GetActualValueDisplay(double expectedValue, PerformanceMeasure performanceMeasure)
        {
            return performanceMeasure.MeasurementUnitType.DisplayValue(expectedValue);
        }

        public string AuditDescriptionString
        {
            get
            {
                var project = HttpRequestStorage.DatabaseEntities.Projects.Find(ProjectID);
                var performanceMeasure = HttpRequestStorage.DatabaseEntities.PerformanceMeasures.Find(PerformanceMeasureID);
                var projectName = project != null ? project.AuditDescriptionString : ViewUtilities.NotFoundString;
                var performanceMeasureName = performanceMeasure != null ? performanceMeasure.AuditDescriptionString : ViewUtilities.NotFoundString;
                var actualValue = GetActualValueDisplay(ActualValue, performanceMeasure);
                return string.Format("Project: {0}, Performance Measure: {1}, Actual Value: {2}", projectName, performanceMeasureName, actualValue);
            }
        }

        public List<IPerformanceMeasureValueSubcategoryOption> PerformanceMeasureSubcategoryOptions
        {
            get { return new List<IPerformanceMeasureValueSubcategoryOption>(PerformanceMeasureActualSubcategoryOptions.ToList()); }
        }
        public double? ReportedValue
        {
            get { return ActualValue; }
        }

        public string PerformanceMeasureSubcategoriesAsString
        {
            get
            {
                if (PerformanceMeasure.HasRealSubcategories)
                {
                    return PerformanceMeasureActualSubcategoryOptions.Any()
                        ? string.Join("\r\n",
                            PerformanceMeasureActualSubcategoryOptions.OrderBy(x => x.PerformanceMeasureSubcategory.PerformanceMeasureSubcategoryDisplayName)
                                .Select(x => string.Format("{0}: {1}", x.PerformanceMeasureSubcategory.PerformanceMeasureSubcategoryDisplayName, x.PerformanceMeasureSubcategoryOption.PerformanceMeasureSubcategoryOptionName)))
                        : ViewUtilities.NoneString;
                }
                else
                {
                    return string.Empty;
                }
        }
        }
    }
}