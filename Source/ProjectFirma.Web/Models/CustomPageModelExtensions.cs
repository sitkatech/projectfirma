using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjectFirma.Web.Models
{
    public static class CustomPageModelExtensions
    {
        public static bool IsDisplayNameUnique(IEnumerable<CustomPage> customPages, string displayName, int currentCustomPageID)
        {
            return customPages.SingleOrDefault(x =>
                       x.CustomPageID != currentCustomPageID && String.Equals(x.CustomPageDisplayName, displayName, StringComparison.InvariantCultureIgnoreCase)) == null;
        }

        public static bool IsVanityUrlUnique(IEnumerable<CustomPage> customPages, string vanityUrl, int currentCustomPageID)
        {
            return customPages.SingleOrDefault(x =>
                       x.CustomPageID != currentCustomPageID && String.Equals(x.CustomPageVanityUrl, vanityUrl, StringComparison.InvariantCultureIgnoreCase)) == null;
        }
    }
}