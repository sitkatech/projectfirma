using System.Collections.Generic;
using System.Linq;

namespace ProjectFirma.Web.Views.ProjectUpdate
{
    public class BudgetsValidationResult
    {
        private readonly List<string> _warningMessages;

        public BudgetsValidationResult()
        {
            _warningMessages = new List<string>();
        }

        public BudgetsValidationResult(Dictionary<Models.FundingSource, HashSet<int>> missingFundingSourceYears)
            : this(missingFundingSourceYears, new List<int>())
        {
        }

        public BudgetsValidationResult(List<int> missingYears)
            : this(new Dictionary<Models.FundingSource, HashSet<int>>(), missingYears)
        {
        }

        public BudgetsValidationResult(Dictionary<Models.FundingSource, HashSet<int>> missingFundingSourceYears, List<int> missingYears) :this()
        {
            if (missingYears.Any())
            {
                _warningMessages.Add(string.Format("Missing Budget Amounts for {0}", string.Join(", ", missingYears)));
            }

            if (missingFundingSourceYears.Any())
            {
                _warningMessages.AddRange(
                    missingFundingSourceYears.Select(
                        missingFundingSourceYear =>
                            string.Format("Missing Budget Amounts for Funding Source '{0}' for the following years: {1}",
                                missingFundingSourceYear.Key.DisplayName,
                                string.Join(", ", missingFundingSourceYear.Value))).ToList());
            }
        }

        public BudgetsValidationResult(string customErrorMessage)
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