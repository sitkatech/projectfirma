//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[FirmaPageType]
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
        public static FirmaPageType GetFirmaPageType(this IQueryable<FirmaPageType> firmaPageTypes, int firmaPageTypeID)
        {
            var firmaPageType = firmaPageTypes.SingleOrDefault(x => x.FirmaPageTypeID == firmaPageTypeID);
            Check.RequireNotNullThrowNotFound(firmaPageType, "FirmaPageType", firmaPageTypeID);
            return firmaPageType;
        }

        // Delete using an IDList (Firma style)
        public static void DeleteFirmaPageType(this IQueryable<FirmaPageType> firmaPageTypes, List<int> firmaPageTypeIDList)
        {
            if(firmaPageTypeIDList.Any())
            {
                firmaPageTypes.Where(x => firmaPageTypeIDList.Contains(x.FirmaPageTypeID)).Delete();
            }
        }

        // Delete using an object list (Firma style)
        public static void DeleteFirmaPageType(this IQueryable<FirmaPageType> firmaPageTypes, ICollection<FirmaPageType> firmaPageTypesToDelete)
        {
            if(firmaPageTypesToDelete.Any())
            {
                var firmaPageTypeIDList = firmaPageTypesToDelete.Select(x => x.FirmaPageTypeID).ToList();
                firmaPageTypes.Where(x => firmaPageTypeIDList.Contains(x.FirmaPageTypeID)).Delete();
            }
        }

        public static void DeleteFirmaPageType(this IQueryable<FirmaPageType> firmaPageTypes, int firmaPageTypeID)
        {
            DeleteFirmaPageType(firmaPageTypes, new List<int> { firmaPageTypeID });
        }

        public static void DeleteFirmaPageType(this IQueryable<FirmaPageType> firmaPageTypes, FirmaPageType firmaPageTypeToDelete)
        {
            DeleteFirmaPageType(firmaPageTypes, new List<FirmaPageType> { firmaPageTypeToDelete });
        }
    }
}