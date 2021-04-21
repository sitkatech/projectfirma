//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[PersonLoginAccount]
using System.Collections.Generic;
using System.Linq;
using CodeFirstStoreFunctions;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static PersonLoginAccount GetPersonLoginAccount(this IQueryable<PersonLoginAccount> personLoginAccounts, int personLoginAccountID)
        {
            var personLoginAccount = personLoginAccounts.SingleOrDefault(x => x.PersonLoginAccountID == personLoginAccountID);
            Check.RequireNotNullThrowNotFound(personLoginAccount, "PersonLoginAccount", personLoginAccountID);
            return personLoginAccount;
        }

    }
}