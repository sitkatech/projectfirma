using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using ProjectFirma.Web.Models;
using LtInfo.Common;

namespace ProjectFirma.Web.Views.Shared
{
    public class IndicatorReportedBulk
    {
        [Required]
        public int IndicatorReportingPeriodID { get; set; }
        [Required]
        [StringLength(SustainabilityIndicatorReportingPeriod.FieldLengths.SustainabilityIndicatorReportingPeriodLabel)]
        public string IndicatorReportingPeriodLabel { get; set; }
        [Required]
        public string IndicatorReportingPeriodBeginDate { get; set; }
        [Required]
        public string IndicatorReportingPeriodEndDate { get; set; }
        public int? IndicatorSubcategoryID { get; set; }
        [Required]
        public List<ReportedValueForDisplay> ReportedValuesForDisplay { get; set; }

        public double? TargetValue { get; set; }
        public string TargetValueDescription { get; set; }

        /// <summary>
        /// Needed by ModelBinder
        /// </summary>
        public IndicatorReportedBulk()
        {
        }

        public IndicatorReportedBulk(IIndicatorReported sustainabilityIndicatorReported, List<IIndicatorReported> sustainabilityIndicatorReporteds)
        {
            IndicatorReportingPeriodID = sustainabilityIndicatorReported.IndicatorReportingPeriod.ReportingPeriodID;
            IndicatorReportingPeriodLabel = sustainabilityIndicatorReported.IndicatorReportingPeriod.ReportingPeriodLabel;
            IndicatorReportingPeriodBeginDate = sustainabilityIndicatorReported.IndicatorReportingPeriod.ReportingPeriodBeginDate.ToStringDate();
            IndicatorReportingPeriodEndDate = sustainabilityIndicatorReported.IndicatorReportingPeriod.ReportingPeriodEndDate.ToStringDate();

            IndicatorSubcategoryID = sustainabilityIndicatorReported.IndicatorWithOnlyOneSubcategoryAndNotReportedInEIP.IndicatorSubcategory.IndicatorSubcategoryID;
            ReportedValuesForDisplay = new List<ReportedValueForDisplay>();
            TargetValue = sustainabilityIndicatorReported.IndicatorReportingPeriod.TargetValue;
            TargetValueDescription = sustainabilityIndicatorReported.IndicatorReportingPeriod.TargetValueDescription;
            sustainabilityIndicatorReporteds.ForEach(x =>
            {
                ReportedValuesForDisplay.Add(new ReportedValueForDisplay(x));
            });
        }

        public static List<IndicatorReportedBulk> MakeFromList(List<IIndicatorReported> indicatorReporteds)
        {
            var groupedByNameAndReportingPeriod = indicatorReporteds.GroupBy(x => new { x.IndicatorWithOnlyOneSubcategoryAndNotReportedInEIP.Indicator.IndicatorID, x.IndicatorReportingPeriod.ReportingPeriodID });
            return groupedByNameAndReportingPeriod.Select(grouping => new IndicatorReportedBulk(grouping.First(), grouping.ToList())).ToList();
        }
    }
}