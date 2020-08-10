using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LtInfo.Common.Views;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Models
{
    public static class CustomPageModelExtensions
    {
        public static bool IsDisplayNameUnique(IEnumerable<CustomPage> customPages, string displayName, int currentCustomPageID)
        {
            return customPages.SingleOrDefault(x =>
                       x.CustomPageID != currentCustomPageID && string.Equals(x.CustomPageDisplayName, displayName, StringComparison.InvariantCultureIgnoreCase)) == null;
        }

        public static bool IsVanityUrlUnique(IEnumerable<CustomPage> customPages, string vanityUrl, int currentCustomPageID)
        {
            return customPages.SingleOrDefault(x =>
                       x.CustomPageID != currentCustomPageID && string.Equals(x.CustomPageVanityUrl, vanityUrl, StringComparison.InvariantCultureIgnoreCase)) == null;
        }

        public static string GetAboutPageUrl(this CustomPage customPage) =>
            SitkaRoute<CustomPageController>.BuildUrlFromExpression(t => t.About(customPage.CustomPageVanityUrl));

        public static string GetDeleteUrl(this CustomPage customPage) =>
            SitkaRoute<CustomPageController>.BuildUrlFromExpression(c => c.DeleteCustomPage(customPage.CustomPageID));

        public static string GetViewableRolesAsListOfStrings(this CustomPage customPage)
        {
            var customPageRoles = HttpRequestStorage.DatabaseEntities.CustomPageRoles.Where(x => x.CustomPageID == customPage.CustomPageID).ToList();
            return customPage.CustomPageRoles.Any()
                ? string.Join(", ", customPage.CustomPageRoles.OrderBy(x => x.Role?.SortOrder).Select(x => x.Role == null ? "Anonymous (Public)" : x.Role.GetRoleDisplayName()).ToList())
                : "Disabled";
        }

        public static bool IsDisabled(this CustomPage customPage)
        {
            return !customPage.CustomPageRoles.Any();
        }

        // public static HtmlString GetViewableRoles(this CustomPage customPage)
        // {
        //     var customPageRoles = HttpRequestStorage.DatabaseEntities.CustomPageRoles.Where(x => x.CustomPageID == customPage.CustomPageID).ToList();
        //     return new HtmlString(customPageRoles.Any()
        //         ? string.Join(", ", customPageRoles.OrderBy(x => x.Role?.SortOrder).Select(x => x.Role == null ? "Anonymous (Public)" : x.Role.GetRoleDisplayName()).ToList())
        //         : "Disabled");
        // }
    }
}