//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[PersonLoginAccount]
using System.Collections.Generic;
using System.Linq;
using Z.EntityFramework.Plus;
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

        // Delete using an IDList (Firma style)
        public static void DeletePersonLoginAccount(this IQueryable<PersonLoginAccount> personLoginAccounts, List<int> personLoginAccountIDList)
        {
            if(personLoginAccountIDList.Any())
            {
                personLoginAccounts.Where(x => personLoginAccountIDList.Contains(x.PersonLoginAccountID)).Delete();
            }
        }

        // Delete using an object list (Firma style)
        public static void DeletePersonLoginAccount(this IQueryable<PersonLoginAccount> personLoginAccounts, ICollection<PersonLoginAccount> personLoginAccountsToDelete)
        {
            if(personLoginAccountsToDelete.Any())
            {
                var personLoginAccountIDList = personLoginAccountsToDelete.Select(x => x.PersonLoginAccountID).ToList();
                personLoginAccounts.Where(x => personLoginAccountIDList.Contains(x.PersonLoginAccountID)).Delete();
            }
        }

        public static void DeletePersonLoginAccount(this IQueryable<PersonLoginAccount> personLoginAccounts, int personLoginAccountID)
        {
            DeletePersonLoginAccount(personLoginAccounts, new List<int> { personLoginAccountID });
        }

        public static void DeletePersonLoginAccount(this IQueryable<PersonLoginAccount> personLoginAccounts, PersonLoginAccount personLoginAccountToDelete)
        {
            DeletePersonLoginAccount(personLoginAccounts, new List<PersonLoginAccount> { personLoginAccountToDelete });
        }
    }
}