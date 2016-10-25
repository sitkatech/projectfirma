//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[FirmaPage]
using System.Collections.Generic;
using System.Linq;
using EntityFramework.Extensions;
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

        public static void DeleteFirmaPage(this IQueryable<FirmaPage> firmaPages, List<int> firmaPageIDList)
        {
            if(firmaPageIDList.Any())
            {
                firmaPages.Where(x => firmaPageIDList.Contains(x.FirmaPageID)).Delete();
            }
        }

        public static void DeleteFirmaPage(this IQueryable<FirmaPage> firmaPages, ICollection<FirmaPage> firmaPagesToDelete)
        {
            if(firmaPagesToDelete.Any())
            {
                var firmaPageIDList = firmaPagesToDelete.Select(x => x.FirmaPageID).ToList();
                firmaPages.Where(x => firmaPageIDList.Contains(x.FirmaPageID)).Delete();
            }
        }

        public static void DeleteFirmaPage(this IQueryable<FirmaPage> firmaPages, int firmaPageID)
        {
            DeleteFirmaPage(firmaPages, new List<int> { firmaPageID });
        }

        public static void DeleteFirmaPage(this IQueryable<FirmaPage> firmaPages, FirmaPage firmaPageToDelete)
        {
            DeleteFirmaPage(firmaPages, new List<FirmaPage> { firmaPageToDelete });
        }
    }
}