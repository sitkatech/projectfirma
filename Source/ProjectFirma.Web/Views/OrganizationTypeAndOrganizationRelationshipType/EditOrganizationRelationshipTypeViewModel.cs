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
using ProjectFirmaModels;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Views.OrganizationTypeAndOrganizationRelationshipType
{
    public class EditOrganizationRelationshipTypeViewModel : FormViewModel, IValidatableObject
    {
        [Required]
        public int RelationshipTypeID { get; set; }

        [Required]
        [StringLength(OrganizationRelationshipType.FieldLengths.OrganizationRelationshipTypeName)]
        [DisplayName("Name")]
        public string OrganizationRelationshipTypeName { get; set; }
      
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
        [FieldDefinitionDisplay(FieldDefinitionEnum.IsOrganizationRelationshipTypeRequired)]
        public bool? IsOrganizationRelationshipTypeRequired { get; set; }

        [Required]
        [DisplayName("Relationship Type Description")]
        public string OrganizationRelationshipTypeDescription { get; set; }

        [Required]
        [DisplayName("Show on Fact Sheet?")]
        public bool? ShowOnFactSheet { get; set; }


        /// <summary>
        /// Needed by the ModelBinder
        /// </summary>
        public EditOrganizationRelationshipTypeViewModel()
        {
        }

        public EditOrganizationRelationshipTypeViewModel(OrganizationRelationshipType organizationRelationshipType)
        {
            RelationshipTypeID = organizationRelationshipType.OrganizationRelationshipTypeID;
            OrganizationRelationshipTypeName = organizationRelationshipType.OrganizationRelationshipTypeName;
            OrganizationTypeIDs = organizationRelationshipType.OrganizationTypeOrganizationRelationshipTypes
                .Select(x => x.OrganizationTypeID)
                .ToList();
            CanStewardProjects = organizationRelationshipType.CanStewardProjects;
            IsPrimaryContact = organizationRelationshipType.IsPrimaryContact;
            IsOrganizationRelationshipTypeRequired = organizationRelationshipType.IsOrganizationRelationshipTypeRequired;
            OrganizationRelationshipTypeDescription = organizationRelationshipType.OrganizationRelationshipTypeDescription;
            ShowOnFactSheet = organizationRelationshipType.ShowOnFactSheet;
        }

        public void UpdateModel(OrganizationRelationshipType organizationRelationshipType, ICollection<OrganizationTypeOrganizationRelationshipType> allOrganizationTypeOrganizationRelationshipTypes)
        {
            organizationRelationshipType.OrganizationRelationshipTypeName = OrganizationRelationshipTypeName;

            var organizationTypesUpdated = OrganizationTypeIDs.Select(x => new OrganizationTypeOrganizationRelationshipType(x, organizationRelationshipType.OrganizationRelationshipTypeID)).ToList();

            organizationRelationshipType.OrganizationTypeOrganizationRelationshipTypes.Merge(organizationTypesUpdated,
                allOrganizationTypeOrganizationRelationshipTypes,
                (x, y) => x.OrganizationTypeID == y.OrganizationTypeID && x.OrganizationRelationshipTypeID == y.OrganizationRelationshipTypeID, HttpRequestStorage.DatabaseEntities);

            organizationRelationshipType.CanStewardProjects = CanStewardProjects ?? false; // Should never be null due to required validation attribute
            organizationRelationshipType.IsPrimaryContact = IsPrimaryContact ?? false; // Should never be null due to required validation attribute
            organizationRelationshipType.IsOrganizationRelationshipTypeRequired = organizationRelationshipType.CanStewardProjects || organizationRelationshipType.IsPrimaryContact || (IsOrganizationRelationshipTypeRequired ?? false); // can steward projects and isprimarycontact can only related once to a project
            organizationRelationshipType.ShowOnFactSheet = ShowOnFactSheet ?? false; // sShould never be null due to required validation attribute
            organizationRelationshipType.OrganizationRelationshipTypeDescription = OrganizationRelationshipTypeDescription;
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var organizationRelationshipTypes = HttpRequestStorage.DatabaseEntities.OrganizationRelationshipTypes.ToList();
            if (!OrganizationRelationshipTypeModelExtensions.IsOrganizationRelationshipTypeNameUnique(organizationRelationshipTypes, OrganizationRelationshipTypeName, RelationshipTypeID))
            {
                yield return new SitkaValidationResult<EditOrganizationRelationshipTypeViewModel, string>("Name already exists.",
                    x => x.OrganizationRelationshipTypeName);
            }

            if (CanStewardProjects == true &&
                organizationRelationshipTypes.Any(x => x.OrganizationRelationshipTypeID != RelationshipTypeID && x.CanStewardProjects))
            {
                yield return new SitkaValidationResult<EditOrganizationRelationshipTypeViewModel, bool?>(
                    $"There can only be one {FieldDefinitionEnum.ProjectOrganizationRelationshipType.ToType().GetFieldDefinitionLabel()} in the system where \"Can Steward Projects?\" is set to \"Yes\".",
                    m => m.CanStewardProjects);
            }

            if (IsPrimaryContact == true &&
                organizationRelationshipTypes.Any(x => x.OrganizationRelationshipTypeID != RelationshipTypeID && x.IsPrimaryContact))
            {
                yield return new SitkaValidationResult<EditOrganizationRelationshipTypeViewModel, bool?>(
                    $"There can only be one {FieldDefinitionEnum.ProjectOrganizationRelationshipType.ToType().GetFieldDefinitionLabel()} in the system where \"Is Primary Contact?\" is set to \"Yes\".",
                    m => m.IsPrimaryContact);
            }

            // if the edit for the relationship type is changing the relationship to IsOrganizationRelationshipTypeRequired,
            // prevent them from doing that if there are already projects that have multiple organizations for that relationship type
            // This ensures that when we are looking for a primary contact through an organization, that there can only be one organization selected
            if (IsOrganizationRelationshipTypeRequired == true || IsPrimaryContact == true || CanStewardProjects == true)
            {
                var projectOrganizations = HttpRequestStorage.DatabaseEntities.ProjectOrganizations.ToList();
                var projectOrganizationsWithThisRelationshipTypeGroupedByProjectID = projectOrganizations.Where(x => x.OrganizationRelationshipTypeID == RelationshipTypeID).GroupBy(x => x.ProjectID).ToList();
                if (projectOrganizationsWithThisRelationshipTypeGroupedByProjectID.Any(c => c.Count() > 1))
                {
                    yield return new SitkaValidationResult<EditOrganizationRelationshipTypeViewModel, bool?>(
                        $"There are already {FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabelPluralized()} in the system with more than one {OrganizationRelationshipTypeName} selected.",
                        m => m.IsOrganizationRelationshipTypeRequired);
                }
            }

            // if the edit for the relationship type is changing the relationship to IsOrganizationRelationshipTypeRequired,
            // prevent them from doing that if there are already projects that have multiple organization updates for that relationship type
            // This ensures that when we are looking for a primary contact through an organization, that there can only be one organization selected
            if (IsOrganizationRelationshipTypeRequired == true || IsPrimaryContact == true || CanStewardProjects == true)
            {
                var projectOrganizationUpdatess = HttpRequestStorage.DatabaseEntities.ProjectOrganizationUpdates.ToList();
                var projectOrganizationUpdatesWithThisRelationshipTypeGroupedByProjectID = projectOrganizationUpdatess.Where(x => x.OrganizationRelationshipTypeID == RelationshipTypeID).GroupBy(x => x.ProjectUpdateBatchID).ToList();
                if (projectOrganizationUpdatesWithThisRelationshipTypeGroupedByProjectID.Any(c => c.Count() > 1))
                {
                    yield return new SitkaValidationResult<EditOrganizationRelationshipTypeViewModel, bool?>(
                        $"There are already {FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()} Updates in the system with more than one {OrganizationRelationshipTypeName} selected.",
                        m => m.IsOrganizationRelationshipTypeRequired);
                }
            }
        }
    }
}
