using System.Collections.Generic;
using System.Linq;

namespace ProjectFirma.Web.Areas.EIP.Views.ProjectUpdate
{
    public class ExpendituresValidationResult
    {
        private readonly List<string> _warningMessages;

        public ExpendituresValidationResult(Dictionary<Models.FundingSource, HashSet<int>> missingFundingSourceYears)
            : this(missingFundingSourceYears, new List<int>())
        {
        }

        public ExpendituresValidationResult(List<int> missingYears)
            : this(new Dictionary<Models.FundingSource, HashSet<int>>(), missingYears)
        {
        }

        public ExpendituresValidationResult(Dictionary<Models.FundingSource, HashSet<int>> missingFundingSourceYears, List<int> missingYears)
        {
            _warningMessages = new List<string>();
            if (missingYears.Any())
            {
                _warningMessages.Add(string.Format("Missing Expenditures for {0}", string.Join(", ", missingYears)));
            }

            if (missingFundingSourceYears.Any())
            {
                _warningMessages.AddRange(
                    missingFundingSourceYears.Select(
                        missingFundingSourceYear =>
                            string.Format("Missing Expenditures for Funding Source '{0}' for the following years: {1}",
                                missingFundingSourceYear.Key.DisplayName,
                                string.Join(", ", missingFundingSourceYear.Value))).ToList());
            }
        }

        public ExpendituresValidationResult(string customErrorMessage)
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