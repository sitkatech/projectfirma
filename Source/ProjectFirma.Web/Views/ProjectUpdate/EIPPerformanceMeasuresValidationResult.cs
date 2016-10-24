using System.Collections.Generic;
using System.Linq;

namespace ProjectFirma.Web.Views.ProjectUpdate
{
    public class EIPPerformanceMeasuresValidationResult
    {
        public const string FoundIncompleteEIPPerformanceMeasureRowsMessage =
            "Found incomplete Performance Measure (PM) rows. You must either delete irrelevant PM rows, or provide complete information for each PM row.";

        private readonly List<string> _warningMessages;

        public readonly HashSet<int> EIPPerformanceMeasureActualUpdatesWithWarnings;

        public EIPPerformanceMeasuresValidationResult(HashSet<int> missingYears, HashSet<int> eipPerformanceMeasureActualUpdatesWithWarnings)
        {
            EIPPerformanceMeasureActualUpdatesWithWarnings = eipPerformanceMeasureActualUpdatesWithWarnings;
            _warningMessages = new List<string>();
            if (missingYears.Any())
            {
                _warningMessages.Add(string.Format("Missing Performance Measures for {0}", string.Join(", ", missingYears)));
            }
            if (eipPerformanceMeasureActualUpdatesWithWarnings.Any())
            {
                _warningMessages.Add(FoundIncompleteEIPPerformanceMeasureRowsMessage);
            }
        }

        public EIPPerformanceMeasuresValidationResult(string customErrorMessage)
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