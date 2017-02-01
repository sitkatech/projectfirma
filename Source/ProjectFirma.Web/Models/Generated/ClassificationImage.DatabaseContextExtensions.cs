//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ClassificationImage]
using System.Collections.Generic;
using System.Linq;
using Z.EntityFramework.Plus;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static ClassificationImage GetClassificationImage(this IQueryable<ClassificationImage> classificationImages, int classificationImageID)
        {
            var classificationImage = classificationImages.SingleOrDefault(x => x.ClassificationImageID == classificationImageID);
            Check.RequireNotNullThrowNotFound(classificationImage, "ClassificationImage", classificationImageID);
            return classificationImage;
        }

        public static void DeleteClassificationImage(this IQueryable<ClassificationImage> classificationImages, List<int> classificationImageIDList)
        {
            if(classificationImageIDList.Any())
            {
                classificationImages.Where(x => classificationImageIDList.Contains(x.ClassificationImageID)).Delete();
            }
        }

        public static void DeleteClassificationImage(this IQueryable<ClassificationImage> classificationImages, ICollection<ClassificationImage> classificationImagesToDelete)
        {
            if(classificationImagesToDelete.Any())
            {
                var classificationImageIDList = classificationImagesToDelete.Select(x => x.ClassificationImageID).ToList();
                classificationImages.Where(x => classificationImageIDList.Contains(x.ClassificationImageID)).Delete();
            }
        }

        public static void DeleteClassificationImage(this IQueryable<ClassificationImage> classificationImages, int classificationImageID)
        {
            DeleteClassificationImage(classificationImages, new List<int> { classificationImageID });
        }

        public static void DeleteClassificationImage(this IQueryable<ClassificationImage> classificationImages, ClassificationImage classificationImageToDelete)
        {
            DeleteClassificationImage(classificationImages, new List<ClassificationImage> { classificationImageToDelete });
        }
    }
}