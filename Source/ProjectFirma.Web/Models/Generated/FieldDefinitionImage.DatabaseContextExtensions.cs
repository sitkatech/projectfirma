//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[FieldDefinitionImage]
using System.Collections.Generic;
using System.Linq;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static FieldDefinitionImage GetFieldDefinitionImage(this IQueryable<FieldDefinitionImage> fieldDefinitionImages, int fieldDefinitionImageID)
        {
            var fieldDefinitionImage = fieldDefinitionImages.SingleOrDefault(x => x.FieldDefinitionImageID == fieldDefinitionImageID);
            Check.RequireNotNullThrowNotFound(fieldDefinitionImage, "FieldDefinitionImage", fieldDefinitionImageID);
            return fieldDefinitionImage;
        }

        public static void DeleteFieldDefinitionImage(this List<int> fieldDefinitionImageIDList)
        {
            if(fieldDefinitionImageIDList.Any())
            {
                HttpRequestStorage.DatabaseEntities.AllFieldDefinitionImages.RemoveRange(HttpRequestStorage.DatabaseEntities.FieldDefinitionImages.Where(x => fieldDefinitionImageIDList.Contains(x.FieldDefinitionImageID)));
            }
        }

        public static void DeleteFieldDefinitionImage(this ICollection<FieldDefinitionImage> fieldDefinitionImagesToDelete)
        {
            if(fieldDefinitionImagesToDelete.Any())
            {
                HttpRequestStorage.DatabaseEntities.AllFieldDefinitionImages.RemoveRange(fieldDefinitionImagesToDelete);
            }
        }

        public static void DeleteFieldDefinitionImage(this int fieldDefinitionImageID)
        {
            DeleteFieldDefinitionImage(new List<int> { fieldDefinitionImageID });
        }

        public static void DeleteFieldDefinitionImage(this FieldDefinitionImage fieldDefinitionImageToDelete)
        {
            DeleteFieldDefinitionImage(new List<FieldDefinitionImage> { fieldDefinitionImageToDelete });
        }
    }
}