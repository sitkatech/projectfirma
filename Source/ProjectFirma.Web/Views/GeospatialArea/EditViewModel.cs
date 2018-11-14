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
using ProjectFirma.Web.Models;
using LtInfo.Common;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Views.GeospatialArea
{
    public class EditViewModel : FormViewModel, IValidatableObject
    {
        [Required]
        public int GeospatialAreaID { get; set; }

        [Required]
        [StringLength(Models.GeospatialArea.FieldLengths.GeospatialAreaName)]
        [DisplayName("Name")]
        public string GeospatialAreaName { get; set; }

        /// <summary>
        /// Needed by the ModelBinder
        /// </summary>
        public EditViewModel()
        {
        }

        public EditViewModel(Models.GeospatialArea geospatialArea)
        {
            GeospatialAreaID = geospatialArea.GeospatialAreaID;
            GeospatialAreaName = geospatialArea.GeospatialAreaName;
        }

        public void UpdateModel(Models.GeospatialArea geospatialArea, Person currentPerson)
        {
            geospatialArea.GeospatialAreaName = GeospatialAreaName;
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var errors = new List<ValidationResult>();

            var existingGeospatialAreas = HttpRequestStorage.DatabaseEntities.GeospatialAreas.ToList();
            if (!Models.GeospatialArea.IsGeospatialAreaNameUnique(existingGeospatialAreas, GeospatialAreaName, GeospatialAreaID))
            {
                errors.Add(new SitkaValidationResult<EditViewModel, string>(FirmaValidationMessages.GeospatialAreaNameUnique, x => x.GeospatialAreaName));
            }

            return errors;
        }
    }
}
