/*-----------------------------------------------------------------------
<copyright file="ExpectedPerformanceMeasureValuesViewModel.cs" company="Tahoe Regional Planning Agency">
Copyright (c) Tahoe Regional Planning Agency. All rights reserved.
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
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using ProjectFirmaModels.Models;
using LtInfo.Common.Models;
using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.Views.ProjectUpdate
{
    public class ExpectedPerformanceMeasuresViewModel : FormViewModel
    {
        [DisplayName("Review Comments")]
        [StringLength(ProjectUpdateBatch.FieldLengths.ExpectedPerformanceMeasuresComment)]
        public string Comments { get; set; }

        public List<PerformanceMeasureExpectedSimple> PerformanceMeasureExpecteds { get; set; }

        /// <summary>
        /// Needed by the ModelBinder
        /// </summary>
        public ExpectedPerformanceMeasuresViewModel()
        {
            PerformanceMeasureExpecteds = new List<PerformanceMeasureExpectedSimple>();
        }

        public ExpectedPerformanceMeasuresViewModel(List<PerformanceMeasureExpectedSimple> performanceMeasureExpecteds, string comments)
        {
            PerformanceMeasureExpecteds = performanceMeasureExpecteds.ToList();
            Comments = comments;
        }

        public virtual void UpdateModel(List<PerformanceMeasureExpectedUpdate> currentPerformanceMeasureExpectedUpdates, IList<PerformanceMeasureExpectedUpdate> allPerformanceMeasureExpectedUpdates, IList<PerformanceMeasureExpectedSubcategoryOptionUpdate> allPerformanceMeasureExpectedSubcategoryOptionUpdates, ProjectFirmaModels.Models.ProjectUpdateBatch projectUpdateBatch)
        {
            // Remove all existing associations
            currentPerformanceMeasureExpectedUpdates.ForEach(pmav =>
            {
                pmav.PerformanceMeasureExpectedSubcategoryOptionUpdates.ToList().ForEach(pmavso => allPerformanceMeasureExpectedSubcategoryOptionUpdates.Remove(pmavso));
                allPerformanceMeasureExpectedUpdates.Remove(pmav);
            });
            currentPerformanceMeasureExpectedUpdates.Clear();

            if (PerformanceMeasureExpecteds != null)
            {
                // Completely rebuild the list
                foreach (var x in PerformanceMeasureExpecteds)
                {
                    var performanceMeasureExpected = new PerformanceMeasureExpectedUpdate(projectUpdateBatch.ProjectUpdateBatchID, x.PerformanceMeasureID) { ExpectedValue = x.ExpectedValue };
                    allPerformanceMeasureExpectedUpdates.Add(performanceMeasureExpected);
                    if (x.PerformanceMeasureExpectedSubcategoryOptions != null)
                    {
                        x.PerformanceMeasureExpectedSubcategoryOptions.Where(y => ModelObjectHelpers.IsRealPrimaryKeyValue(y.PerformanceMeasureSubcategoryOptionID))
                            .ToList()
                            .ForEach(
                                y =>
                                    allPerformanceMeasureExpectedSubcategoryOptionUpdates.Add(
                                        new PerformanceMeasureExpectedSubcategoryOptionUpdate(performanceMeasureExpected.PerformanceMeasureExpectedUpdateID,
                                            y.PerformanceMeasureSubcategoryOptionID,
                                            y.PerformanceMeasureID,
                                            y.PerformanceMeasureSubcategoryID)));
                    }
                }
            }
        }
    }
}
