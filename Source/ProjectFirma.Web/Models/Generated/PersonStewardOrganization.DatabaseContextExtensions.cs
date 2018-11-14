//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[PersonStewardOrganization]
using System.Collections.Generic;
using System.Linq;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static PersonStewardOrganization GetPersonStewardOrganization(this IQueryable<PersonStewardOrganization> personStewardOrganizations, int personStewardOrganizationID)
        {
            var personStewardOrganization = personStewardOrganizations.SingleOrDefault(x => x.PersonStewardOrganizationID == personStewardOrganizationID);
            Check.RequireNotNullThrowNotFound(personStewardOrganization, "PersonStewardOrganization", personStewardOrganizationID);
            return personStewardOrganization;
        }

        public static void DeletePersonStewardOrganization(this List<int> personStewardOrganizationIDList)
        {
            if(personStewardOrganizationIDList.Any())
            {
                HttpRequestStorage.DatabaseEntities.AllPersonStewardOrganizations.RemoveRange(HttpRequestStorage.DatabaseEntities.PersonStewardOrganizations.Where(x => personStewardOrganizationIDList.Contains(x.PersonStewardOrganizationID)));
            }
        }

        public static void DeletePersonStewardOrganization(this ICollection<PersonStewardOrganization> personStewardOrganizationsToDelete)
        {
            if(personStewardOrganizationsToDelete.Any())
            {
                HttpRequestStorage.DatabaseEntities.AllPersonStewardOrganizations.RemoveRange(personStewardOrganizationsToDelete);
            }
        }

        public static void DeletePersonStewardOrganization(this int personStewardOrganizationID)
        {
            DeletePersonStewardOrganization(new List<int> { personStewardOrganizationID });
        }

        public static void DeletePersonStewardOrganization(this PersonStewardOrganization personStewardOrganizationToDelete)
        {
            DeletePersonStewardOrganization(new List<PersonStewardOrganization> { personStewardOrganizationToDelete });
        }
    }
}