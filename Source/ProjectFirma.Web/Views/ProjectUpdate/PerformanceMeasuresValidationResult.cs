using System.Collections.Generic;
using System.Linq;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Views.ProjectUpdate
{
    public class PerformanceMeasuresValidationResult
    {
        public static readonly string FoundIncompletePerformanceMeasureRowsMessage = string.Format("Found incomplete {0} rows. You must either delete irrelevant rows, or provide complete information for each row.", MultiTenantHelpers.GetPerformanceMeasureName());

        private readonly List<string> _warningMessages;

        public readonly HashSet<int> PerformanceMeasureActualUpdatesWithWarnings;

        public PerformanceMeasuresValidationResult(HashSet<int> missingYears, HashSet<int> performanceMeasureActualUpdatesWithWarnings)
        {
            PerformanceMeasureActualUpdatesWithWarnings = performanceMeasureActualUpdatesWithWarnings;
            _warningMessages = new List<string>();
            if (missingYears.Any())
            {
                _warningMessages.Add(string.Format("Missing {0} for {1}", MultiTenantHelpers.GetPerformanceMeasureName(), string.Join(", ", missingYears)));
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