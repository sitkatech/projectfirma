//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ClassificationPerformanceMeasure]
using System.Collections.Generic;
using System.Linq;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static ClassificationPerformanceMeasure GetClassificationPerformanceMeasure(this IQueryable<ClassificationPerformanceMeasure> classificationPerformanceMeasures, int classificationPerformanceMeasureID)
        {
            var classificationPerformanceMeasure = classificationPerformanceMeasures.SingleOrDefault(x => x.ClassificationPerformanceMeasureID == classificationPerformanceMeasureID);
            Check.RequireNotNullThrowNotFound(classificationPerformanceMeasure, "ClassificationPerformanceMeasure", classificationPerformanceMeasureID);
            return classificationPerformanceMeasure;
        }

        public static void DeleteClassificationPerformanceMeasure(this List<int> classificationPerformanceMeasureIDList)
        {
            if(classificationPerformanceMeasureIDList.Any())
            {
                HttpRequestStorage.DatabaseEntities.AllClassificationPerformanceMeasures.RemoveRange(HttpRequestStorage.DatabaseEntities.ClassificationPerformanceMeasures.Where(x => classificationPerformanceMeasureIDList.Contains(x.ClassificationPerformanceMeasureID)));
            }
        }

        public static void DeleteClassificationPerformanceMeasure(this ICollection<ClassificationPerformanceMeasure> classificationPerformanceMeasuresToDelete)
        {
            if(classificationPerformanceMeasuresToDelete.Any())
            {
                HttpRequestStorage.DatabaseEntities.AllClassificationPerformanceMeasures.RemoveRange(classificationPerformanceMeasuresToDelete);
            }
        }

        public static void DeleteClassificationPerformanceMeasure(this int classificationPerformanceMeasureID)
        {
            DeleteClassificationPerformanceMeasure(new List<int> { classificationPerformanceMeasureID });
        }

        public static void DeleteClassificationPerformanceMeasure(this ClassificationPerformanceMeasure classificationPerformanceMeasureToDelete)
        {
            DeleteClassificationPerformanceMeasure(new List<ClassificationPerformanceMeasure> { classificationPerformanceMeasureToDelete });
        }
    }
}