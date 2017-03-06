/*-----------------------------------------------------------------------
<copyright file="PerformanceMeasureMonitoringProgramSimple.cs" company="Tahoe Regional Planning Agency">
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
namespace ProjectFirma.Web.Models
{
    public class PerformanceMeasureMonitoringProgramSimple
    {
        /// <summary>
        /// Needed by ModelBinder
        /// </summary>
        public PerformanceMeasureMonitoringProgramSimple()
        {
        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public PerformanceMeasureMonitoringProgramSimple(int monitoringProgramPartnerID, int performanceMeasureID, int monitoringProgramID)
            : this()
        {
            MonitoringProgramPartnerID = monitoringProgramPartnerID;
            PerformanceMeasureID = performanceMeasureID;
            MonitoringProgramID = monitoringProgramID;
        }

        /// <summary>
        /// Constructor for building a new simple object with the POCO class
        /// </summary>
        public PerformanceMeasureMonitoringProgramSimple(PerformanceMeasureMonitoringProgram performanceMeasureMonitoringProgram)
            : this()
        {
            MonitoringProgramPartnerID = performanceMeasureMonitoringProgram.PerformanceMeasureMonitoringProgramID;
            PerformanceMeasureID = performanceMeasureMonitoringProgram.PerformanceMeasureID;
            MonitoringProgramID = performanceMeasureMonitoringProgram.MonitoringProgramID;
        }

        public int MonitoringProgramPartnerID { get; set; }
        public int PerformanceMeasureID { get; set; }
        public int MonitoringProgramID { get; set; }
    }
}
