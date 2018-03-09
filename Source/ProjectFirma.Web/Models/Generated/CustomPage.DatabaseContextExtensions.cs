//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[CustomPage]
using System.Collections.Generic;
using System.Linq;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static CustomPage GetCustomPage(this IQueryable<CustomPage> customPages, int customPageID)
        {
            var customPage = customPages.SingleOrDefault(x => x.CustomPageID == customPageID);
            Check.RequireNotNullThrowNotFound(customPage, "CustomPage", customPageID);
            return customPage;
        }

        public static void DeleteCustomPage(this List<int> customPageIDList)
        {
            if(customPageIDList.Any())
            {
                HttpRequestStorage.DatabaseEntities.AllCustomPages.RemoveRange(HttpRequestStorage.DatabaseEntities.CustomPages.Where(x => customPageIDList.Contains(x.CustomPageID)));
            }
        }

        public static void DeleteCustomPage(this ICollection<CustomPage> customPagesToDelete)
        {
            if(customPagesToDelete.Any())
            {
                HttpRequestStorage.DatabaseEntities.AllCustomPages.RemoveRange(customPagesToDelete);
            }
        }

        public static void DeleteCustomPage(this int customPageID)
        {
            DeleteCustomPage(new List<int> { customPageID });
        }

        public static void DeleteCustomPage(this CustomPage customPageToDelete)
        {
            DeleteCustomPage(new List<CustomPage> { customPageToDelete });
        }
    }
}