using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace ProjectFirma.Web.Models
{
    public partial class ThresholdIndicatorReported : IAuditableEntity, IIndicatorReported
    {
        public int SortOrder
        {
            get
            {
                if (ThresholdIndicatorReportedSubcategoryOptions.Any())
                {
                    return ThresholdIndicatorReportedSubcategoryOptions.OrderBy(x => x.IndicatorSubcategoryOption.SortOrder).First().IndicatorSubcategoryOption.SortOrder ?? 0;
                }
                return 0;
            }
        }

        public string AuditDescriptionString
        {
            get { return ReportedValue.ToString(CultureInfo.InvariantCulture); }
        }

        public IIndicatorReportingPeriod IndicatorReportingPeriod
        {
            get { return ThresholdIndicatorReportingPeriod; }
        }

        public IIndicatorWithOnlyOneSubcategoryAndNotReportedInEIP IndicatorWithOnlyOneSubcategoryAndNotReportedInEIP
        {
            get { return ThresholdIndicator; }
        }

        public List<IIndicatorReportedSubcategoryOption> IndicatorReportedSubcategoryOptions
        {
            get { return new List<IIndicatorReportedSubcategoryOption>(ThresholdIndicatorReportedSubcategoryOptions); }
        }
    }
}