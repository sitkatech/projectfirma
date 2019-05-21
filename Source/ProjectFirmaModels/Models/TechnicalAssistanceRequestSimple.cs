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

using System.ComponentModel.DataAnnotations;

namespace ProjectFirmaModels.Models
{
    public class TechnicalAssistanceRequestSimple
    {
        public int TechnicalAssistanceRequestID { get; set; }
        [Required]
        public int ProjectID { get; set; }
        [Required]
        public int FiscalYear { get; set; }
        public int? PersonID { get; set; }
        public int? TechnicalAssistanceTypeID { get; set; }
        public int? HoursRequested { get; set; }
        public int? HoursAllocated { get; set; }
        public int? HoursProvided { get; set; }
        public string Notes { get; set; }

        /// <summary>
        /// Needed by ModelBinder
        /// </summary>
        public TechnicalAssistanceRequestSimple()
        {
        }

        /// <summary>
        /// Constructors for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public TechnicalAssistanceRequestSimple(TechnicalAssistanceRequest technicalAssistanceRequest)
        {
            this.TechnicalAssistanceRequestID = technicalAssistanceRequest.TechnicalAssistanceRequestID;
            this.ProjectID = technicalAssistanceRequest.ProjectID;
            this.FiscalYear = technicalAssistanceRequest.FiscalYear;
            this.PersonID = technicalAssistanceRequest.PersonID;
            this.TechnicalAssistanceTypeID = technicalAssistanceRequest.TechnicalAssistanceTypeID;
            this.HoursRequested = technicalAssistanceRequest.HoursRequested;
            this.HoursAllocated = technicalAssistanceRequest.HoursAllocated;
            this.HoursProvided = technicalAssistanceRequest.HoursProvided;
            this.Notes = technicalAssistanceRequest.Notes;
        }

        public TechnicalAssistanceRequestSimple(TechnicalAssistanceRequestUpdate technicalAssistanceRequestUpdate)
        {
            this.TechnicalAssistanceRequestID = technicalAssistanceRequestUpdate.TechnicalAssistanceRequestUpdateID;
            this.ProjectID = technicalAssistanceRequestUpdate.ProjectUpdateBatch.ProjectID;
            this.FiscalYear = technicalAssistanceRequestUpdate.FiscalYear;
            this.PersonID = technicalAssistanceRequestUpdate.PersonID;
            this.TechnicalAssistanceTypeID = technicalAssistanceRequestUpdate.TechnicalAssistanceTypeID;
            this.HoursRequested = technicalAssistanceRequestUpdate.HoursRequested;
            this.HoursAllocated = technicalAssistanceRequestUpdate.HoursAllocated;
            this.HoursProvided = technicalAssistanceRequestUpdate.HoursProvided;
            this.Notes = technicalAssistanceRequestUpdate.Notes;
        }
    }
}
