/*-----------------------------------------------------------------------
<copyright file="ProjectExemptReportingYearUpdateSimple.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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

using LtInfo.Common.Models;
using ProjectFirma.Web.Common;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Models
{
    public class ProjectExemptReportingYearUpdateSimple
    {
        /// <summary>
        /// Needed by ModelBinder
        /// </summary>
        public ProjectExemptReportingYearUpdateSimple()
        {
        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public ProjectExemptReportingYearUpdateSimple(int projectExemptReportingYearUpdateID, int projectUpdateBatchID, int calendarYear)
            : this()
        {
            ProjectExemptReportingYearUpdateID = projectExemptReportingYearUpdateID;
            ProjectUpdateBatchID = projectUpdateBatchID;
            CalendarYear = calendarYear;
            CalendarYearDisplay = MultiTenantHelpers.FormatReportingYear(calendarYear);
        }

        /// <summary>
        /// Constructor for building a new simple object with the POCO class
        /// </summary>
        public ProjectExemptReportingYearUpdateSimple(ProjectExemptReportingYearUpdate projectExemptReportingYearUpdate)
            : this()
        {
            ProjectExemptReportingYearUpdateID = projectExemptReportingYearUpdate.ProjectExemptReportingYearUpdateID;
            ProjectUpdateBatchID = projectExemptReportingYearUpdate.ProjectUpdateBatchID;
            CalendarYear = projectExemptReportingYearUpdate.CalendarYear;
            IsExempt = ModelObjectHelpers.IsRealPrimaryKeyValue(projectExemptReportingYearUpdate.ProjectExemptReportingYearUpdateID);
            CalendarYearDisplay = MultiTenantHelpers.FormatReportingYear(projectExemptReportingYearUpdate.CalendarYear);
        }

        public int ProjectExemptReportingYearUpdateID { get; set; }
        public int ProjectUpdateBatchID { get; set; }
        public int CalendarYear { get; set; }
        public bool IsExempt { get; set; }
        public string CalendarYearDisplay { get; set; }
    }
}
