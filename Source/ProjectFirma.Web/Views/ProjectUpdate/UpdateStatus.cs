/*-----------------------------------------------------------------------
<copyright file="UpdateStatus.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
namespace ProjectFirma.Web.Views.ProjectUpdate
{
    public class UpdateStatus
    {
        public readonly bool IsBasicsUpdated;
        public readonly bool IsPerformanceMeasuresUpdated;
        public readonly bool IsExpectedFundingUpdated;
        public readonly bool IsExpendituresUpdated;
        public readonly bool IsBudgetsUpdated;
        public readonly bool IsPhotosUpdated;
        public readonly bool IsLocationSimpleUpdated;
        public readonly bool IsLocationDetailUpdated;
        public readonly bool IsWatershedUpdated;
        public readonly bool IsExternalLinksUpdated;
        public readonly bool IsNotesUpdated;
        public readonly bool IsOrganizationsUpdated;

        public UpdateStatus(bool isBasicsUpdated,
            bool isPerformanceMeasuresUpdated,
            bool isExpendituresUpdated,
            bool isBudgetsUpdated,
            bool isPhotosUpdated,
            bool isLocationSimpleUpdated,
            bool isLocationDetailUpdated,
            bool isWatershedUpdated,
            bool isExternalLinksUpdated,
            bool isNotesUpdated,
            bool isExpectedFundingUpdated,
            bool isOrganizationsUpdated)
        {
            IsBasicsUpdated = isBasicsUpdated;
            IsPerformanceMeasuresUpdated = isPerformanceMeasuresUpdated;
            IsExpendituresUpdated = isExpendituresUpdated;
            IsBudgetsUpdated = isBudgetsUpdated;
            IsPhotosUpdated = isPhotosUpdated;
            IsLocationSimpleUpdated = isLocationSimpleUpdated;
            IsLocationDetailUpdated = isLocationDetailUpdated;
            IsWatershedUpdated = isWatershedUpdated;
            IsExternalLinksUpdated = isExternalLinksUpdated;
            IsNotesUpdated = isNotesUpdated;
            IsExpectedFundingUpdated = isExpectedFundingUpdated;
            IsOrganizationsUpdated = isOrganizationsUpdated;
        }

        
    }
}
