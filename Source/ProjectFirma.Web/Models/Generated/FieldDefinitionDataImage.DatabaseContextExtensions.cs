//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[FieldDefinitionDataImage]
using System.Collections.Generic;
using System.Linq;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static FieldDefinitionDataImage GetFieldDefinitionDataImage(this IQueryable<FieldDefinitionDataImage> fieldDefinitionDataImages, int fieldDefinitionDataImageID)
        {
            var fieldDefinitionDataImage = fieldDefinitionDataImages.SingleOrDefault(x => x.FieldDefinitionDataImageID == fieldDefinitionDataImageID);
            Check.RequireNotNullThrowNotFound(fieldDefinitionDataImage, "FieldDefinitionDataImage", fieldDefinitionDataImageID);
            return fieldDefinitionDataImage;
        }

        public static void DeleteFieldDefinitionDataImage(this List<int> fieldDefinitionDataImageIDList)
        {
            if(fieldDefinitionDataImageIDList.Any())
            {
                HttpRequestStorage.DatabaseEntities.AllFieldDefinitionDataImages.RemoveRange(HttpRequestStorage.DatabaseEntities.FieldDefinitionDataImages.Where(x => fieldDefinitionDataImageIDList.Contains(x.FieldDefinitionDataImageID)));
            }
        }

        public static void DeleteFieldDefinitionDataImage(this ICollection<FieldDefinitionDataImage> fieldDefinitionDataImagesToDelete)
        {
            if(fieldDefinitionDataImagesToDelete.Any())
            {
                HttpRequestStorage.DatabaseEntities.AllFieldDefinitionDataImages.RemoveRange(fieldDefinitionDataImagesToDelete);
            }
        }

        public static void DeleteFieldDefinitionDataImage(this int fieldDefinitionDataImageID)
        {
            DeleteFieldDefinitionDataImage(new List<int> { fieldDefinitionDataImageID });
        }

        public static void DeleteFieldDefinitionDataImage(this FieldDefinitionDataImage fieldDefinitionDataImageToDelete)
        {
            DeleteFieldDefinitionDataImage(new List<FieldDefinitionDataImage> { fieldDefinitionDataImageToDelete });
        }
    }
}