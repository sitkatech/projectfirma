//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[PersonStewardTaxonomyBranch]
using System.Collections.Generic;
using System.Linq;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static PersonStewardTaxonomyBranch GetPersonStewardTaxonomyBranch(this IQueryable<PersonStewardTaxonomyBranch> personStewardTaxonomyBranches, int personStewardTaxonomyBranchID)
        {
            var personStewardTaxonomyBranch = personStewardTaxonomyBranches.SingleOrDefault(x => x.PersonStewardTaxonomyBranchID == personStewardTaxonomyBranchID);
            Check.RequireNotNullThrowNotFound(personStewardTaxonomyBranch, "PersonStewardTaxonomyBranch", personStewardTaxonomyBranchID);
            return personStewardTaxonomyBranch;
        }

        public static void DeletePersonStewardTaxonomyBranch(this List<int> personStewardTaxonomyBranchIDList)
        {
            if(personStewardTaxonomyBranchIDList.Any())
            {
                HttpRequestStorage.DatabaseEntities.AllPersonStewardTaxonomyBranches.RemoveRange(HttpRequestStorage.DatabaseEntities.PersonStewardTaxonomyBranches.Where(x => personStewardTaxonomyBranchIDList.Contains(x.PersonStewardTaxonomyBranchID)));
            }
        }

        public static void DeletePersonStewardTaxonomyBranch(this ICollection<PersonStewardTaxonomyBranch> personStewardTaxonomyBranchesToDelete)
        {
            if(personStewardTaxonomyBranchesToDelete.Any())
            {
                HttpRequestStorage.DatabaseEntities.AllPersonStewardTaxonomyBranches.RemoveRange(personStewardTaxonomyBranchesToDelete);
            }
        }

        public static void DeletePersonStewardTaxonomyBranch(this int personStewardTaxonomyBranchID)
        {
            DeletePersonStewardTaxonomyBranch(new List<int> { personStewardTaxonomyBranchID });
        }

        public static void DeletePersonStewardTaxonomyBranch(this PersonStewardTaxonomyBranch personStewardTaxonomyBranchToDelete)
        {
            DeletePersonStewardTaxonomyBranch(new List<PersonStewardTaxonomyBranch> { personStewardTaxonomyBranchToDelete });
        }
    }
}