/*-----------------------------------------------------------------------
<copyright file="AuditLogsGridSpec.cs" company="Tahoe Regional Planning Agency">
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
using ProjectFirma.Web.Models;
using LtInfo.Common;
using LtInfo.Common.DhtmlWrappers;
using LtInfo.Common.Views;

namespace ProjectFirma.Web.Views.Shared
{
    public class AuditLogsGridSpec : GridSpec<AuditLog>
    {
        public AuditLogsGridSpec()
        {
            Add("Date", a => a.AuditLogDate, 120);
            Add("User", a => a.Person.GetFullNameFirstLastAndOrgAsUrl(), 300);
            Add("Section", a => a.TableName.ToProperCase(), 200, DhtmlxGridColumnFilterType.SelectFilterStrict);
            Add("Description", a => a.AuditDescriptionDisplay, 400);
        }
    }
}
