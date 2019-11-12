/*-----------------------------------------------------------------------
<copyright file="CustomNotificationViewData.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
using ProjectFirma.Web.Models;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Views.ProjectUpdate
{
    public class CustomNotificationViewData : FirmaUserControlViewData
    {
        public readonly string PersonLabel;
        public readonly List<Person> PeopleToNotify;
        public readonly string SendPreviewEmailUrl;
        public readonly string SupportEmail;
        public readonly Person CurrentPerson;

        public CustomNotificationViewData(FirmaSession currentFirmaSession, List<Person> peopleToNotify, string sendPreviewEmailUrl)
        {
            PeopleToNotify = peopleToNotify;
            CurrentPerson = currentFirmaSession.Person;
            SendPreviewEmailUrl = sendPreviewEmailUrl;
            PersonLabel = peopleToNotify.Count > 1 ? "People" : "Person";
            SupportEmail = NotificationModelExtensions.DoNotReplyMailAddress().Address;
        }
    }
}
