/*-----------------------------------------------------------------------
<copyright file="EditPerformanceMeasureMonitoringProgramsViewModel.cs" company="Sitka Technology Group">
Copyright (c) Sitka Technology Group. All rights reserved.
<author>Sitka Technology Group</author>
<date>Wednesday, February 22, 2017</date>
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
using ProjectFirma.Web.Models;
using LtInfo.Common;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Views.PerformanceMeasureMonitoringProgram
{
    public class EditPerformanceMeasureMonitoringProgramsViewModel : FormViewModel
    {
        public List<PerformanceMeasureMonitoringProgramSimple> PerformanceMeasureMonitoringPrograms { get; set; }

        /// <summary>
        /// Needed by the ModelBinder
        /// </summary>
        public EditPerformanceMeasureMonitoringProgramsViewModel()
        {
        }

        public EditPerformanceMeasureMonitoringProgramsViewModel(List<PerformanceMeasureMonitoringProgramSimple> performanceMeasureMonitoringPrograms)
        {
            PerformanceMeasureMonitoringPrograms = performanceMeasureMonitoringPrograms;
        }

        public void UpdateModel(List<Models.PerformanceMeasureMonitoringProgram> currentPerformanceMeasureMonitoringPrograms, IList<Models.PerformanceMeasureMonitoringProgram> allPerformanceMeasureMonitoringPrograms)
        {
            var performanceMeasureMonitoringProgramsUpdated = new List<Models.PerformanceMeasureMonitoringProgram>();
            if (PerformanceMeasureMonitoringPrograms != null)
            {
                // Completely rebuild the list
                performanceMeasureMonitoringProgramsUpdated = PerformanceMeasureMonitoringPrograms.Select(x => new Models.PerformanceMeasureMonitoringProgram(x.PerformanceMeasureID, x.MonitoringProgramID)).ToList();
            }
            currentPerformanceMeasureMonitoringPrograms.Merge(performanceMeasureMonitoringProgramsUpdated, allPerformanceMeasureMonitoringPrograms, (x, y) => x.MonitoringProgramID == y.MonitoringProgramID && x.PerformanceMeasureID == y.PerformanceMeasureID);
        }
    }
}
