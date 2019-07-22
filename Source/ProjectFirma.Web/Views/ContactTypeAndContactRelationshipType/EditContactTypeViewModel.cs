/*-----------------------------------------------------------------------
<copyright file="EditContactTypeViewModel.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
using LtInfo.Common;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Views.ContactTypeAndContactRelationshipType
{
    public class EditContactTypeViewModel : FormViewModel, IValidatableObject
    {
        [Required]
        public int ContactTypeID { get; set; }

        [Required]
        [StringLength(ContactType.FieldLengths.ContactTypeName)]
        [DisplayName("Name")]
        public string ContactTypeName { get; set; }

        [Required]
        [StringLength(ContactType.FieldLengths.ContactTypeAbbreviation)]
        [FieldDefinitionDisplay(FieldDefinitionEnum.ContactTypeAbbreviation)]
        public string ContactTypeAbbreviation { get; set; }

        [Required]
        [FieldDefinitionDisplay(FieldDefinitionEnum.IsDefaultContactType)]
        public bool? IsDefaultContactType { get; set; }


        /// <summary>
        /// Needed by the ModelBinder
        /// </summary>
        public EditContactTypeViewModel()
        {
        }

        public EditContactTypeViewModel(ContactType contactType)
        {
            ContactTypeID = contactType.ContactTypeID;
            ContactTypeName = contactType.ContactTypeName;
            ContactTypeAbbreviation = contactType.ContactTypeAbbreviation;
            IsDefaultContactType = contactType.IsDefaultContactType;
        }

        public void UpdateModel(ContactType contactType, Person currentPerson)
        {
            contactType.ContactTypeName = ContactTypeName;
            contactType.ContactTypeAbbreviation = ContactTypeAbbreviation; 
            contactType.IsDefaultContactType = IsDefaultContactType ?? false;
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var errors = new List<ValidationResult>();
            var existingContactType = HttpRequestStorage.DatabaseEntities.ContactTypes.ToList();
            if (!ContactTypeModelExtensions.IsContactTypeNameUnique(existingContactType, ContactTypeName, ContactTypeID))
            {
                errors.Add(new SitkaValidationResult<EditContactTypeViewModel, string>("Name is already used for another contact type", x => x.ContactTypeName));
            }

            if (!ContactTypeModelExtensions.IsContactTypeAbbreviationUnique(existingContactType, ContactTypeAbbreviation, ContactTypeID))
            {
                errors.Add(new SitkaValidationResult<EditContactTypeViewModel, string>("Abbreviation is already used for another contact type", x => x.ContactTypeAbbreviation));
            }
            return errors;
        }
    }
}
