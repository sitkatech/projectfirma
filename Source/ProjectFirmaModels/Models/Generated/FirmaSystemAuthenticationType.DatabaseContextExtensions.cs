//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[FirmaSystemAuthenticationType]
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
        public static FirmaSystemAuthenticationType GetFirmaSystemAuthenticationType(this IQueryable<FirmaSystemAuthenticationType> firmaSystemAuthenticationTypes, int firmaSystemAuthenticationTypeID)
        {
            var firmaSystemAuthenticationType = firmaSystemAuthenticationTypes.SingleOrDefault(x => x.FirmaSystemAuthenticationTypeID == firmaSystemAuthenticationTypeID);
            Check.RequireNotNullThrowNotFound(firmaSystemAuthenticationType, "FirmaSystemAuthenticationType", firmaSystemAuthenticationTypeID);
            return firmaSystemAuthenticationType;
        }

        // Delete using an IDList (Firma style)
        public static void DeleteFirmaSystemAuthenticationType(this IQueryable<FirmaSystemAuthenticationType> firmaSystemAuthenticationTypes, List<int> firmaSystemAuthenticationTypeIDList)
        {
            if(firmaSystemAuthenticationTypeIDList.Any())
            {
                firmaSystemAuthenticationTypes.Where(x => firmaSystemAuthenticationTypeIDList.Contains(x.FirmaSystemAuthenticationTypeID)).Delete();
            }
        }

        // Delete using an object list (Firma style)
        public static void DeleteFirmaSystemAuthenticationType(this IQueryable<FirmaSystemAuthenticationType> firmaSystemAuthenticationTypes, ICollection<FirmaSystemAuthenticationType> firmaSystemAuthenticationTypesToDelete)
        {
            if(firmaSystemAuthenticationTypesToDelete.Any())
            {
                var firmaSystemAuthenticationTypeIDList = firmaSystemAuthenticationTypesToDelete.Select(x => x.FirmaSystemAuthenticationTypeID).ToList();
                firmaSystemAuthenticationTypes.Where(x => firmaSystemAuthenticationTypeIDList.Contains(x.FirmaSystemAuthenticationTypeID)).Delete();
            }
        }

        public static void DeleteFirmaSystemAuthenticationType(this IQueryable<FirmaSystemAuthenticationType> firmaSystemAuthenticationTypes, int firmaSystemAuthenticationTypeID)
        {
            DeleteFirmaSystemAuthenticationType(firmaSystemAuthenticationTypes, new List<int> { firmaSystemAuthenticationTypeID });
        }

        public static void DeleteFirmaSystemAuthenticationType(this IQueryable<FirmaSystemAuthenticationType> firmaSystemAuthenticationTypes, FirmaSystemAuthenticationType firmaSystemAuthenticationTypeToDelete)
        {
            DeleteFirmaSystemAuthenticationType(firmaSystemAuthenticationTypes, new List<FirmaSystemAuthenticationType> { firmaSystemAuthenticationTypeToDelete });
        }
    }
}