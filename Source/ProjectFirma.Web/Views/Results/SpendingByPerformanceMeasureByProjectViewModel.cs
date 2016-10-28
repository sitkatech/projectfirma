using System.ComponentModel;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Views.Results
{
    public class SpendingByPerformanceMeasureByProjectViewModel : FormViewModel
    {
        [DisplayName("Performance Measure ID")]
        public int? PerformanceMeasureID { get; set; }

        [DisplayName("Performance Measure")]
        public Models.PerformanceMeasure PerformanceMeasure { get; set; }

        /// <summary>
        /// Needed by Model Binder
        /// </summary>
        public SpendingByPerformanceMeasureByProjectViewModel()
        {
        }

        public SpendingByPerformanceMeasureByProjectViewModel(int? performanceMeasureID, Models.PerformanceMeasure performanceMeasure)
        {
            PerformanceMeasureID = performanceMeasureID;
            PerformanceMeasure = performanceMeasure;
        }
    }
}