/*-----------------------------------------------------------------------
<copyright file="PersonModelExtensions.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Security;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Models
{
    /// <summary>
    /// These have been implemented as extension methods on <see cref="Person"/> so we can handle the anonymous user as a null person object
    /// </summary>
    public static class PersonModelExtensions
    {
        public static HtmlString GetFullNameFirstLastAsUrl(this Person person)
        {
            return UrlTemplate.MakeHrefString(person.GetDetailUrl(), person.GetFullNameFirstLast());
        }

        public static HtmlString GetFullNameFirstLastAndOrgAsUrl(this Person person)
        {
            var userUrl = person.GetFullNameFirstLastAsUrl();
            var orgUrl = person.Organization.GetDisplayNameAsUrl();
            return new HtmlString($"{userUrl} - {orgUrl}");
        }

        public static HtmlString GetFullNameFirstLastAndOrgShortNameAsUrl(this Person person)
        {
            var userUrl = person.GetFullNameFirstLastAsUrl();
            var orgUrl = person.Organization.GetShortNameAsUrl();
            return new HtmlString($"{userUrl} ({orgUrl})");
        }

        public static HtmlString GetFullNameFirstLastAsStringAndOrgAsUrl(this Person person)
        {
            var userString = person.GetFullNameFirstLast();
            var orgUrl = person.Organization.GetShortNameAsUrl();
            return new HtmlString($"{userString} - {orgUrl}");
        }

        public static string GetFullNameFirstLastAndOrg(this Person person) => $"{person.FirstName} {person.LastName} - {person.Organization.GetDisplayName()}";

        public static string GetFullNameFirstLastAndOrgShortName(this Person person) =>
            $"{person.FirstName} {person.LastName} ({person.Organization.GetOrganizationShortNameIfAvailable()})";

        public static string GetOrganizationDescriptor(this Person person)
        {
            return person.Organization.IsUnknown()
                ? "Private Individual"
                : person.Organization.OrganizationName;
        }

        public static string GetEditUrl(this Person person)
        {
            return SitkaRoute<UserController>.BuildUrlFromExpression(t => t.EditRoles(person));
        }

        public static readonly UrlTemplate<int> DeleteUrlTemplate = new UrlTemplate<int>(SitkaRoute<UserController>.BuildUrlFromExpression(t => t.Delete(UrlTemplate.Parameter1Int)));
        public static string GetDeleteUrl(this Person person)
        {
            return DeleteUrlTemplate.ParameterReplace(person.PersonID);
        }

        public static readonly UrlTemplate<int> DetailUrlTemplate = new UrlTemplate<int>(SitkaRoute<UserController>.BuildUrlFromExpression(t => t.Detail(UrlTemplate.Parameter1Int)));
        public static string GetDetailUrl(this Person person)
        {
            return person != null ? DetailUrlTemplate.ParameterReplace(person.PersonID) : null;
        }

        public static bool IsAnonymousOrUnassigned(this Person person) => person.IsAnonymousUser() || person.Role == Role.Unassigned;

        public static bool IsSitkaAdministrator(this Person person)
        {
            return person != null && person.Role == Role.SitkaAdmin;

        }

        public static bool IsAdministrator(this Person person)
        {
            return person != null && (person.Role == Role.Admin || IsSitkaAdministrator(person));
        }

        public static bool IsApprover(this Person person)
        {
            return person != null && (person.IsAdministrator() || person.IsSitkaAdministrator());
        }
        
        public static bool ShouldReceiveNotifications(this Person person)
        {
            return person.ReceiveSupportEmails;
        }

        public static string GetKeystoneEditLink(this Person person)
        {
            return $"{FirmaWebConfiguration.KeystoneUserProfileUrl}{person.PersonGuid}";
        }

        /// <summary>
        /// Needed for Keystone; basically <see cref="HttpRequestStorage.Person" /> is set to this fake
        /// "Anonymous" person when we are not authenticated to not have to handle the null Person case.
        /// Seems like MR and all the other RPs do this so following the pattern
        /// </summary>
        /// <returns></returns>
        public static Person GetAnonymousSitkaUser()
        {
            var anonymousSitkaUser = new Person(Person.AnonymousPersonID, Guid.Empty, "Anonymous", "User", null, null, null, Role.Unassigned.RoleID, DateTime.Today, DateTime.Today, DateTime.Today, true, 2, false, null, null);
            anonymousSitkaUser.TenantID = HttpRequestStorage.Tenant?.TenantID ?? 0;
            // as we add new areas, we need to make sure we assign the anonymous user with the unassigned roles for each area
            return anonymousSitkaUser;
        }

        /// <summary>
        /// List of Projects for which this Person is the primary contact
        /// </summary>
        public static List<Project> GetPrimaryContactProjects(this Person person, Person currentPerson)
        {
            var isPersonViewingThePrimaryContact = currentPerson.PersonID == person.PersonID;
            if (isPersonViewingThePrimaryContact)
            {
                return person.ProjectsWhereYouAreThePrimaryContactPerson.ToList().Where(x => x.ProjectStage != ProjectStage.Terminated).ToList();
            }
            return person.ProjectsWhereYouAreThePrimaryContactPerson.ToList().GetActiveProjectsAndProposals(currentPerson.CanViewProposals()).ToList();
        }

        public static List<Project> GetPrimaryContactUpdatableProjects(this Person person, Person currentPerson)
        {
            return person.GetPrimaryContactProjects(currentPerson).Where(x => x.IsUpdatableViaProjectUpdateProcess()).ToList();
        }

        public static bool IsPersonAProjectOwnerWhoCanStewardProjects(this Person person)
        {
            var canStewardProjectsOrganizationRelationship = MultiTenantHelpers.GetCanStewardProjectsOrganizationRelationship();
            if (MultiTenantHelpers.GetProjectStewardshipAreaType() == ProjectStewardshipAreaType.ProjectStewardingOrganizations)
            {
                return Role.ProjectSteward.RoleID == person.RoleID &&
                       canStewardProjectsOrganizationRelationship != null &&
                       canStewardProjectsOrganizationRelationship.OrganizationTypeOrganizationRelationshipTypes.Any(
                           x => x.OrganizationTypeID == person.Organization.OrganizationTypeID);
            }

            return Role.ProjectSteward.RoleID == person.RoleID;
        }

        public static bool CanViewProposals(this Person person) => MultiTenantHelpers.ShowProposalsToThePublic() || !person.IsAnonymousOrUnassigned();

        public static List<HtmlString> GetProjectStewardshipAreaHtmlStringList(this Person person)
        {
            return MultiTenantHelpers.GetProjectStewardshipAreaType()?.GetProjectStewardshipAreaHtmlStringList(person);
        }

        public static bool CanViewPendingProjects(this Person person) => new PendingProjectsViewListFeature().HasPermissionByPerson(person);

        public static bool CanStewardProject(this Person person, Project project)
        {
            return MultiTenantHelpers.GetProjectStewardshipAreaType()?.CanStewardProject(person, project) ?? true;
        }

        public static Person GetPersonByEmail(this IQueryable<Person> people, string email)
        {
            return GetPersonByEmail(people, email, true);
        }

        public static Person GetPersonByEmail(this IQueryable<Person> people, string email, bool requireRecordFound)
        {
            var person = people.SingleOrDefault(x => x.Email == email);
            if (requireRecordFound)
            {
                Check.RequireNotNullThrowNotFound(person, email);
            }
            return person;
        }

        public static Person GetPersonByPersonGuid(this IQueryable<Person> people, Guid personGuid)
        {
            return GetPersonByPersonGuid(people, personGuid, false);
        }

        public static Person GetPersonByPersonGuid(this IQueryable<Person> people, Guid personGuid, bool requireRecordFound)
        {
            var person = people.SingleOrDefault(x => x.PersonGuid == personGuid);
            if (requireRecordFound)
            {
                Check.RequireNotNullThrowNotFound(person, personGuid.ToString());
            }
            return person;
        }

        public static Person GetPersonByWebServiceAccessToken(this IQueryable<Person> people, Guid webServiceAccessToken)
        {
            var person = people.SingleOrDefault(x => x.WebServiceAccessToken == webServiceAccessToken);
            return person;
        }

        public static List<Person> GetActivePeople(this IQueryable<Person> people)
        {
            return people.Where(x => x.IsActive).ToList().OrderBy(ht => ht.GetFullNameLastFirst()).ToList();
        }

        public static List<Person> GetPeopleWhoReceiveNotifications(this IQueryable<Person> people)
        {
            return people.ToList().Where(x => x.ShouldReceiveNotifications()).OrderBy(ht => ht.GetFullNameLastFirst()).ToList();
        }

        public static List<Person> GetPeopleWhoReceiveSupportEmails(this IQueryable<Person> people)
        {
            return people.ToList().Where(x => x.ReceiveSupportEmails && x.IsActive).OrderBy(ht => ht.GetFullNameLastFirst()).ToList();
        }
    }
}
