using System.Collections.Generic;
using ProjectFirma.Web.Models;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Views.IndicatorRelationship
{
    public class EditViewModel : FormViewModel
    {
        public List<IndicatorThresholdReportingCategorySimple> IndicatorRelationships { get; set; }

        /// <summary>
        /// Needed by the ModelBinder
        /// </summary>
        public EditViewModel()
        {
        }

        public EditViewModel(List<IndicatorThresholdReportingCategorySimple> indicatorRelationships)
        {
            IndicatorRelationships = indicatorRelationships;
        }
    }
}