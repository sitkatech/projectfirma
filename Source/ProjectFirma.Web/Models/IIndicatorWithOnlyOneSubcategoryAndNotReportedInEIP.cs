using System.Collections.Generic;

namespace ProjectFirma.Web.Models
{
    public interface IIndicatorWithOnlyOneSubcategoryAndNotReportedInEIP
    {
        Indicator Indicator { get; }
        IndicatorSubcategory IndicatorSubcategory { get; }
        bool UseCustomDateRange { get; }
        List<IIndicatorReportingPeriod> GetIndicatorReportingPeriods();
        List<IIndicatorReported> GetIndicatorReportedValues();
        string GetChartPopupUrl();
    }
}