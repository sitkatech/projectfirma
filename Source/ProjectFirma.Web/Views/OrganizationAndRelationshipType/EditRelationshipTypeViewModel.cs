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
    public class EditRelationshipTypeViewModel : FormViewModel, IValidatableObject
    {
        [Required]
        public int RelationshipTypeID { get; set; }

        [Required]
        [StringLength(RelationshipType.FieldLengths.RelationshipTypeName)]
        [DisplayName("Name")]
        public string RelationshipTypeName { get; set; }
      
        [Required]
        [FieldDefinitionDisplay(FieldDefinitionEnum.OrganizationType)]
        public List<int> OrganizationTypeIDs { get; set; }

        [Required]
        [DisplayName("Can Approve Projects?")]
        public bool? CanApproveProjects { get; set; }

        [Required]
        [DisplayName("Is Primary Contact?")]
        public bool? IsPrimaryContact { get; set; }

        [Required]
        [DisplayName("Can only be related to a project once?")]
        public bool? CanOnlyBeRelatedOnceToAProject { get; set; }


        /// <summary>
        /// Needed by the ModelBinder
        /// </summary>
        public EditRelationshipTypeViewModel()
        {
        }

        public EditRelationshipTypeViewModel(RelationshipType relationshipType)
        {
            RelationshipTypeID = relationshipType.RelationshipTypeID;
            RelationshipTypeName = relationshipType.RelationshipTypeName;
            OrganizationTypeIDs = relationshipType.OrganizationTypeRelationshipTypes
                .Select(x => x.OrganizationTypeID)
                .ToList();
            CanApproveProjects = relationshipType.CanApproveProjects;
            IsPrimaryContact = relationshipType.IsPrimaryContact;
            CanOnlyBeRelatedOnceToAProject = relationshipType.CanOnlyBeRelatedOnceToAProject;
        }

        public void UpdateModel(RelationshipType relationshipType, ICollection<OrganizationTypeRelationshipType> allOrganizationTypeRelationshipTypes)
        {
            relationshipType.RelationshipTypeName = RelationshipTypeName;

            var organizationTypesUpdated = OrganizationTypeIDs.Select(x => new OrganizationTypeRelationshipType(x, relationshipType.RelationshipTypeID)).ToList();

            relationshipType.OrganizationTypeRelationshipTypes.Merge(organizationTypesUpdated,
                allOrganizationTypeRelationshipTypes,
                (x, y) => x.OrganizationTypeID == y.OrganizationTypeID && x.RelationshipTypeID == y.RelationshipTypeID);

            relationshipType.CanApproveProjects = CanApproveProjects ?? false; // Should never be null due to required validation attribute
            relationshipType.IsPrimaryContact = IsPrimaryContact ?? false; // Should never be null due to required validation attribute
            relationshipType.CanOnlyBeRelatedOnceToAProject = relationshipType.CanApproveProjects || relationshipType.IsPrimaryContact || (CanOnlyBeRelatedOnceToAProject ?? false); // can approve projects and isprimarycontact can only related once to a project
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var errors = new List<ValidationResult>();
            var existingRelationshipType = HttpRequestStorage.DatabaseEntities.RelationshipTypes.ToList();
            if (!RelationshipType.IsRelationshipTypeNameUnique(existingRelationshipType, RelationshipTypeName, RelationshipTypeID))
            {
                errors.Add(new SitkaValidationResult<EditRelationshipTypeViewModel, string>("Name already exists.", x => x.RelationshipTypeName));
            }

            if (CanApproveProjects == true &&
                existingRelationshipType.Any(x => x.RelationshipTypeID != RelationshipTypeID && x.CanApproveProjects))
            {
                errors.Add(new ValidationResult($"There can only be one {Models.FieldDefinition.ProjectRelationshipType.GetFieldDefinitionLabel()} in the system where \"Can Approve Projects?\" is set to \"Yes\"."));
            }

            if (IsPrimaryContact == true &&
                existingRelationshipType.Any(x => x.RelationshipTypeID != RelationshipTypeID && x.IsPrimaryContact))
            {
                errors.Add(new ValidationResult($"There can only be one {Models.FieldDefinition.ProjectRelationshipType.GetFieldDefinitionLabel()} in the system where \"Is Primary Contact?\" is set to \"Yes\"."));
            }
           
            return errors;
        }
    }
}
