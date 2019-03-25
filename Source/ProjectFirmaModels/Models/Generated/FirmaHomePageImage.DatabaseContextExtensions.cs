//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[FirmaHomePageImage]
using System.Collections.Generic;
using System.Linq;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static FirmaHomePageImage GetFirmaHomePageImage(this IQueryable<FirmaHomePageImage> firmaHomePageImages, int firmaHomePageImageID)
        {
            var firmaHomePageImage = firmaHomePageImages.SingleOrDefault(x => x.FirmaHomePageImageID == firmaHomePageImageID);
            Check.RequireNotNullThrowNotFound(firmaHomePageImage, "FirmaHomePageImage", firmaHomePageImageID);
            return firmaHomePageImage;
        }

    }
}