
using System.Collections.Generic;

namespace ProjectFirmaModels.Models.DataTransferObjects
{
    public class ProjectIndicatorReportedValueSimpleDto
    {
        public int ProjectIndicatorReportedValueID { get; set; }
        public int ProjectID { get; set; }
        public int IndicatorID { get; set; }
        public int CalendarYear { get; set; }
        public double ActualValue { get; set; }
        public IndicatorSimpleDto Indicator { get; set; }
        public List<ProjectIndicatorReportedValueSubcategoryOptionSimpleDto> ProjectIndicatorReportedValueSubcategoryOptions { get; set; }
    }

}