using System.ComponentModel;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Areas.EIP.Views.Results
{
    public class SpendingByEIPPerformanceMeasureByProjectViewModel : FormViewModel
    {
        [DisplayName("Performance Measure ID")]
        public int? EIPPerformanceMeasureID { get; set; }

        [DisplayName("Performance Measure")]
        public Models.EIPPerformanceMeasure EIPPerformanceMeasure { get; set; }

        /// <summary>
        /// Needed by Model Binder
        /// </summary>
        public SpendingByEIPPerformanceMeasureByProjectViewModel()
        {
        }

        public SpendingByEIPPerformanceMeasureByProjectViewModel(int? eipPerformanceMeasureID, Models.EIPPerformanceMeasure eipPerformanceMeasure)
        {
            EIPPerformanceMeasureID = eipPerformanceMeasureID;
            EIPPerformanceMeasure = eipPerformanceMeasure;
        }
    }
}