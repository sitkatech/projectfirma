using System;
using System.Collections.Generic;
using System.Linq;
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
    }
}