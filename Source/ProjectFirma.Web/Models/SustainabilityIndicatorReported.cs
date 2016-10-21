using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace ProjectFirma.Web.Models
{
    public partial class SustainabilityIndicatorReported : IAuditableEntity, IIndicatorReported
    {
        public int SortOrder
        {
            get
            {
                if (SustainabilityIndicatorReportedSubcategoryOptions.Any())
                {
                    return SustainabilityIndicatorReportedSubcategoryOptions.OrderBy(x => x.IndicatorSubcategoryOption.SortOrder).First().IndicatorSubcategoryOption.SortOrder ?? 0;
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
            get { return SustainabilityIndicatorReportingPeriod; }
        }

        public IIndicatorWithOnlyOneSubcategoryAndNotReportedInEIP IndicatorWithOnlyOneSubcategoryAndNotReportedInEIP
        {
            get { return SustainabilityIndicator; }
        }

        public List<IIndicatorReportedSubcategoryOption> IndicatorReportedSubcategoryOptions
        {
            get { return new List<IIndicatorReportedSubcategoryOption>(SustainabilityIndicatorReportedSubcategoryOptions); }
        }
    }
}