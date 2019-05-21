/*-----------------------------------------------------------------------
<copyright file="TechnicalAssistanceRequestSimple.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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


using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public partial class TechnicalAssistanceRequest : IAuditableEntity
    {
        public TechnicalAssistanceRequest(TechnicalAssistanceRequestUpdate technicalAssistanceRequestUpdate)
        {
            TechnicalAssistanceRequestID = ModelObjectHelpers.NotYetAssignedID;
            ProjectID = technicalAssistanceRequestUpdate.ProjectUpdateBatch.ProjectID;
            FiscalYear = technicalAssistanceRequestUpdate.FiscalYear;
            PersonID = technicalAssistanceRequestUpdate.PersonID;
            TechnicalAssistanceTypeID = technicalAssistanceRequestUpdate.TechnicalAssistanceTypeID;
            HoursRequested = technicalAssistanceRequestUpdate.HoursRequested;
            HoursAllocated = technicalAssistanceRequestUpdate.HoursAllocated;
            HoursProvided = technicalAssistanceRequestUpdate.HoursProvided;
            Notes = technicalAssistanceRequestUpdate.Notes;
        }
        public string GetAuditDescriptionString()
        {
            return $"Technical Assistance Request " + TechnicalAssistanceRequestID;
        }
    }
}
