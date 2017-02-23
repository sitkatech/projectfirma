/*-----------------------------------------------------------------------
<copyright file="ModelObjectHelpers.cs" company="Sitka Technology Group">
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
using System.Threading;

namespace LtInfo.Common.Models
{
    public static class ModelObjectHelpers
    {
        public const int NotYetAssignedID = -1;
        private static int _lastUnsavedPrimaryKeyValueIssued = NotYetAssignedID;

        public static bool IsRealPrimaryKeyValue(int? primaryKeyValueToCheck)
        {
            return primaryKeyValueToCheck.HasValue && primaryKeyValueToCheck.Value != NotYetAssignedID && primaryKeyValueToCheck.Value > 0;
        }

        /// <summary>
        /// Assigns new IDs to objects in a thread safe way, so that those IDs are considered not saved yet. <see cref="IsRealPrimaryKeyValue"/>
        /// </summary>
        public static int MakeNextUnsavedPrimaryKeyValue()
        {
            return Interlocked.Decrement(ref _lastUnsavedPrimaryKeyValueIssued);
        }
    }
}
