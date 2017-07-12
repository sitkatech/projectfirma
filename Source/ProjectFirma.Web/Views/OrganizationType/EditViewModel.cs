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
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using LtInfo.Common;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.Views.OrganizationType
{
    public class EditViewModel : FormViewModel, IValidatableObject
    {
        [Required]
        public int OrganizationTypeID { get; set; }

        [Required]
        [StringLength(Models.OrganizationType.FieldLengths.OrganizationTypeName)]
        [DisplayName("Name")]
        public string OrganizationTypeName { get; set; }

        [Required]
        [StringLength(Models.OrganizationType.FieldLengths.OrganizationTypeAbbreviation)]
        [DisplayName("Abbreviation")]
        public string OrganizationTypeAbbreviation { get; set; }

        [Required]
        public string LegendColor { get; set; }

        /// <summary>
        /// Needed by the ModelBinder
        /// </summary>
        public EditViewModel()
        {
        }

        public EditViewModel(Models.OrganizationType organizationType)
        {
            OrganizationTypeID = organizationType.OrganizationTypeID;
            OrganizationTypeName = organizationType.OrganizationTypeName;
            OrganizationTypeAbbreviation = organizationType.OrganizationTypeAbbreviation;
            LegendColor = organizationType.LegendColor;
        }

        public void UpdateModel(Models.OrganizationType organizationType, Person currentPerson)
        {
            organizationType.OrganizationTypeName = OrganizationTypeName;
            organizationType.OrganizationTypeAbbreviation = OrganizationTypeAbbreviation; 
            organizationType.LegendColor = LegendColor;
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var errors = new List<ValidationResult>();
            var existingOrganizationType = HttpRequestStorage.DatabaseEntities.OrganizationTypes.ToList();
            if (!Models.OrganizationType.IsOrganizationTypeNameUnique(existingOrganizationType, OrganizationTypeName, OrganizationTypeID))
            {
                errors.Add(new SitkaValidationResult<EditViewModel, string>("Name already exists", x => x.OrganizationTypeName));
            }
            return errors;
        }
    }
}
