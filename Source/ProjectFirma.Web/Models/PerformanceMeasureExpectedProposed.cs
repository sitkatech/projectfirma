using System;
using System.Collections.Generic;
using System.Linq;
using ProjectFirma.Web.Common;
using LtInfo.Common.Views;

namespace ProjectFirma.Web.Models
{
    public partial class PerformanceMeasureExpectedProposed : IAuditableEntity, IPerformanceMeasureValue
    {
        public string ExpectedValueDisplay
        {
            get { return GetExpectedValueDisplay(ExpectedValue, PerformanceMeasure); }
        }

        private static string GetExpectedValueDisplay(double? expectedValue, PerformanceMeasure performanceMeasure)
        {
            return performanceMeasure.MeasurementUnitType.DisplayValue(expectedValue);
        }

        public string AuditDescriptionString
        {
            get
            {
                var project = HttpRequestStorage.DatabaseEntities.AllProposedProjects.Find(ProposedProjectID);
                var performanceMeasure = HttpRequestStorage.DatabaseEntities.AllPerformanceMeasures.Find(PerformanceMeasureID);
                var projectName = project != null ? project.AuditDescriptionString : ViewUtilities.NotFoundString;
                var performanceMeasureName = performanceMeasure != null ? performanceMeasure.AuditDescriptionString : ViewUtilities.NotFoundString;
                var expectedValue = GetExpectedValueDisplay(ExpectedValue, performanceMeasure);
                return String.Format("Proposed Project: {0}, Performance Measure: {1}, Expected Value: {2}", projectName, performanceMeasureName, expectedValue);
            }
        }

        public string PerformanceMeasureSubcategoriesAsString
        {
            get
            {
                return PerformanceMeasureExpectedSubcategoryOptionProposeds.Any()
                    ? String.Join(", ",
                        PerformanceMeasureExpectedSubcategoryOptionProposeds.OrderBy(x => x.PerformanceMeasureSubcategory.PerformanceMeasureSubcategoryDisplayName)
                            .Select(x => String.Format("[{0}: {1}]", x.PerformanceMeasureSubcategory.PerformanceMeasureSubcategoryDisplayName, x.PerformanceMeasureSubcategoryOption.PerformanceMeasureSubcategoryOptionName)))
                    : ViewUtilities.NoneString;
            }
        }

        public List<IPerformanceMeasureValueSubcategoryOption> PerformanceMeasureSubcategoryOptions
        {
            get { return new List<IPerformanceMeasureValueSubcategoryOption>(PerformanceMeasureExpectedSubcategoryOptionProposeds.ToList()); }
        }
        public double? ReportedValue
        {
            get { return ExpectedValue; }
        }
    }
}