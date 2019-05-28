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


using System;
using System.Collections.Generic;
using System.Linq;
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

        public decimal GetValueProvided(List<TechnicalAssistanceParameter> technicalAssistanceParameters)
        {
            var yearParameter = technicalAssistanceParameters.Single(x => x.Year == FiscalYear);
            var rate = GetRateToUse(yearParameter);
            return rate * HoursProvided ?? 0;
        }

        private decimal GetRateToUse(TechnicalAssistanceParameter yearParameter)
        {
            decimal rate = 0;
            switch (TechnicalAssistanceType.ToEnum)
            {
                case TechnicalAssistanceTypeEnum.Engineering:
                    rate = yearParameter.EngineeringHourlyCost ?? 0;
                    break;
                case TechnicalAssistanceTypeEnum.CapacityBuilding:
                case TechnicalAssistanceTypeEnum.EducationOutreach:
                case TechnicalAssistanceTypeEnum.Operations:
                case TechnicalAssistanceTypeEnum.TechnicalAssistance:
                    rate = yearParameter.OtherAssistanceHourlyCost ?? 0;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            return rate;
        }

        public string GetAuditDescriptionString()
        {
            return $"Technical Assistance Request " + TechnicalAssistanceRequestID;
        }
    }
}
 