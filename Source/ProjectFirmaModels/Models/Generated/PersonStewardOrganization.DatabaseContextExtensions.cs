//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[PersonStewardOrganization]
using System.Collections.Generic;
using System.Linq;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static PersonStewardOrganization GetPersonStewardOrganization(this IQueryable<PersonStewardOrganization> personStewardOrganizations, int personStewardOrganizationID)
        {
            var personStewardOrganization = personStewardOrganizations.SingleOrDefault(x => x.PersonStewardOrganizationID == personStewardOrganizationID);
            Check.RequireNotNullThrowNotFound(personStewardOrganization, "PersonStewardOrganization", personStewardOrganizationID);
            return personStewardOrganization;
        }

    }
}