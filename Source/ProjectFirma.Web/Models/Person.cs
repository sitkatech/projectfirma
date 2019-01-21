/*-----------------------------------------------------------------------
<copyright file="Person.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
using ProjectFirma.Web.Common;
using Keystone.Common;
using LtInfo.Common;
using ProjectFirma.Web.Security;

namespace ProjectFirma.Web.Models
{
    public partial class Person : IAuditableEntity, IKeystoneUser
    {
        public bool IsAnonymousUser => PersonID == PersonModelExtensions.AnonymousPersonID;

        public string FullNameFirstLast => $"{FirstName} {LastName}";

        public string FullNameFirstLastAndOrg => $"{FirstName} {LastName} - {Organization.DisplayName}";

        public string FullNameFirstLastAndOrgShortName => $"{FirstName} {LastName} ({Organization.OrganizationShortNameIfAvailable})";

        public string FullNameLastFirst => $"{LastName}, {FirstName}";

        /// <summary>
        /// List of Organizations for which this Person is the primary contact
        /// </summary>
        public List<Organization> PrimaryContactOrganizations
        {
            get { return OrganizationsWhereYouAreThePrimaryContactPerson.OrderBy(x => x.OrganizationName).ToList(); }
        }

        public string AuditDescriptionString => FullNameFirstLast;

        public Notification GetMostRecentReminder()
        {
            var notifications = Notifications.Where(x => x.NotificationType == NotificationType.ProjectUpdateReminder).ToList();

            if (notifications.Count == 0)
                return null;
            return notifications.OrderByDescending(y => y.NotificationDate).First();
        }

        /// <summary>
        /// All role names of BOTH types used by Keystone not for user display 
        /// </summary>
        public IEnumerable<string> RoleNames
        {
            get
            {
                if (IsAnonymousUser)
                {
                    // the presence of roles switches you from being IsAuthenticated or not
                    return new List<string>();
                }
                var roleNames = new List<string> {Role.RoleName};
                return roleNames;
            }
        }

        public void SetKeystoneUserClaims(IKeystoneUserClaims keystoneUserClaims)
        {
            Organization = HttpRequestStorage.DatabaseEntities.Organizations.Where(x => x.OrganizationGuid.HasValue).SingleOrDefault(x => x.OrganizationGuid == keystoneUserClaims.OrganizationGuid);
            Phone = keystoneUserClaims.PrimaryPhone.ToPhoneNumberString();
            Email = keystoneUserClaims.Email;
        }

        public bool CanStewardProject(Project project)
        {
            return MultiTenantHelpers.GetProjectStewardshipAreaType()?.CanStewardProject(this, project) ?? true;
        }

        public bool PersonIsProjectOwnerWhoCanStewardProjects
        {
            get
            {
                var canStewardProjectsOrganizationRelationship = MultiTenantHelpers.GetCanStewardProjectsOrganizationRelationship();
                if (MultiTenantHelpers.GetProjectStewardshipAreaType() == ProjectStewardshipAreaType.ProjectStewardingOrganizations)
                {
                    return Role.ProjectSteward.RoleID == RoleID &&
                           canStewardProjectsOrganizationRelationship != null &&
                           canStewardProjectsOrganizationRelationship.OrganizationTypeRelationshipTypes.Any(
                               x => x.OrganizationTypeID == Organization.OrganizationTypeID);
                }

                return Role.ProjectSteward.RoleID == RoleID;
            }
        }

        public List<HtmlString> GetProjectStewardshipAreaHtmlStringList()
        {
            return MultiTenantHelpers.GetProjectStewardshipAreaType()?.GetProjectStewardshipAreaHtmlStringList(this);
        }

        public bool IsAnonymousOrUnassigned => IsAnonymousUser || Role == Role.Unassigned;

        public bool CanViewProposals => MultiTenantHelpers.ShowProposalsToThePublic() || !IsAnonymousOrUnassigned;       
        public bool CanViewPendingProjects => new PendingProjectsViewListFeature().HasPermissionByPerson(this);

    }
}
