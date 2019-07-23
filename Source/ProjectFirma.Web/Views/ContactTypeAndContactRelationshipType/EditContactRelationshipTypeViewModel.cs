/*-----------------------------------------------------------------------
<copyright file="EditContactRelationshipTypeViewModel.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
using ProjectFirma.Web.Models;
using ProjectFirmaModels;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Views.ContactTypeAndContactRelationshipType
{
    public class EditContactRelationshipTypeViewModel : FormViewModel, IValidatableObject
    {
        [Required]
        public int RelationshipTypeID { get; set; }

        [Required]
        [StringLength(ContactRelationshipType.FieldLengths.ContactRelationshipTypeName)]
        [DisplayName("Name")]
        public string ContactRelationshipTypeName { get; set; }
      
        [Required]
        [FieldDefinitionDisplay(FieldDefinitionEnum.ContactType)]
        public List<int> ContactTypeIDs { get; set; }

        [Required]
        [DisplayName("Must be Related to Once?")]
        public bool? CanOnlyBeRelatedOnceToAProject { get; set; }

        [Required]
        [DisplayName("Relationship Type Description")]
        public string ContactRelationshipTypeDescription { get; set; }


        /// <summary>
        /// Needed by the ModelBinder
        /// </summary>
        public EditContactRelationshipTypeViewModel()
        {
        }

        public EditContactRelationshipTypeViewModel(ContactRelationshipType contactRelationshipType)
        {
            RelationshipTypeID = contactRelationshipType.ContactRelationshipTypeID;
            ContactRelationshipTypeName = contactRelationshipType.ContactRelationshipTypeName;
            ContactTypeIDs = contactRelationshipType.ContactTypeContactRelationshipTypes
                .Select(x => x.ContactTypeID)
                .ToList();
            CanOnlyBeRelatedOnceToAProject = contactRelationshipType.CanOnlyBeRelatedOnceToAProject;
            ContactRelationshipTypeDescription = contactRelationshipType.ContactRelationshipTypeDescription;
        }

        public void UpdateModel(ContactRelationshipType contactRelationshipType, ICollection<ContactTypeContactRelationshipType> allContactTypeContactRelationshipTypes)
        {
            contactRelationshipType.ContactRelationshipTypeName = ContactRelationshipTypeName;

            var contactTypesUpdated = ContactTypeIDs.Select(x => new ContactTypeContactRelationshipType(x, contactRelationshipType.ContactRelationshipTypeID)).ToList();

            contactRelationshipType.ContactTypeContactRelationshipTypes.Merge(contactTypesUpdated,
                allContactTypeContactRelationshipTypes,
                (x, y) => x.ContactTypeID == y.ContactTypeID && x.ContactRelationshipTypeID == y.ContactRelationshipTypeID, HttpRequestStorage.DatabaseEntities);


            contactRelationshipType.CanOnlyBeRelatedOnceToAProject = CanOnlyBeRelatedOnceToAProject ?? false;
            contactRelationshipType.ContactRelationshipTypeDescription = ContactRelationshipTypeDescription;
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var contactRelationshipTypes = HttpRequestStorage.DatabaseEntities.ContactRelationshipTypes.ToList();
            if (!contactRelationshipTypes.IsContactRelationshipTypeNameUnique(ContactRelationshipTypeName, RelationshipTypeID))
            {
                yield return new SitkaValidationResult<EditContactRelationshipTypeViewModel, string>("Name already exists.",
                    x => x.ContactRelationshipTypeName);
            }

        }
    }
}
