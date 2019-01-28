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
using LtInfo.Common;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using ProjectFirmaModels.Models;

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
        [DisplayName("Can Steward?")]
        public bool? CanStewardProjects { get; set; }

        [Required]
        [DisplayName("Serves as Primary Contact?")]
        public bool? IsPrimaryContact { get; set; }

        [Required]
        [DisplayName("Must be Related to Once?")]
        public bool? CanOnlyBeRelatedOnceToAProject { get; set; }

        [Required]
        [DisplayName("Relationship Type Description")]
        public string RelationshipTypeDescription { get; set; }

        [Required]
        [DisplayName("Show on Fact Sheet?")]
        public bool? ShowOnFactSheet { get; set; }


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
            CanStewardProjects = relationshipType.CanStewardProjects;
            IsPrimaryContact = relationshipType.IsPrimaryContact;
            CanOnlyBeRelatedOnceToAProject = relationshipType.CanOnlyBeRelatedOnceToAProject;
            RelationshipTypeDescription = relationshipType.RelationshipTypeDescription;
            ShowOnFactSheet = relationshipType.ShowOnFactSheet;
        }

        public void UpdateModel(RelationshipType relationshipType, ICollection<OrganizationTypeRelationshipType> allOrganizationTypeRelationshipTypes)
        {
            relationshipType.RelationshipTypeName = RelationshipTypeName;

            var organizationTypesUpdated = OrganizationTypeIDs.Select(x => new OrganizationTypeRelationshipType(x, relationshipType.RelationshipTypeID)).ToList();

            relationshipType.OrganizationTypeRelationshipTypes.Merge(organizationTypesUpdated,
                allOrganizationTypeRelationshipTypes,
                (x, y) => x.OrganizationTypeID == y.OrganizationTypeID && x.RelationshipTypeID == y.RelationshipTypeID);

            relationshipType.CanStewardProjects = CanStewardProjects ?? false; // Should never be null due to required validation attribute
            relationshipType.IsPrimaryContact = IsPrimaryContact ?? false; // Should never be null due to required validation attribute
            relationshipType.CanOnlyBeRelatedOnceToAProject = relationshipType.CanStewardProjects || relationshipType.IsPrimaryContact || (CanOnlyBeRelatedOnceToAProject ?? false); // can steward projects and isprimarycontact can only related once to a project
            relationshipType.ShowOnFactSheet = ShowOnFactSheet ?? false; // sShould never be null due to required validation attribute
            relationshipType.RelationshipTypeDescription = RelationshipTypeDescription;
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var existingRelationshipType = HttpRequestStorage.DatabaseEntities.RelationshipTypes.ToList();
            if (!RelationshipTypeModelExtensions.IsRelationshipTypeNameUnique(existingRelationshipType, RelationshipTypeName, RelationshipTypeID))
            {
                yield return new SitkaValidationResult<EditRelationshipTypeViewModel, string>("Name already exists.",
                    x => x.RelationshipTypeName);
            }

            if (CanStewardProjects == true &&
                existingRelationshipType.Any(x => x.RelationshipTypeID != RelationshipTypeID && x.CanStewardProjects))
            {
                yield return new SitkaValidationResult<EditRelationshipTypeViewModel, bool?>(
                    $"There can only be one {FieldDefinitionEnum.ProjectRelationshipType.ToType().GetFieldDefinitionLabel()} in the system where \"Can Steward Projects?\" is set to \"Yes\".",
                    m => m.CanStewardProjects);
            }

            if (IsPrimaryContact == true &&
                existingRelationshipType.Any(x => x.RelationshipTypeID != RelationshipTypeID && x.IsPrimaryContact))
            {
                yield return new SitkaValidationResult<EditRelationshipTypeViewModel, bool?>(
                    $"There can only be one {FieldDefinitionEnum.ProjectRelationshipType.ToType().GetFieldDefinitionLabel()} in the system where \"Is Primary Contact?\" is set to \"Yes\".",
                    m => m.IsPrimaryContact);
            }
        }
    }
}
