//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ClassificationPerformanceMeasure]
using System.Collections.Generic;
using System.Linq;
using EntityFramework.Extensions;
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

        public static void DeleteClassificationPerformanceMeasure(this IQueryable<ClassificationPerformanceMeasure> classificationPerformanceMeasures, List<int> classificationPerformanceMeasureIDList)
        {
            if(classificationPerformanceMeasureIDList.Any())
            {
                classificationPerformanceMeasures.Where(x => classificationPerformanceMeasureIDList.Contains(x.ClassificationPerformanceMeasureID)).Delete();
            }
        }

        public static void DeleteClassificationPerformanceMeasure(this IQueryable<ClassificationPerformanceMeasure> classificationPerformanceMeasures, ICollection<ClassificationPerformanceMeasure> classificationPerformanceMeasuresToDelete)
        {
            if(classificationPerformanceMeasuresToDelete.Any())
            {
                var classificationPerformanceMeasureIDList = classificationPerformanceMeasuresToDelete.Select(x => x.ClassificationPerformanceMeasureID).ToList();
                classificationPerformanceMeasures.Where(x => classificationPerformanceMeasureIDList.Contains(x.ClassificationPerformanceMeasureID)).Delete();
            }
        }

        public static void DeleteClassificationPerformanceMeasure(this IQueryable<ClassificationPerformanceMeasure> classificationPerformanceMeasures, int classificationPerformanceMeasureID)
        {
            DeleteClassificationPerformanceMeasure(classificationPerformanceMeasures, new List<int> { classificationPerformanceMeasureID });
        }

        public static void DeleteClassificationPerformanceMeasure(this IQueryable<ClassificationPerformanceMeasure> classificationPerformanceMeasures, ClassificationPerformanceMeasure classificationPerformanceMeasureToDelete)
        {
            DeleteClassificationPerformanceMeasure(classificationPerformanceMeasures, new List<ClassificationPerformanceMeasure> { classificationPerformanceMeasureToDelete });
        }
    }
}