using System.Collections.Generic;
using System.Linq;
using ProjectFirma.Web.Common;
using LtInfo.Common.Views;

namespace ProjectFirma.Web.Models
{
    public partial class EIPPerformanceMeasureActual : IAuditableEntity, IEIPPerformanceMeasureValue
    {
        public string ActualValueDisplay
        {
            get { return GetActualValueDisplay(ActualValue, EIPPerformanceMeasure); }
        }

        private static string GetActualValueDisplay(double expectedValue, EIPPerformanceMeasure eipPerformanceMeasure)
        {
            return eipPerformanceMeasure.Indicator.MeasurementUnitType.DisplayValue(expectedValue);
        }

        public string AuditDescriptionString
        {
            get
            {
                var project = HttpRequestStorage.DatabaseEntities.Projects.Find(ProjectID);
                var eipPerformanceMeasure = HttpRequestStorage.DatabaseEntities.EIPPerformanceMeasures.Find(EIPPerformanceMeasureID);
                var projectName = project != null ? project.AuditDescriptionString : ViewUtilities.NotFoundString;
                var eipPerformanceMeasureName = eipPerformanceMeasure != null ? eipPerformanceMeasure.AuditDescriptionString : ViewUtilities.NotFoundString;
                var actualValue = GetActualValueDisplay(ActualValue, eipPerformanceMeasure);
                return string.Format("Project: {0}, Performance Measure: {1}, Actual Value: {2}", projectName, eipPerformanceMeasureName, actualValue);
            }
        }

        public List<IEIPPerformanceMeasureValueSubcategoryOption> IndicatorSubcategoryOptions
        {
            get { return new List<IEIPPerformanceMeasureValueSubcategoryOption>(EIPPerformanceMeasureActualSubcategoryOptions.ToList()); }
        }
        public double? ReportedValue
        {
            get { return ActualValue; }
        }

        public string IndicatorSubcategoriesAsString
        {
            get
            {
                if (EIPPerformanceMeasure.Indicator.HasRealSubcategories)
                {
                    return EIPPerformanceMeasureActualSubcategoryOptions.Any()
                        ? string.Join("\r\n",
                            EIPPerformanceMeasureActualSubcategoryOptions.OrderBy(x => x.IndicatorSubcategory.IndicatorSubcategoryDisplayName)
                                .Select(x => string.Format("{0}: {1}", x.IndicatorSubcategory.IndicatorSubcategoryDisplayName, x.IndicatorSubcategoryOption.IndicatorSubcategoryOptionName)))
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