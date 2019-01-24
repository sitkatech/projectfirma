//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[FirmaPageImage]
using System.Collections.Generic;
using System.Linq;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static FirmaPageImage GetFirmaPageImage(this IQueryable<FirmaPageImage> firmaPageImages, int firmaPageImageID)
        {
            var firmaPageImage = firmaPageImages.SingleOrDefault(x => x.FirmaPageImageID == firmaPageImageID);
            Check.RequireNotNullThrowNotFound(firmaPageImage, "FirmaPageImage", firmaPageImageID);
            return firmaPageImage;
        }

    }
}