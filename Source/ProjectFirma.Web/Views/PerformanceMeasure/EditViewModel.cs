/*-----------------------------------------------------------------------
<copyright file="EditViewModel.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using ProjectFirma.Web.Common;
using ProjectFirmaModels.Models;
using LtInfo.Common;
using LtInfo.Common.Models;
using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.Views.PerformanceMeasure
{
    public class EditViewModel : FormViewModel, IValidatableObject
    {
        [Required]
        public int PerformanceMeasureID { get; set; }

        [Required]
        [StringLength(ProjectFirmaModels.Models.PerformanceMeasure.FieldLengths.PerformanceMeasureDisplayName)]
        [FieldDefinitionDisplay(FieldDefinitionEnum.PerformanceMeasure)]
        public string PerformanceMeasureDisplayName { get; set; }

        [Required]
        [FieldDefinitionDisplay(FieldDefinitionEnum.MeasurementUnit)]
        public int MeasurementUnitTypeID { get; set; }

        [Required]
        [DisplayName("Description")]
        public string PerformanceMeasureDefinition { get; set; }

        [Required]
        [FieldDefinitionDisplay(FieldDefinitionEnum.PerformanceMeasureType)]
        public int? PerformanceMeasureTypeID { get; set; }

        [Required]
        [FieldDefinitionDisplay(FieldDefinitionEnum.PerformanceMeasureIsSummable)]
        public bool? IsSummable { get; set; }

        /// <summary>
        /// Needed by the ModelBinder
        /// </summary>
        public EditViewModel()
        {
        }

        public EditViewModel(ProjectFirmaModels.Models.PerformanceMeasure performanceMeasure)
        {
            PerformanceMeasureID = performanceMeasure.PerformanceMeasureID;
            PerformanceMeasureDisplayName = performanceMeasure.PerformanceMeasureDisplayName;
            PerformanceMeasureTypeID = performanceMeasure.PerformanceMeasureTypeID;
            MeasurementUnitTypeID = performanceMeasure.MeasurementUnitTypeID;
            PerformanceMeasureDefinition = performanceMeasure.PerformanceMeasureDefinition;
            IsSummable = performanceMeasure.IsSummable;
        }

        public void UpdateModel(ProjectFirmaModels.Models.PerformanceMeasure performanceMeasure, Person currentPerson)
        {
            performanceMeasure.PerformanceMeasureDisplayName = PerformanceMeasureDisplayName;
            performanceMeasure.PerformanceMeasureTypeID = PerformanceMeasureTypeID.Value;
            performanceMeasure.MeasurementUnitTypeID = MeasurementUnitTypeID;
            performanceMeasure.PerformanceMeasureDefinition = PerformanceMeasureDefinition;
            performanceMeasure.IsSummable = IsSummable.GetValueOrDefault(); // will never be null due to RequiredAttribute
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var errors = new List<ValidationResult>();

            var performanceMeasures = HttpRequestStorage.DatabaseEntities.PerformanceMeasures.ToList();
            if (!PerformanceMeasureModelExtensions.IsPerformanceMeasureDisplayNameUnique(performanceMeasures, PerformanceMeasureDisplayName, PerformanceMeasureID))
            {
                errors.Add(new SitkaValidationResult<EditViewModel, string>(FirmaValidationMessages.PerformanceMeasureNameUnique, x => x.PerformanceMeasureDisplayName));
            }
            return errors;
        }
    }
}
