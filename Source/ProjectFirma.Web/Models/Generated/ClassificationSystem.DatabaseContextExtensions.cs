//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ClassificationSystem]
using System.Collections.Generic;
using System.Linq;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static ClassificationSystem GetClassificationSystem(this IQueryable<ClassificationSystem> classificationSystems, int classificationSystemID)
        {
            var classificationSystem = classificationSystems.SingleOrDefault(x => x.ClassificationSystemID == classificationSystemID);
            Check.RequireNotNullThrowNotFound(classificationSystem, "ClassificationSystem", classificationSystemID);
            return classificationSystem;
        }

        public static void DeleteClassificationSystem(this List<int> classificationSystemIDList)
        {
            if(classificationSystemIDList.Any())
            {
                HttpRequestStorage.DatabaseEntities.AllClassificationSystems.RemoveRange(HttpRequestStorage.DatabaseEntities.ClassificationSystems.Where(x => classificationSystemIDList.Contains(x.ClassificationSystemID)));
            }
        }

        public static void DeleteClassificationSystem(this ICollection<ClassificationSystem> classificationSystemsToDelete)
        {
            if(classificationSystemsToDelete.Any())
            {
                HttpRequestStorage.DatabaseEntities.AllClassificationSystems.RemoveRange(classificationSystemsToDelete);
            }
        }

        public static void DeleteClassificationSystem(this int classificationSystemID)
        {
            DeleteClassificationSystem(new List<int> { classificationSystemID });
        }

        public static void DeleteClassificationSystem(this ClassificationSystem classificationSystemToDelete)
        {
            DeleteClassificationSystem(new List<ClassificationSystem> { classificationSystemToDelete });
        }
    }
}