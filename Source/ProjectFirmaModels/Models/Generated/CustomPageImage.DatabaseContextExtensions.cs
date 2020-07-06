//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[CustomPageImage]
using System.Collections.Generic;
using System.Linq;
using CodeFirstStoreFunctions;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static CustomPageImage GetCustomPageImage(this IQueryable<CustomPageImage> customPageImages, int customPageImageID)
        {
            var customPageImage = customPageImages.SingleOrDefault(x => x.CustomPageImageID == customPageImageID);
            Check.RequireNotNullThrowNotFound(customPageImage, "CustomPageImage", customPageImageID);
            return customPageImage;
        }

    }
}