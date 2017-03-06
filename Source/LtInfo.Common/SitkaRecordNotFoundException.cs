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
            : base(string.Format("Could not find {0} with ID# {1}", objectName, id)) {}

        public SitkaRecordNotFoundException(string objectName, Guid guid)
            : base(string.Format("Could not find {0} with GUID {1}", objectName, guid)) { }

        public SitkaRecordNotFoundException(string objectName, string matchingCriteria)
            : base(string.Format("Could not find {0} with criteria \"{1}\"", objectName, matchingCriteria)) { }

        public SitkaRecordNotFoundException(string errorMessage) : base(errorMessage) { }
    }
}
