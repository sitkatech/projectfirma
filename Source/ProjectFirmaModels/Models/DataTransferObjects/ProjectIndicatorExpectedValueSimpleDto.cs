

using System.Collections.Generic;

namespace ProjectFirmaModels.Models.DataTransferObjects
{

    public class ProjectIndicatorExpectedValueSimpleDto
    {
        public int ProjectIndicatorExpectedValueID { get; set; }
        public int ProjectID { get; set; }
        public int IndicatorID { get; set; }
        public double? ExpectedValue { get; set; }
        public IndicatorSimpleDto Indicator { get; set; }
        public List<ProjectIndicatorExpectedValueSubcategoryOptionSimpleDto> ProjectIndicatorExpectedValueSubcategoryOptions { get; set; }
    }

}