/*-----------------------------------------------------------------------
<copyright file="FirmaLogger.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
using System;
using System.Web;
using LtInfo.Common;

namespace ProjectFirma.Web.Common
{
    public class FirmaLogger : SitkaLogger
    {
        public override string GetUserAndSessionInformationForError(HttpContext context)
        {
            var person = HttpRequestStorage.Person;
            if (person.IsAnonymousUser)
            {
                return "User: Anonymous";
            }
            string organizationName = person.Organization.OrganizationName;
            return
                $"User: {person.FullNameFirstLast}{Environment.NewLine}LogonName: {person.Email}{Environment.NewLine}PersonID: {person.PersonID}{Environment.NewLine}Organization: {organizationName}{Environment.NewLine}";
        }
    }
}
