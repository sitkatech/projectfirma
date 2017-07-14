/*-----------------------------------------------------------------------
<copyright file="EditOrganizationsViewModelValidator.cs" company="Tahoe Regional Planning Agency">
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
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using ProjectFirma.Web.Common;
using FluentValidation;

namespace ProjectFirma.Web.Views.ProjectOrganization
{
    public class EditOrganizationsViewModelValidator : AbstractValidator<EditOrganizationsViewModel>
    {
        // Validators are singletons, so this list must be initialized every time.
        public Func<IList<Models.Organization>> AllOrganizations = () =>
        {
            HttpRequestStorage.DatabaseEntities.Organizations.Load();
            return HttpRequestStorage.DatabaseEntities.AllOrganizations.Local;
        };

        public EditOrganizationsViewModelValidator(IList<Models.Organization> organizations) : this()
        {
            AllOrganizations = (() => organizations);
        }

        public EditOrganizationsViewModelValidator()
        {
            RuleFor(x => x.ProjectOrganizationsViewModelJson)
                .Must(HasOneLeadImplementer)
                .WithMessage(FirmaValidationMessages.ProjectOrganizationLeadShouldBeSetIfThereAreAnyOrganizations)
                .Must(LeadImplementingOrganizationIfSetMustHavePrimaryContactSet)
                .WithMessage(FirmaValidationMessages.LeadImplementingOrganizationMustHavePrimaryContactSet);
        }

        /// <summary>
        /// If there are any orgs, one of them must be the lead implementer
        /// </summary>
        /// <param name="projectOrganizationsViewModelJson"></param>
        /// <returns></returns>
        private static bool HasOneLeadImplementer(ProjectOrganizationsViewModelJson projectOrganizationsViewModelJson)
        {
            var meetsRule = projectOrganizationsViewModelJson.ProjectOrganizations.Any(x => x.OrganizationID == projectOrganizationsViewModelJson.LeadOrganizationID);
            return meetsRule;
        }

        /// <summary>
        /// If there are any orgs, one of them must be the lead implementer
        /// </summary>
        /// <param name="projectOrganizationsViewModelJson"></param>
        /// <returns></returns>
        private bool LeadImplementingOrganizationIfSetMustHavePrimaryContactSet(ProjectOrganizationsViewModelJson projectOrganizationsViewModelJson)
        {
            if (projectOrganizationsViewModelJson.ProjectOrganizations.Any())
            {
                var leadImplementingOrganization = projectOrganizationsViewModelJson.ProjectOrganizations.SingleOrDefault(x => x.OrganizationID == projectOrganizationsViewModelJson.LeadOrganizationID);
                if (leadImplementingOrganization == null)
                    return false;

                var theLeadImplementingOrg = AllOrganizations().Single(org => org.OrganizationID == leadImplementingOrganization.OrganizationID);
                return theLeadImplementingOrg.PrimaryContactPerson != null;
            }
            return true;
        }
    }
}
