using System.Collections.Generic;
using System.Linq;
using ProjectFirma.Web.Models;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Areas.EIP.Views.Shared.EIPPerformanceMeasureControls
{
    public class EditEIPPerformanceMeasureExpectedViewModel : FormViewModel
    {
        public List<EIPPerformanceMeasureExpectedSimple> EIPPerformanceMeasureExpecteds { get; set; }

        /// <summary>
        /// Needed by the ModelBinder
        /// </summary>
        public EditEIPPerformanceMeasureExpectedViewModel()
        {
            EIPPerformanceMeasureExpecteds = new List<EIPPerformanceMeasureExpectedSimple>();
        }

        public EditEIPPerformanceMeasureExpectedViewModel(List<EIPPerformanceMeasureExpectedSimple> eipPerformanceMeasureExpecteds)
        {
            EIPPerformanceMeasureExpecteds = eipPerformanceMeasureExpecteds;
        }

        public void UpdateModel(List<EIPPerformanceMeasureExpected> currentEIPPerformanceMeasureExpecteds,
            IList<EIPPerformanceMeasureExpected> allEIPPerformanceMeasureExpecteds,
            IList<EIPPerformanceMeasureExpectedSubcategoryOption> allEIPPerformanceMeasureExpectedSubcategoryOptions)
        {
            // Remove all existing associations
            currentEIPPerformanceMeasureExpecteds.ForEach(pmav =>
            {
                pmav.EIPPerformanceMeasureExpectedSubcategoryOptions.ToList().ForEach(pmavso => allEIPPerformanceMeasureExpectedSubcategoryOptions.Remove(pmavso));
                allEIPPerformanceMeasureExpecteds.Remove(pmav);
            });
            currentEIPPerformanceMeasureExpecteds.Clear();

            if (EIPPerformanceMeasureExpecteds != null)
            {
                // Completely rebuild the list
                foreach (var x in EIPPerformanceMeasureExpecteds)
                {
                    var eipPerformanceMeasureExpected = new EIPPerformanceMeasureExpected(x.ProjectID, x.EIPPerformanceMeasureID) {ExpectedValue = x.ExpectedValue};
                    allEIPPerformanceMeasureExpecteds.Add(eipPerformanceMeasureExpected);                                   
                    if (x.EIPPerformanceMeasureExpectedSubcategoryOptions != null)
                    {
                        x.EIPPerformanceMeasureExpectedSubcategoryOptions.Where(y => ModelObjectHelpers.IsRealPrimaryKeyValue(y.IndicatorSubcategoryOptionID))
                            .ToList()
                            .ForEach(
                                y =>
                                    allEIPPerformanceMeasureExpectedSubcategoryOptions.Add(
                                        new EIPPerformanceMeasureExpectedSubcategoryOption(eipPerformanceMeasureExpected.EIPPerformanceMeasureExpectedID,
                                            y.IndicatorSubcategoryOptionID,
                                            y.EIPPerformanceMeasureID,
                                            y.IndicatorSubcategoryID)));
                    }
                }
            }
        }        
    }
}