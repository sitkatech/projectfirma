//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[TaxonomyBranch]
using System.Collections.Generic;
using System.Linq;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static TaxonomyBranch GetTaxonomyBranch(this IQueryable<TaxonomyBranch> taxonomyBranches, int taxonomyBranchID)
        {
            var taxonomyBranch = taxonomyBranches.SingleOrDefault(x => x.TaxonomyBranchID == taxonomyBranchID);
            Check.RequireNotNullThrowNotFound(taxonomyBranch, "TaxonomyBranch", taxonomyBranchID);
            return taxonomyBranch;
        }

        public static void DeleteTaxonomyBranch(this List<int> taxonomyBranchIDList)
        {
            if(taxonomyBranchIDList.Any())
            {
                HttpRequestStorage.DatabaseEntities.AllTaxonomyBranches.RemoveRange(HttpRequestStorage.DatabaseEntities.TaxonomyBranches.Where(x => taxonomyBranchIDList.Contains(x.TaxonomyBranchID)));
            }
        }

        public static void DeleteTaxonomyBranch(this ICollection<TaxonomyBranch> taxonomyBranchesToDelete)
        {
            if(taxonomyBranchesToDelete.Any())
            {
                HttpRequestStorage.DatabaseEntities.AllTaxonomyBranches.RemoveRange(taxonomyBranchesToDelete);
            }
        }

        public static void DeleteTaxonomyBranch(this int taxonomyBranchID)
        {
            DeleteTaxonomyBranch(new List<int> { taxonomyBranchID });
        }

        public static void DeleteTaxonomyBranch(this TaxonomyBranch taxonomyBranchToDelete)
        {
            DeleteTaxonomyBranch(new List<TaxonomyBranch> { taxonomyBranchToDelete });
        }
    }
}