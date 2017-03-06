/*-----------------------------------------------------------------------
<copyright file="ProjectExemptReportingYearSimple.cs" company="Tahoe Regional Planning Agency">
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
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Models
{
    public class ProjectExemptReportingYearSimple
    {
        /// <summary>
        /// Needed by ModelBinder
        /// </summary>
        public ProjectExemptReportingYearSimple()
        {
        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public ProjectExemptReportingYearSimple(int projectExemptReportingYearID, int projectID, int calendarYear)
            : this()
        {
            ProjectExemptReportingYearID = projectExemptReportingYearID;
            ProjectID = projectID;
            CalendarYear = calendarYear;
        }

        /// <summary>
        /// Constructor for building a new simple object with the POCO class
        /// </summary>
        public ProjectExemptReportingYearSimple(ProjectExemptReportingYear projectExemptReportingYear)
            : this()
        {
            ProjectExemptReportingYearID = projectExemptReportingYear.ProjectExemptReportingYearID;
            ProjectID = projectExemptReportingYear.ProjectID;
            CalendarYear = projectExemptReportingYear.CalendarYear;
            IsExempt = ModelObjectHelpers.IsRealPrimaryKeyValue(projectExemptReportingYear.ProjectExemptReportingYearID);
        }

        public int ProjectExemptReportingYearID { get; set; }
        public int ProjectID { get; set; }
        public int CalendarYear { get; set; }
        public bool IsExempt { get; set; }
    }
}
