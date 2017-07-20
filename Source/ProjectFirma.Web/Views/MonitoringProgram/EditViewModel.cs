/*-----------------------------------------------------------------------
<copyright file="EditViewModel.cs" company="Tahoe Regional Planning Agency">
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
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using LtInfo.Common;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Views.MonitoringProgram
{
    public class EditViewModel : FormViewModel, IValidatableObject
    {
        [Required]
        public int MonitoringProgramID { get; set; }

        [Required]
        [StringLength(Models.MonitoringProgram.FieldLengths.MonitoringProgramName)]
        [FieldDefinitionDisplay(FieldDefinitionEnum.MonitoringProgram)]
        public string MonitoringProgramName { get; set; }

        [StringLength(Models.MonitoringProgram.FieldLengths.MonitoringApproach)]
        [FieldDefinitionDisplay(FieldDefinitionEnum.MonitoringApproach)]
        public string MonitoringApproach { get; set; }

        [FieldDefinitionDisplay(FieldDefinitionEnum.MonitoringProgramUrl)]
        [Url]
        public string MonitoringProgramUrl { get; set; }


        /// <summary>
        /// Needed by the ModelBinder
        /// </summary>
        public EditViewModel()
        {
        }

        public EditViewModel(Models.MonitoringProgram monitoringProgram)
        {
            MonitoringProgramID = monitoringProgram.MonitoringProgramID;
            MonitoringProgramName = monitoringProgram.MonitoringProgramName;
            MonitoringApproach = monitoringProgram.MonitoringApproach;
            MonitoringProgramUrl = monitoringProgram.MonitoringProgramUrl;
        }

        public void UpdateModel(Models.MonitoringProgram monitoringProgram, Person currentPerson)
        {
            monitoringProgram.MonitoringProgramName = MonitoringProgramName;
            monitoringProgram.MonitoringApproach = MonitoringApproach;
            monitoringProgram.MonitoringProgramUrl = MonitoringProgramUrl;
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var errors = new List<ValidationResult>();

            var existingMonitoringPrograms = HttpRequestStorage.DatabaseEntities.MonitoringPrograms.ToList();
            if (!Models.MonitoringProgram.IsMonitoringProgramNameUnique(existingMonitoringPrograms, MonitoringProgramName, MonitoringProgramID))
            {
                errors.Add(new SitkaValidationResult<EditViewModel, string>($"{Models.FieldDefinition.MonitoringProgram.GetFieldDefinitionLabel()} Name already exists", x => x.MonitoringProgramName));
            }
            return errors;
        }
    }
}
