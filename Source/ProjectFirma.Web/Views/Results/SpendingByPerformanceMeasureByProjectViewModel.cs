using LtInfo.Common.Models;

namespace ProjectFirma.Web.Views.Results
{
    public class SpendingByPerformanceMeasureByProjectViewModel : FormViewModel
    {
        public int? PerformanceMeasureID { get; set; }

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