/*-----------------------------------------------------------------------
<copyright file="EditAttachmentRelationshipTypeViewModel.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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

namespace ProjectFirma.Web.Views.AttachmentRelationshipType
{
    public class EditAttachmentRelationshipTypeViewModel : FormViewModel, IValidatableObject
    {
        [Required]
        public int RelationshipTypeID { get; set; }

        [Required]
        [StringLength(ProjectFirmaModels.Models.AttachmentRelationshipType.FieldLengths.AttachmentRelationshipTypeName)]
        [DisplayName("Name")]
        public string AttachmentRelationshipTypeName { get; set; }


        [Required]
        [DisplayName("Relationship Type Description")]
        public string AttachmentRelationshipTypeDescription { get; set; }


        /// <summary>
        /// Needed by the ModelBinder
        /// </summary>
        public EditAttachmentRelationshipTypeViewModel()
        {
        }

        public EditAttachmentRelationshipTypeViewModel(ProjectFirmaModels.Models.AttachmentRelationshipType contactRelationshipType)
        {
            RelationshipTypeID = contactRelationshipType.AttachmentRelationshipTypeID;
            AttachmentRelationshipTypeName = contactRelationshipType.AttachmentRelationshipTypeName;

            AttachmentRelationshipTypeDescription = contactRelationshipType.AttachmentRelationshipTypeDescription;
        }

        public void UpdateModel(ProjectFirmaModels.Models.AttachmentRelationshipType contactRelationshipType)
        {
            contactRelationshipType.AttachmentRelationshipTypeName = AttachmentRelationshipTypeName;

            contactRelationshipType.AttachmentRelationshipTypeDescription = AttachmentRelationshipTypeDescription;
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var contactRelationshipTypes = HttpRequestStorage.DatabaseEntities.AttachmentRelationshipTypes.ToList();
            if (!contactRelationshipTypes.IsAttachmentRelationshipTypeNameUnique(AttachmentRelationshipTypeName, RelationshipTypeID))
            {
                yield return new SitkaValidationResult<EditAttachmentRelationshipTypeViewModel, string>("Name already exists.",
                    x => x.AttachmentRelationshipTypeName);
            }

        }
    }
}
