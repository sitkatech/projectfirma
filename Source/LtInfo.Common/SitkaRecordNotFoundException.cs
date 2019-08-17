/*-----------------------------------------------------------------------
<copyright file="SitkaRecordNotFoundException.cs" company="Sitka Technology Group">
Copyright (c) Sitka Technology Group. All rights reserved.
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

namespace LtInfo.Common
{
    public class SitkaRecordNotFoundException : SitkaDisplayErrorException
    {
        public SitkaRecordNotFoundException(string objectName, int id)
            : base($"Could not find {objectName} with ID# {id}") {}

        public SitkaRecordNotFoundException(string objectName, Guid guid)
            : base($"Could not find {objectName} with GUID {guid}") { }

        public SitkaRecordNotFoundException(string objectName, string matchingCriteria)
            : base($"Could not find {objectName} with criteria \"{matchingCriteria}\"") { }

        public SitkaRecordNotFoundException(string errorMessage) : base(errorMessage) { }
    }
}
