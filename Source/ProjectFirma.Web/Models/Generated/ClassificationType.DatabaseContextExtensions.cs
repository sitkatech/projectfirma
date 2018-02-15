//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ClassificationType]
using System.Collections.Generic;
using System.Linq;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static ClassificationType GetClassificationType(this IQueryable<ClassificationType> classificationTypes, int classificationTypeID)
        {
            var classificationType = classificationTypes.SingleOrDefault(x => x.ClassificationTypeID == classificationTypeID);
            Check.RequireNotNullThrowNotFound(classificationType, "ClassificationType", classificationTypeID);
            return classificationType;
        }

        public static void DeleteClassificationType(this List<int> classificationTypeIDList)
        {
            if(classificationTypeIDList.Any())
            {
                HttpRequestStorage.DatabaseEntities.AllClassificationTypes.RemoveRange(HttpRequestStorage.DatabaseEntities.ClassificationTypes.Where(x => classificationTypeIDList.Contains(x.ClassificationTypeID)));
            }
        }

        public static void DeleteClassificationType(this ICollection<ClassificationType> classificationTypesToDelete)
        {
            if(classificationTypesToDelete.Any())
            {
                HttpRequestStorage.DatabaseEntities.AllClassificationTypes.RemoveRange(classificationTypesToDelete);
            }
        }

        public static void DeleteClassificationType(this int classificationTypeID)
        {
            DeleteClassificationType(new List<int> { classificationTypeID });
        }

        public static void DeleteClassificationType(this ClassificationType classificationTypeToDelete)
        {
            DeleteClassificationType(new List<ClassificationType> { classificationTypeToDelete });
        }
    }
}