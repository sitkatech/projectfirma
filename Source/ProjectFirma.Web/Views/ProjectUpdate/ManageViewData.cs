/*-----------------------------------------------------------------------
<copyright file="ManageViewData.cs" company="Sitka Technology Group">
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
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using LtInfo.Common.ModalDialog;

namespace ProjectFirma.Web.Views.ProjectUpdate
{
    public class ManageViewData : FirmaViewData
    {
        public readonly int ReportingYear;

        public readonly ProjectUpdateStatusGridSpec ProjectsRequiringUpdateGridSpec;
        public readonly string ProjectsRequiringUpdateGridName;
        public readonly string ProjectsRequiringUpdateGridDataUrl;

        public readonly PeopleReceivingReminderGridSpec PeopleReceivingReminderGridSpec;
        public readonly string PeopleReceivingReminderGridName;
        public readonly string PeopleReceivingReminderGridDataUrl;

        public readonly int ProjectsWithNoContactCount;

        public ManageViewData(Person currentPerson,
            Models.FirmaPage firmaPage,
            string customNotificationUrl,
            ProjectUpdateStatusGridSpec projectsRequiringUpdateGridSpec,
            string projectsRequiringUpdateGridDataUrl,
            PeopleReceivingReminderGridSpec peopleReceivingReminderGridSpec,
            string peopleReceivingReminderGridDataUrl, int projectsWithNoContactCount) : base(currentPerson, firmaPage, false)
        {
            var reportingYear = FirmaDateUtilities.CalculateCurrentYearToUseForReporting();
            PageTitle = string.Format("Project Update Notifications for Reporting Year: {0}", reportingYear);
            ReportingYear = reportingYear;

            ProjectsRequiringUpdateGridDataUrl = projectsRequiringUpdateGridDataUrl;
            ProjectsRequiringUpdateGridSpec = projectsRequiringUpdateGridSpec;
            ProjectsRequiringUpdateGridName = "projectsRequiringAnUpdateGrid";

            PeopleReceivingReminderGridDataUrl = peopleReceivingReminderGridDataUrl;
            ProjectsWithNoContactCount = projectsWithNoContactCount;
            PeopleReceivingReminderGridSpec = peopleReceivingReminderGridSpec;
            PeopleReceivingReminderGridName = "peopleReceivingAnReminderGrid";

            var getPersonIDFunctionString = string.Format("function() {{ return Sitka.{0}.getValuesFromCheckedGridRows({1}, '{2}', '{3}'); }}",
                PeopleReceivingReminderGridName,
                0,
                "PersonID",
                "PersonIDList");


            var modalDialogFormLink = ModalDialogFormHelper.ModalDialogFormLink("<span class=\"glyphicon glyphicon-envelope\" style=\"margin-right:5px\"></span>Send Notification to Selected People",
                customNotificationUrl,
                "Send Notification to Selected People",
                700,
                "Send",
                "Cancel",
                new List<string>(),
                null,
                getPersonIDFunctionString);

            PeopleReceivingReminderGridSpec.ArbitraryHtml = new List<string> {modalDialogFormLink.ToString()};
        }
    }
}
