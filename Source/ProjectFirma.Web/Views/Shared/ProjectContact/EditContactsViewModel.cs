/*-----------------------------------------------------------------------
<copyright file="EditContactsViewModel.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
using System.ComponentModel.DataAnnotations;
using System.Linq;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using ProjectFirmaModels;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Views.Shared.ProjectContact
{
    public class EditContactsViewModel : FormViewModel, IValidatableObject
    {
        [FieldDefinitionDisplay(FieldDefinitionEnum.ProjectPrimaryContact)]
        public int? PrimaryContactPersonID { get; set; }
        public List<ProjectContactSimple> ProjectContactSimples { get; set; }

        /// <summary>
        /// Needed by Model Binder
        /// </summary>
        public EditContactsViewModel()
        {
        }

        public EditContactsViewModel(ProjectFirmaModels.Models.Project project, List<ProjectFirmaModels.Models.ProjectContact> projectContacts,
            FirmaSession currentFirmaSession)
        {           
            PrimaryContactPersonID = project.PrimaryContactPersonID;
            ProjectContactSimples = projectContacts.Select(x => new ProjectContactSimple(x)).ToList();
        }

        public void UpdateModel(ProjectFirmaModels.Models.Project project, ICollection<ProjectFirmaModels.Models.ProjectContact> allProjectContacts)
        {
            project.PrimaryContactPersonID = PrimaryContactPersonID;

            var projectContactsUpdated = ProjectContactSimples.Where(x => ModelObjectHelpers.IsRealPrimaryKeyValue(x.ContactID)).Select(x =>
                new ProjectFirmaModels.Models.ProjectContact(project.ProjectID, x.ContactID, x.ContactRelationshipTypeID)).ToList();

            project.ProjectContacts.Merge(projectContactsUpdated,
                allProjectContacts,
                (x, y) => x.ProjectID == y.ProjectID && x.ContactID == y.ContactID && x.ContactRelationshipTypeID == y.ContactRelationshipTypeID, HttpRequestStorage.DatabaseEntities);
        }

        public virtual IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            return GetValidationResults();
        }

        public IEnumerable<ValidationResult> GetValidationResults()
        {
            var errors = new List<ValidationResult>();

            if (ProjectContactSimples == null)
            {
                ProjectContactSimples = new List<ProjectContactSimple>();
            }

            if (ProjectContactSimples.GroupBy(x => new { RelationshipTypeID = x.ContactRelationshipTypeID, PersonID = x.ContactID }).Any(x => x.Count() > 1))
            {
                errors.Add(new ValidationResult($"Cannot have the same relationship type listed for the same contact multiple times."));
            }
            
            var relationshipTypeThatIsRequiredAndOnlyOneSelected = HttpRequestStorage.DatabaseEntities.ContactRelationshipTypes.Where(x => x.IsContactRelationshipTypeRequired).ToList();

            var projectContactsGroupedByRelationshipTypeID = ProjectContactSimples.GroupBy(x => x.ContactRelationshipTypeID).ToList();

            errors.AddRange(relationshipTypeThatIsRequiredAndOnlyOneSelected
                .Where(rt => projectContactsGroupedByRelationshipTypeID.Count(po => po.Key == rt.ContactRelationshipTypeID) > 1)
                .Select(relationshipType => new ValidationResult(
                    $"Cannot have more than one contact with a {FieldDefinitionEnum.ProjectContactRelationshipType.ToType().GetFieldDefinitionLabel()} set to \"{relationshipType.ContactRelationshipTypeName}\".")));

            errors.AddRange(relationshipTypeThatIsRequiredAndOnlyOneSelected
                .Where(rt => projectContactsGroupedByRelationshipTypeID.Count(po => po.Key == rt.ContactRelationshipTypeID) == 0)
                .Select(relationshipType => new ValidationResult(
                    $"Must have one contact with a {FieldDefinitionEnum.ProjectContactRelationshipType.ToType().GetFieldDefinitionLabel()} set to \"{relationshipType.ContactRelationshipTypeName}\".")));

            //var allValidRelationshipTypes = ProjectContactSimples.All(x =>
            //{
            //    var contact = HttpRequestStorage.DatabaseEntities.People.FirstOrDefault(people => people.PersonID == x.ContactID);
            //    var contactType = contact.ContactType;

            //    if (contactType != null)
            //    {
            //        var contactTypeContactRelationshipTypeIDs =
            //            contactType.ContactTypeContactRelationshipTypes.Select(y => y.ContactRelationshipTypeID);

            //        return contactTypeContactRelationshipTypeIDs.Contains(x.ContactRelationshipTypeID);
            //    }
            //    return false;
            //});

            //if (!allValidRelationshipTypes)
            //{
            //    errors.Add(new ValidationResult("One or more relationship types are invalid."));
            //}

            return errors;
        }
    }
}
