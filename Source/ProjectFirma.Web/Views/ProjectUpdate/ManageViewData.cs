/*-----------------------------------------------------------------------
<copyright file="ManageViewData.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
using ProjectFirma.Web.Common;
using ProjectFirmaModels.Models;
using LtInfo.Common.ModalDialog;
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.Views.ProjectUpdate
{
    public class ManageViewData : FirmaViewData
    {
        public int ReportingYear { get; }

        public ProjectUpdateStatusGridSpec ProjectsRequiringUpdateGridSpec { get; }
        public string ProjectsRequiringUpdateGridName { get; }
        public string ProjectsRequiringUpdateGridDataUrl { get; }

        public PeopleReceivingReminderGridSpec PeopleReceivingReminderGridSpec { get; }
        public string PeopleReceivingReminderGridName { get; }
        public string PeopleReceivingReminderGridDataUrl { get; }

        public int ProjectsWithNoContactCount { get; }
        public string EditProjectUpdateConfigurationUrl { get; }
        public ProjectUpdateSetting ProjectUpdateSetting { get; }
        public string KickOffIntroPreviewUrl { get; }
        public string ReminderIntroPreviewUrl { get; }
        public string CloseOutIntroPreviewUrl { get; }

        public ManageViewData(FirmaSession currentFirmaSession,
                              ProjectFirmaModels.Models.FirmaPage firmaPage,
                              string customNotificationUrl,
                              ProjectUpdateStatusGridSpec projectsRequiringUpdateGridSpec,
                              string projectsRequiringUpdateGridDataUrl,
                              PeopleReceivingReminderGridSpec peopleReceivingReminderGridSpec,
                              string peopleReceivingReminderGridDataUrl, int projectsWithNoContactCount,
                              ProjectUpdateSetting projectUpdateSetting) : base(currentFirmaSession, firmaPage)
        {
            var reportingYear = FirmaDateUtilities.CalculateCurrentYearToUseForRequiredReporting();
            var fieldDefinitionLabelProject = FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel();
            PageTitle = $"Manage {fieldDefinitionLabelProject} Updates";
            ReportingYear = reportingYear;

            ProjectsRequiringUpdateGridDataUrl = projectsRequiringUpdateGridDataUrl;
            ProjectsRequiringUpdateGridSpec = projectsRequiringUpdateGridSpec;
            ProjectsRequiringUpdateGridName = "projectsRequiringAnUpdateGrid";

            PeopleReceivingReminderGridDataUrl = peopleReceivingReminderGridDataUrl;
            ProjectsWithNoContactCount = projectsWithNoContactCount;

            ProjectUpdateSetting = projectUpdateSetting;

            PeopleReceivingReminderGridSpec = peopleReceivingReminderGridSpec;
            PeopleReceivingReminderGridName = "peopleReceivingAnReminderGrid";

            KickOffIntroPreviewUrl = SitkaRoute<ProjectUpdateController>.BuildUrlFromExpression(x => x.KickOffIntroPreview());
            ReminderIntroPreviewUrl = SitkaRoute<ProjectUpdateController>.BuildUrlFromExpression(x => x.ReminderIntroPreview());
            CloseOutIntroPreviewUrl = SitkaRoute<ProjectUpdateController>.BuildUrlFromExpression(x => x.CloseOutIntroPreview());

            var getPersonIDFunctionString =
                $"function() {{ return Sitka.{PeopleReceivingReminderGridName}.getValuesFromCheckedGridRows({0}, \'PersonID\', \'PersonIDList\'); }}";

            var modalDialogFormLink = ModalDialogFormHelper.ModalDialogFormLink(
                "<span class=\"glyphicon glyphicon-envelope\" style=\"margin-right:5px\"></span>Send Notification to Selected People",
                customNotificationUrl,
                "Send Notification to Selected People",
                700,
                "Send",
                "Cancel",
                new List<string>(),
                null,
                getPersonIDFunctionString);

            PeopleReceivingReminderGridSpec.ArbitraryHtml = new List<string> {modalDialogFormLink.ToString()};

            EditProjectUpdateConfigurationUrl = SitkaRoute<ProjectUpdateController>.BuildUrlFromExpression(x => x.EditProjectUpdateConfiguration());
        }
    }
}
