//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[FirmaPage]
using System.Collections.Generic;
using System.Linq;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static FirmaPage GetFirmaPage(this IQueryable<FirmaPage> firmaPages, int firmaPageID)
        {
            var firmaPage = firmaPages.SingleOrDefault(x => x.FirmaPageID == firmaPageID);
            Check.RequireNotNullThrowNotFound(firmaPage, "FirmaPage", firmaPageID);
            return firmaPage;
        }

    }
}