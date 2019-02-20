//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[SecondaryProjectTaxonomyLeaf]
using System.Collections.Generic;
using System.Linq;
using Z.EntityFramework.Plus;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static SecondaryProjectTaxonomyLeaf GetSecondaryProjectTaxonomyLeaf(this IQueryable<SecondaryProjectTaxonomyLeaf> secondaryProjectTaxonomyLeafs, int secondaryProjectTaxonomyLeafID)
        {
            var secondaryProjectTaxonomyLeaf = secondaryProjectTaxonomyLeafs.SingleOrDefault(x => x.SecondaryProjectTaxonomyLeafID == secondaryProjectTaxonomyLeafID);
            Check.RequireNotNullThrowNotFound(secondaryProjectTaxonomyLeaf, "SecondaryProjectTaxonomyLeaf", secondaryProjectTaxonomyLeafID);
            return secondaryProjectTaxonomyLeaf;
        }

        // Delete using an IDList (Firma style)
        public static void DeleteSecondaryProjectTaxonomyLeaf(this IQueryable<SecondaryProjectTaxonomyLeaf> secondaryProjectTaxonomyLeafs, List<int> secondaryProjectTaxonomyLeafIDList)
        {
            if(secondaryProjectTaxonomyLeafIDList.Any())
            {
                secondaryProjectTaxonomyLeafs.Where(x => secondaryProjectTaxonomyLeafIDList.Contains(x.SecondaryProjectTaxonomyLeafID)).Delete();
            }
        }

        // Delete using an object list (Firma style)
        public static void DeleteSecondaryProjectTaxonomyLeaf(this IQueryable<SecondaryProjectTaxonomyLeaf> secondaryProjectTaxonomyLeafs, ICollection<SecondaryProjectTaxonomyLeaf> secondaryProjectTaxonomyLeafsToDelete)
        {
            if(secondaryProjectTaxonomyLeafsToDelete.Any())
            {
                var secondaryProjectTaxonomyLeafIDList = secondaryProjectTaxonomyLeafsToDelete.Select(x => x.SecondaryProjectTaxonomyLeafID).ToList();
                secondaryProjectTaxonomyLeafs.Where(x => secondaryProjectTaxonomyLeafIDList.Contains(x.SecondaryProjectTaxonomyLeafID)).Delete();
            }
        }

        public static void DeleteSecondaryProjectTaxonomyLeaf(this IQueryable<SecondaryProjectTaxonomyLeaf> secondaryProjectTaxonomyLeafs, int secondaryProjectTaxonomyLeafID)
        {
            DeleteSecondaryProjectTaxonomyLeaf(secondaryProjectTaxonomyLeafs, new List<int> { secondaryProjectTaxonomyLeafID });
        }

        public static void DeleteSecondaryProjectTaxonomyLeaf(this IQueryable<SecondaryProjectTaxonomyLeaf> secondaryProjectTaxonomyLeafs, SecondaryProjectTaxonomyLeaf secondaryProjectTaxonomyLeafToDelete)
        {
            DeleteSecondaryProjectTaxonomyLeaf(secondaryProjectTaxonomyLeafs, new List<SecondaryProjectTaxonomyLeaf> { secondaryProjectTaxonomyLeafToDelete });
        }
    }
}