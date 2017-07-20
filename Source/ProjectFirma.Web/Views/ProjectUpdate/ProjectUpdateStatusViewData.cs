/*-----------------------------------------------------------------------
<copyright file="ProjectUpdateStatusViewData.cs" company="Tahoe Regional Planning Agency">
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
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Views.Shared;

namespace ProjectFirma.Web.Views.ProjectUpdate
{
    public class ProjectUpdateStatusViewData : FirmaViewData
    {
        public readonly int ReportingYear;

        public readonly PeopleReceivingReminderGridSpec PeopleReceivingReminderGridSpec;
        public readonly string PeopleReceivingReminderGridName;
        public readonly string PeopleReceivingReminderGridDataUrl;

        public ProjectUpdateStatusViewData(Person currentPerson,
            Models.FirmaPage firmaPage,                        
            PeopleReceivingReminderGridSpec peopleReceivingReminderGridSpec,
            string peopleReceivingReminderGridDataUrl) : base(currentPerson, firmaPage)
        {
            var reportingYear = FirmaDateUtilities.CalculateCurrentYearToUseForReporting();
            PageTitle = string.Format("Project Update Status for {0}: {1}", Models.FieldDefinition.ReportingYear.GetFieldDefinitionLabel(), reportingYear);
            ReportingYear = reportingYear;

            PeopleReceivingReminderGridDataUrl = peopleReceivingReminderGridDataUrl;
            PeopleReceivingReminderGridSpec = peopleReceivingReminderGridSpec;
            PeopleReceivingReminderGridName = "peopleReceivingAnReminderGrid";           
        }
    }
}
