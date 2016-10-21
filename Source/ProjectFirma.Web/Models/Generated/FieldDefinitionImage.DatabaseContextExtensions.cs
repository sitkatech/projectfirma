//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[FieldDefinitionImage]
using System.Collections.Generic;
using System.Linq;
using EntityFramework.Extensions;
using ProjectFirma.Web.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

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

        public static void DeleteFieldDefinitionImage(this IQueryable<FieldDefinitionImage> fieldDefinitionImages, List<int> fieldDefinitionImageIDList)
        {
            if(fieldDefinitionImageIDList.Any())
            {
                fieldDefinitionImages.Where(x => fieldDefinitionImageIDList.Contains(x.FieldDefinitionImageID)).Delete();
            }
        }

        public static void DeleteFieldDefinitionImage(this IQueryable<FieldDefinitionImage> fieldDefinitionImages, ICollection<FieldDefinitionImage> fieldDefinitionImagesToDelete)
        {
            if(fieldDefinitionImagesToDelete.Any())
            {
                var fieldDefinitionImageIDList = fieldDefinitionImagesToDelete.Select(x => x.FieldDefinitionImageID).ToList();
                fieldDefinitionImages.Where(x => fieldDefinitionImageIDList.Contains(x.FieldDefinitionImageID)).Delete();
            }
        }

        public static void DeleteFieldDefinitionImage(this IQueryable<FieldDefinitionImage> fieldDefinitionImages, int fieldDefinitionImageID)
        {
            DeleteFieldDefinitionImage(fieldDefinitionImages, new List<int> { fieldDefinitionImageID });
        }

        public static void DeleteFieldDefinitionImage(this IQueryable<FieldDefinitionImage> fieldDefinitionImages, FieldDefinitionImage fieldDefinitionImageToDelete)
        {
            DeleteFieldDefinitionImage(fieldDefinitionImages, new List<FieldDefinitionImage> { fieldDefinitionImageToDelete });
        }
    }
}