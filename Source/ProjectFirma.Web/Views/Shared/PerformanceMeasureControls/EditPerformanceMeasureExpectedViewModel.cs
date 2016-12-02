using System.Collections.Generic;
using System.Linq;
using LtInfo.Common.Models;
using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.Views.Shared.PerformanceMeasureControls
{
    public class EditPerformanceMeasureExpectedViewModel : FormViewModel
    {
        public List<PerformanceMeasureExpectedSimple> PerformanceMeasureExpecteds { get; set; }

        /// <summary>
        /// Needed by the ModelBinder
        /// </summary>
        public EditPerformanceMeasureExpectedViewModel()
        {
            PerformanceMeasureExpecteds = new List<PerformanceMeasureExpectedSimple>();
        }

        public EditPerformanceMeasureExpectedViewModel(List<PerformanceMeasureExpectedSimple> performanceMeasureExpecteds)
        {
            PerformanceMeasureExpecteds = performanceMeasureExpecteds;
        }

        public void UpdateModel(List<PerformanceMeasureExpected> currentPerformanceMeasureExpecteds,
            IList<PerformanceMeasureExpected> allPerformanceMeasureExpecteds,
            IList<PerformanceMeasureExpectedSubcategoryOption> allPerformanceMeasureExpectedSubcategoryOptions)
        {
            // Remove all existing associations
            currentPerformanceMeasureExpecteds.ForEach(pmav =>
            {
                pmav.PerformanceMeasureExpectedSubcategoryOptions.ToList().ForEach(pmavso => allPerformanceMeasureExpectedSubcategoryOptions.Remove(pmavso));
                allPerformanceMeasureExpecteds.Remove(pmav);
            });
            currentPerformanceMeasureExpecteds.Clear();

            if (PerformanceMeasureExpecteds != null)
            {
                // Completely rebuild the list
                foreach (var x in PerformanceMeasureExpecteds)
                {
                    var performanceMeasureExpected = new PerformanceMeasureExpected(x.ProjectID, x.PerformanceMeasureID) {ExpectedValue = x.ExpectedValue};
                    allPerformanceMeasureExpecteds.Add(performanceMeasureExpected);                                   
                    if (x.PerformanceMeasureExpectedSubcategoryOptions != null)
                    {
                        x.PerformanceMeasureExpectedSubcategoryOptions.Where(y => ModelObjectHelpers.IsRealPrimaryKeyValue(y.PerformanceMeasureSubcategoryOptionID))
                            .ToList()
                            .ForEach(
                                y =>
                                    allPerformanceMeasureExpectedSubcategoryOptions.Add(
                                        new PerformanceMeasureExpectedSubcategoryOption(performanceMeasureExpected.PerformanceMeasureExpectedID,
                                            y.PerformanceMeasureSubcategoryOptionID,
                                            y.PerformanceMeasureID,
                                            y.PerformanceMeasureSubcategoryID)));
                    }
                }
            }
        }        
    }
}