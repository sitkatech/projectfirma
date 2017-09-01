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

namespace ProjectFirma.Web.Views.OrganizationAndRelationshipType
{
    public class EditOrganizationTypeViewModel : FormViewModel, IValidatableObject
    {
        [Required]
        public int OrganizationTypeID { get; set; }

        [Required]
        [StringLength(Models.OrganizationType.FieldLengths.OrganizationTypeName)]
        [DisplayName("Name")]
        public string OrganizationTypeName { get; set; }

        [Required]
        [StringLength(OrganizationType.FieldLengths.OrganizationTypeAbbreviation)]
        [DisplayName("Abbreviation")]
        public string OrganizationTypeAbbreviation { get; set; }

        [Required]
        public string LegendColor { get; set; }

        [Required]
        [DisplayName("Show On Project Map?")]
        public bool? ShowOnProjectMaps { get; set; }

        /// <summary>
        /// Needed by the ModelBinder
        /// </summary>
        public EditOrganizationTypeViewModel()
        {
        }

        public EditOrganizationTypeViewModel(OrganizationType organizationType)
        {
            OrganizationTypeID = organizationType.OrganizationTypeID;
            OrganizationTypeName = organizationType.OrganizationTypeName;
            OrganizationTypeAbbreviation = organizationType.OrganizationTypeAbbreviation;
            LegendColor = organizationType.LegendColor;
            ShowOnProjectMaps = organizationType.ShowOnProjectMaps;
        }

        public void UpdateModel(OrganizationType organizationType, Person currentPerson)
        {
            organizationType.OrganizationTypeName = OrganizationTypeName;
            organizationType.OrganizationTypeAbbreviation = OrganizationTypeAbbreviation; 
            organizationType.LegendColor = LegendColor;
            organizationType.ShowOnProjectMaps = ShowOnProjectMaps ?? false;
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var errors = new List<ValidationResult>();
            var existingOrganizationType = HttpRequestStorage.DatabaseEntities.OrganizationTypes.ToList();
            if (!OrganizationType.IsOrganizationTypeNameUnique(existingOrganizationType, OrganizationTypeName, OrganizationTypeID))
            {
                errors.Add(new SitkaValidationResult<EditOrganizationTypeViewModel, string>("Name is already used for another organization type", x => x.OrganizationTypeName));
            }

            if (!OrganizationType.IsOrganizationTypeAbbreviationUnique(existingOrganizationType, OrganizationTypeAbbreviation, OrganizationTypeID))
            {
                errors.Add(new SitkaValidationResult<EditOrganizationTypeViewModel, string>("Abbreviation is already used for another organization type", x => x.OrganizationTypeAbbreviation));
            }
            return errors;
        }
    }
}
