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
namespace ProjectFirmaModels.Models
{
    public class ProjectUpdateStatus
    {
        public bool IsBasicsUpdated { get; }
        public bool IsReportedPerformanceMeasuresUpdated { get; }
        public bool IsExpendituresUpdated { get; }
        public bool IsBudgetsUpdated { get; }
        public bool IsPhotosUpdated { get; }
        public bool IsLocationSimpleUpdated { get; }
        public bool IsLocationDetailUpdated { get; }
        public bool IsExternalLinksUpdated { get; }
        public bool IsNotesUpdated { get; }
        public bool IsOrganizationsUpdated { get; }
        public bool IsContactsUpdated { get; }
        public bool IsExpectedPerformanceMeasuresUpdated { get; }
        public bool IsTechnicalAssistanceRequestsUpdated { get;  }
        public bool IsCustomAttributesUpdated { get; }
        public bool IsBulkSetSpatialInformationUpdated { get; }

        public ProjectUpdateStatus(bool isBasicsUpdated,
            bool isReportedPerformanceMeasuresUpdated,
            bool isExpendituresUpdated,
            bool isBudgetsUpdated,
            bool isPhotosUpdated,
            bool isLocationSimpleUpdated,
            bool isLocationDetailUpdated,
            bool isExternalLinksUpdated,
            bool isNotesUpdated,
            bool isOrganizationsUpdated, 
            bool isExpectedPerformanceMeasuresUpdated,
            bool isTechnicalAssistanceRequestsUpdated,
            bool isContactsUpdated,
            bool isCustomAttributesUpdated)
        {
            IsBasicsUpdated = isBasicsUpdated;
            IsReportedPerformanceMeasuresUpdated = isReportedPerformanceMeasuresUpdated;
            IsExpendituresUpdated = isExpendituresUpdated;
            IsBudgetsUpdated = isBudgetsUpdated;
            IsPhotosUpdated = isPhotosUpdated;
            IsLocationSimpleUpdated = isLocationSimpleUpdated;
            IsLocationDetailUpdated = isLocationDetailUpdated;
            IsExternalLinksUpdated = isExternalLinksUpdated;
            IsNotesUpdated = isNotesUpdated;
            IsOrganizationsUpdated = isOrganizationsUpdated;
            IsExpectedPerformanceMeasuresUpdated = isExpectedPerformanceMeasuresUpdated;
            IsTechnicalAssistanceRequestsUpdated = isTechnicalAssistanceRequestsUpdated;
            IsContactsUpdated = isContactsUpdated;
            IsCustomAttributesUpdated = isCustomAttributesUpdated;
            IsBulkSetSpatialInformationUpdated = false;//10/18/2019 TK - always set to false because this section itself isn't updated. We are updating specific Geospatial Area Types.
        }
    }
}
