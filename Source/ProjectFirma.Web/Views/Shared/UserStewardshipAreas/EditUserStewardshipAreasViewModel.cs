/*-----------------------------------------------------------------------
<copyright file="EditUserStewardshipAreasViewModel.cs" company="Tahoe Regional Planning Agency">
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
using System.ComponentModel.DataAnnotations;
using System.Linq;
using LtInfo.Common;
using LtInfo.Common.Models;
using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.Views.Shared.UserStewardshipAreas
{
    public class EditUserStewardshipAreasViewModel : FormViewModel, IValidatableObject
    {

        [Required]
        public int PersonID { get; set; }

        public List<PersonStewardshipAreaSimple> PersonStewardshipAreaSimples { get; set; }

        /// <summary>
        /// Needed by the ModelBinder
        /// </summary>
        public EditUserStewardshipAreasViewModel()
        {
        }

        public EditUserStewardshipAreasViewModel(Person person, Person currentPerson, ProjectStewardshipAreaType projectStewardshipAreaType)
        {
            PersonID = person.PersonID;
            if (projectStewardshipAreaType == ProjectStewardshipAreaType.ProjectStewardingOrganizations)
            {
                PersonStewardshipAreaSimples = person.PersonStewardOrganizations.OrderBy(x => x.Organization.DisplayName).Select(x => new PersonStewardshipAreaSimple(x)).ToList();
            }
            else if (projectStewardshipAreaType == ProjectStewardshipAreaType.TaxonomyBranches)
            {
                PersonStewardshipAreaSimples = person.PersonStewardTaxonomyBranches.OrderBy(x => x.TaxonomyBranch.SortOrder)
                    .ThenBy(x => x.TaxonomyBranch.DisplayName).Select(x => new PersonStewardshipAreaSimple(x)).ToList();
            }
        }

        public void UpdateModel(Person person, IList<PersonStewardOrganization> allPersonStewardOrganizations)
        {
            if (PersonStewardshipAreaSimples == null)
            {
                PersonStewardshipAreaSimples = new List<PersonStewardshipAreaSimple>();
            }

            var personStewardOrganizationUpdateds = PersonStewardshipAreaSimples.Select(x =>
            {
                var personStewardOrganization = new PersonStewardOrganization(
                    x.PersonStewardshipAreaID ?? ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue(), person.PersonID,
                    x.StewardshipAreaID.GetValueOrDefault()); // will never be null due to RequiredAttribute
                return personStewardOrganization;
            }).ToList();

            person.PersonStewardOrganizations.Merge(personStewardOrganizationUpdateds, 
                allPersonStewardOrganizations, 
                (x, y) => x.PersonStewardOrganizationID == y.PersonStewardOrganizationID,
                (x, y) =>
                {
                    x.PersonID = y.PersonID;
                    x.OrganizationID = y.OrganizationID;
                });

        }

        // TODO: If we add a new (third) Stewardship type, we need to make these methods generic to cut down on switching. See NJP about the approach.
        public void UpdateModel(Person person, IList<PersonStewardTaxonomyBranch> allPersonStewardTaxonomyBranches)
        {
            if (PersonStewardshipAreaSimples == null)
            {
                PersonStewardshipAreaSimples = new List<PersonStewardshipAreaSimple>();
            }

            var personStewardTaxonomyBranchUpdateds = PersonStewardshipAreaSimples.Select(x =>
            {
                var personStewardTaxonomyBranch = new PersonStewardTaxonomyBranch(
                    x.PersonStewardshipAreaID ?? ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue(), person.PersonID,
                    x.StewardshipAreaID.GetValueOrDefault()); // will never be null due to RequiredAttribute
                return personStewardTaxonomyBranch;
            }).ToList();

            person.PersonStewardTaxonomyBranches.Merge(personStewardTaxonomyBranchUpdateds,
                allPersonStewardTaxonomyBranches,
                (x, y) => x.PersonStewardTaxonomyBranchID == y.PersonStewardTaxonomyBranchID,
                (x, y) =>
                {
                    x.PersonID = y.PersonID;
                    x.TaxonomyBranchID = y.TaxonomyBranchID;
                });
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            yield break;
        }

    }
}