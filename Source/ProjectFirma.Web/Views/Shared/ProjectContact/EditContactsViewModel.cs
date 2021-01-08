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
        /// <summary>
        /// Only needed during validation
        /// </summary>
        public int ProjectStageID { get; set; }

        [FieldDefinitionDisplay(FieldDefinitionEnum.ProjectPrimaryContact)]
        public int? PrimaryContactPersonID { get; set; }
        public List<ProjectContactSimple> ProjectContactSimples { get; set; }

        /// <summary>
        /// Needed by Model Binder
        /// </summary>
        public EditContactsViewModel()
        {
        }

        public EditContactsViewModel(ProjectFirmaModels.Models.Project project,
                                    List<ProjectFirmaModels.Models.ProjectContact> projectContacts,
                                    FirmaSession currentFirmaSession)
        {
            ProjectStageID = project.ProjectStageID;
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

        public static string GetRequiredRelationshipTypeErrorStringSuffix(ProjectStage currentProjectStage, ProjectFirmaModels.Models.ContactRelationshipType contactRelationshipType)
        {
            bool hasMinimumProjectStageSet = contactRelationshipType.IsContactRelationshipRequiredMinimumProjectStage != null;
            if (hasMinimumProjectStageSet && currentProjectStage.SortOrder >= contactRelationshipType.IsContactRelationshipRequiredMinimumProjectStage.SortOrder)
            {
                return $"Project Stage is at or beyond {contactRelationshipType.IsContactRelationshipRequiredMinimumProjectStage.ProjectStageDisplayName}, when the {contactRelationshipType.ContactRelationshipTypeName} must be set.";
            }

            return string.Empty;
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

            var currentProjectStage = ProjectStage.AllLookupDictionary[this.ProjectStageID];

            // Is the ContactRelationship required?
            var relationshipTypeThatIsRequired = HttpRequestStorage.DatabaseEntities.ContactRelationshipTypes.Where(x => x.IsContactRelationshipTypeRequired).ToList();
            // Only required if current ProjectStage is at or beyond the minimum level required for this ContactRelationshipType, if set. For example, not required until Implementation.
            // Note that we rely on *SORT ORDER* here to determine the temporal order of the ProjectStages.
            var relationshipTypeThatIsRequiredFiltered = relationshipTypeThatIsRequired.Where(rt => rt.IsContactRelationshipRequiredMinimumProjectStage == null ||
                                                                                                                   currentProjectStage.SortOrder >= rt.IsContactRelationshipRequiredMinimumProjectStage.SortOrder).ToList();

            var projectContactsGroupedByRelationshipTypeID = ProjectContactSimples.GroupBy(x => x.ContactRelationshipTypeID).ToList();

            errors.AddRange(relationshipTypeThatIsRequiredFiltered
                .Where(rt => projectContactsGroupedByRelationshipTypeID.Count(po => po.Key == rt.ContactRelationshipTypeID) > 1)
                .Select(relationshipType => new ValidationResult(
                    $"Cannot have more than one Contact with a {FieldDefinitionEnum.ProjectContactRelationshipType.ToType().GetFieldDefinitionLabel()} set to \"{relationshipType.ContactRelationshipTypeName}\". {GetRequiredRelationshipTypeErrorStringSuffix(currentProjectStage, relationshipType)}")));

            errors.AddRange(relationshipTypeThatIsRequiredFiltered
                .Where(rt => projectContactsGroupedByRelationshipTypeID.Count(po => po.Key == rt.ContactRelationshipTypeID) == 0)
                .Select(relationshipType => new ValidationResult(
                    $"Must have one Contact with a {FieldDefinitionEnum.ProjectContactRelationshipType.ToType().GetFieldDefinitionLabel()} set to \"{relationshipType.ContactRelationshipTypeName}\". {GetRequiredRelationshipTypeErrorStringSuffix(currentProjectStage, relationshipType)}")));

            return errors;
        }
    }
}
