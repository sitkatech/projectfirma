//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[PersonStewardTaxonomyBranch]
using System.Collections.Generic;
using System.Linq;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static PersonStewardTaxonomyBranch GetPersonStewardTaxonomyBranch(this IQueryable<PersonStewardTaxonomyBranch> personStewardTaxonomyBranches, int personStewardTaxonomyBranchID)
        {
            var personStewardTaxonomyBranch = personStewardTaxonomyBranches.SingleOrDefault(x => x.PersonStewardTaxonomyBranchID == personStewardTaxonomyBranchID);
            Check.RequireNotNullThrowNotFound(personStewardTaxonomyBranch, "PersonStewardTaxonomyBranch", personStewardTaxonomyBranchID);
            return personStewardTaxonomyBranch;
        }

    }
}