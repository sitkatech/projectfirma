/*-----------------------------------------------------------------------
<copyright file="EditPerformanceMeasureExpectedViewModel.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
Copyright (c) Tahoe Regional Planning Agency and Sitka Technology Group. All rights reserved.
<author>Sitka Technology Group</author>
</copyright>

<license>
This program is free software: you can redistribute it and/or modify
it under the terms of the GNU Affero General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU Affero General Public License <http://www.gnu.org/licenses/> for more details.

Source code is available upon request via <support@sitkatech.com>.
</license>
-----------------------------------------------------------------------*/
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

        public void UpdateModel(List<PerformanceMeasureExpected> currentPerformanceMeasureExpecteds, IList<PerformanceMeasureExpected> allPerformanceMeasureExpecteds, IList<PerformanceMeasureExpectedSubcategoryOption> allPerformanceMeasureExpectedSubcategoryOptions, Models.Project project)
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
                    var performanceMeasureExpected = new PerformanceMeasureExpected(project.ProjectID, x.PerformanceMeasureID) {ExpectedValue = x.ExpectedValue};
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
