/*-----------------------------------------------------------------------
<copyright file="AuditLogEventType.cs" company="Sitka Technology Group">
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
using System;

namespace ProjectFirma.Web.Models
{
    public partial class AuditLogEventType
    {
        public abstract string GetAuditStringForOperationType(string entityName, string auditDescriptionStringForOriginalValue, string auditDescriptionStringForNewValue);
    }

    public partial class AuditLogEventTypeAdded
    {
        public override string GetAuditStringForOperationType(string entityName, string auditDescriptionStringForOriginalValue, string auditDescriptionStringForNewValue)
        {
            return String.Format("{0}: set to {1}", entityName, auditDescriptionStringForNewValue);
        }
    }

    public partial class AuditLogEventTypeModified
    {
        public override string GetAuditStringForOperationType(string entityName, string auditDescriptionStringForOriginalValue, string auditDescriptionStringForNewValue)
        {
            return String.Format("{0}: {1} changed to {2}", entityName, auditDescriptionStringForOriginalValue, auditDescriptionStringForNewValue);
        }
    }

    public partial class AuditLogEventTypeDeleted
    {
        public override string GetAuditStringForOperationType(string entityName, string auditDescriptionStringForOriginalValue, string auditDescriptionStringForNewValue)
        {
            return String.Format("{0}: deleted {1}", entityName, auditDescriptionStringForNewValue);
        }
    }
}
