//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[FieldDefinitionDataImage]
using System.Collections.Generic;
using System.Linq;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static FieldDefinitionDataImage GetFieldDefinitionDataImage(this IQueryable<FieldDefinitionDataImage> fieldDefinitionDataImages, int fieldDefinitionDataImageID)
        {
            var fieldDefinitionDataImage = fieldDefinitionDataImages.SingleOrDefault(x => x.FieldDefinitionDataImageID == fieldDefinitionDataImageID);
            Check.RequireNotNullThrowNotFound(fieldDefinitionDataImage, "FieldDefinitionDataImage", fieldDefinitionDataImageID);
            return fieldDefinitionDataImage;
        }

    }
}