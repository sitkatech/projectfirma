//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[CustomPage]
using System.Collections.Generic;
using System.Linq;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static CustomPage GetCustomPage(this IQueryable<CustomPage> customPages, int customPageID)
        {
            var customPage = customPages.SingleOrDefault(x => x.CustomPageID == customPageID);
            Check.RequireNotNullThrowNotFound(customPage, "CustomPage", customPageID);
            return customPage;
        }

    }
}