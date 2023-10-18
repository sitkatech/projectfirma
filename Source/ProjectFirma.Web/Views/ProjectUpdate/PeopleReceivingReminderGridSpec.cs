﻿/*-----------------------------------------------------------------------
<copyright file="PeopleReceivingReminderGridSpec.cs" company="Tahoe Regional Planning Agency and Environmental Science Associates">
Copyright (c) Tahoe Regional Planning Agency and Environmental Science Associates. All rights reserved.
<author>Environmental Science Associates</author>
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
using System.Linq;
using ProjectFirma.Web.Common;
using ProjectFirmaModels.Models;
using LtInfo.Common.AgGridWrappers;
using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.Views.ProjectUpdate
{
    public class PeopleReceivingReminderGridSpec : GridSpec<Person>
    {
        public PeopleReceivingReminderGridSpec(bool showCheckbox, FirmaSession currentFirmaSession)
        {
            if (showCheckbox)
            {
                AddCheckBoxColumn();
                Add("PersonID", x => x.PersonID, 0);
            }
            Add(FieldDefinitionEnum.OrganizationPrimaryContact.ToType().ToGridHeaderString(), x => x.GetFullNameFirstLastAndOrgShortNameAsUrl(currentFirmaSession), 220);
            Add("Email", a => a.Email, 170);
            Add($"Total Updateable {FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabelPluralized()}",
                x => x.GetPrimaryContactUpdatableProjects(currentFirmaSession).Count,
                75, AgGridColumnAggregationType.Total);
            Add("Updates Not Started",
                x =>
                {
                    return x.GetPrimaryContactUpdatableProjects(currentFirmaSession).Count(y =>
                    {
                        var latestNotApprovedUpdateBatch = y.GetLatestNotApprovedUpdateBatch();
                        var latestApprovedUpdateBatch = y.GetLatestApprovedUpdateBatch();
                        return latestNotApprovedUpdateBatch == null &&
                               (latestApprovedUpdateBatch == null || latestApprovedUpdateBatch.LastUpdateDate < FirmaDateUtilities.LastReportingPeriodStartDate());
                    });
                },
                70, AgGridColumnAggregationType.Total);
            Add("Updates In Progress",
                x =>
                {
                    return x.GetPrimaryContactUpdatableProjects(currentFirmaSession).Count(y =>
                    {
                        var latestNotApprovedUpdateBatch = y.GetLatestNotApprovedUpdateBatch();
                        return latestNotApprovedUpdateBatch != null && latestNotApprovedUpdateBatch.IsCreated();
                    });
                },
                70, AgGridColumnAggregationType.Total);
            Add("Updates Submitted",
                x =>
                {
                    return x.GetPrimaryContactUpdatableProjects(currentFirmaSession).Count(y =>
                    {
                        var latestNotApprovedUpdateBatch = y.GetLatestNotApprovedUpdateBatch();
                        return latestNotApprovedUpdateBatch != null && latestNotApprovedUpdateBatch.IsSubmitted();
                    });
                },
                75, AgGridColumnAggregationType.Total);
            Add("Updates Returned",
                x =>
                {
                    return x.GetPrimaryContactUpdatableProjects(currentFirmaSession).Count(y =>
                    {
                        var latestNotApprovedUpdateBatch = y.GetLatestNotApprovedUpdateBatch();
                        return latestNotApprovedUpdateBatch != null && latestNotApprovedUpdateBatch.IsReturned();
                    });
                },
                70, AgGridColumnAggregationType.Total);
            Add("Updates Approved",
                x =>
                {
                    return x.GetPrimaryContactUpdatableProjects(currentFirmaSession).Count(y =>
                    {
                        var latestApprovedUpdateBatch = y.GetLatestApprovedUpdateBatch();
                        return latestApprovedUpdateBatch != null && latestApprovedUpdateBatch.LastUpdateDate >= FirmaDateUtilities.LastReportingPeriodStartDate();
                    });
                },
                70, AgGridColumnAggregationType.Total);
            Add("Reminders Sent",
                x =>
                    x.Notifications.Count(
                        y =>
                            y.NotificationType == NotificationType.ProjectUpdateReminder &&
                            y.NotificationDate >= FirmaDateUtilities.LastReportingPeriodStartDate()),
                80);
            Add("Date of Last Reminder Message", x =>
            {
                var mostRecentReminder = x.GetMostRecentReminder();
                return mostRecentReminder?.NotificationDate;
            }, 130);
        }
    }
}
