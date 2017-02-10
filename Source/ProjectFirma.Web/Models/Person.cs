using System;
using System.Collections.Generic;
using System.Linq;
using ProjectFirma.Web.Common;
using Keystone.Common;
using LtInfo.Common;
using MoreLinq;

namespace ProjectFirma.Web.Models
{
    public partial class Person : IAuditableEntity, IKeystoneUser
    {
        private const int AnonymousPersonID = -999;

        /// <summary>
        /// Needed for Keystone; basically <see cref="HttpRequestStorage.Person" /> is set to this fake
        /// "Anonymous" person when we are not authenticated to not have to handle the null Person case.
        /// Seems like MR and all the other RPs do this so following the pattern
        /// </summary>
        /// <returns></returns>
        public static Person GetAnonymousSitkaUser()
        {
            var anonymousSitkaUser = new Person { PersonID = AnonymousPersonID };
            // as we add new areas, we need to make sure we assign the anonymous user with the unassigned roles for each area
            anonymousSitkaUser.RoleID = Role.Unassigned.RoleID;
            return anonymousSitkaUser;
        }

        public bool IsAnonymousUser
        {
            get { return PersonID == AnonymousPersonID; }
        }

        public string FullNameFirstLast
        {
            get { return String.Format("{0} {1}", FirstName, LastName); }
        }

        public string FullNameFirstLastAndOrg
        {
            get
            {
                string orgName = Organization.DisplayName;
                return String.Format("{0} {1} - {2}", FirstName, LastName, orgName);
            }
        }

        public string FullNameLastFirst
        {
            get { return String.Format("{0}, {1}", LastName, FirstName); }
        }

        /// <summary>
        /// List of Projects for which this Person is the primary contact
        /// </summary>
        public List<Project> GetPrimaryContactProjects()
        {
            return HttpRequestStorage.DatabaseEntities.Projects.ToList().Where(p => p.PrimaryContactPerson != null && p.PrimaryContactPerson.PersonID == PersonID).ToList();
        }

        public List<Project> GetPrimaryContactUpdatableProjects()
        {
            return GetPrimaryContactProjects().Where(x => x.IsUpdatableViaProjectUpdateProcess).ToList();
        }

        /// <summary>
        /// Is this Person the primary contact for one or more Projects?
        /// </summary>
        public bool IsPrimaryContactForOneOrMoreProjects
        {
            get { return GetPrimaryContactProjects().Any(); }
        }

        /// <summary>
        /// List of Organizations for which this Person is the primary contact
        /// </summary>
        public List<Organization> PrimaryContactOrganizations
        {
            get { return OrganizationsWhereYouAreThePrimaryContactPerson.OrderBy(x => x.OrganizationName).ToList(); }
        }

        public string AuditDescriptionString
        {
            get { return FullNameFirstLastAndOrg; }
        }

        public Notification GetMostRecentReminder()
        {
            var notifications = Notifications.Where(x => x.NotificationType == NotificationType.ProjectUpdateReminder).ToList();

            if (notifications.Count == 0)
                return null;
            return notifications.MaxBy(y => y.NotificationDate);
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
    }
}