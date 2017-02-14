//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[FirmaPage]
using System.Collections.Generic;
using System.Linq;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static FirmaPage GetFirmaPage(this IQueryable<FirmaPage> firmaPages, int firmaPageID)
        {
            var firmaPage = firmaPages.SingleOrDefault(x => x.FirmaPageID == firmaPageID);
            Check.RequireNotNullThrowNotFound(firmaPage, "FirmaPage", firmaPageID);
            return firmaPage;
        }

        public static void DeleteFirmaPage(this List<int> firmaPageIDList)
        {
            if(firmaPageIDList.Any())
            {
                HttpRequestStorage.DatabaseEntities.AllFirmaPages.RemoveRange(HttpRequestStorage.DatabaseEntities.FirmaPages.Where(x => firmaPageIDList.Contains(x.FirmaPageID)));
            }
        }

        public static void DeleteFirmaPage(this ICollection<FirmaPage> firmaPagesToDelete)
        {
            if(firmaPagesToDelete.Any())
            {
                HttpRequestStorage.DatabaseEntities.AllFirmaPages.RemoveRange(firmaPagesToDelete);
            }
        }

        public static void DeleteFirmaPage(this int firmaPageID)
        {
            DeleteFirmaPage(new List<int> { firmaPageID });
        }

        public static void DeleteFirmaPage(this FirmaPage firmaPageToDelete)
        {
            DeleteFirmaPage(new List<FirmaPage> { firmaPageToDelete });
        }
    }
}