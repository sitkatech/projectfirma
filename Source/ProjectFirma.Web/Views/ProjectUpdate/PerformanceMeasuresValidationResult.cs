using System.Collections.Generic;
using System.Linq;

namespace ProjectFirma.Web.Views.ProjectUpdate
{
    public class PerformanceMeasuresValidationResult
    {
        public const string FoundIncompletePerformanceMeasureRowsMessage =
            "Found incomplete Performance Measure (PM) rows. You must either delete irrelevant PM rows, or provide complete information for each PM row.";

        private readonly List<string> _warningMessages;

        public readonly HashSet<int> PerformanceMeasureActualUpdatesWithWarnings;

        public PerformanceMeasuresValidationResult(HashSet<int> missingYears, HashSet<int> performanceMeasureActualUpdatesWithWarnings)
        {
            PerformanceMeasureActualUpdatesWithWarnings = performanceMeasureActualUpdatesWithWarnings;
            _warningMessages = new List<string>();
            if (missingYears.Any())
            {
                _warningMessages.Add(string.Format("Missing Performance Measures for {0}", string.Join(", ", missingYears)));
            }
            if (performanceMeasureActualUpdatesWithWarnings.Any())
            {
                _warningMessages.Add(FoundIncompletePerformanceMeasureRowsMessage);
            }
        }

        public PerformanceMeasuresValidationResult(string customErrorMessage)
        {
            _warningMessages = new List<string> {customErrorMessage};
        }

        public List<string> GetWarningMessages()
        {
            return _warningMessages;
        }

        public bool IsValid
        {
            get { return !_warningMessages.Any(); }
        }
    }
}