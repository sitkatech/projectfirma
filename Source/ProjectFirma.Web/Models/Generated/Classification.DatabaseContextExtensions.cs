//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[Classification]
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
        public static Classification GetClassification(this IQueryable<Classification> classifications, int classificationID)
        {
            var classification = classifications.SingleOrDefault(x => x.ClassificationID == classificationID);
            Check.RequireNotNullThrowNotFound(classification, "Classification", classificationID);
            return classification;
        }

        public static void DeleteClassification(this IQueryable<Classification> classifications, List<int> classificationIDList)
        {
            if(classificationIDList.Any())
            {
                classifications.Where(x => classificationIDList.Contains(x.ClassificationID)).Delete();
            }
        }

        public static void DeleteClassification(this IQueryable<Classification> classifications, ICollection<Classification> classificationsToDelete)
        {
            if(classificationsToDelete.Any())
            {
                var classificationIDList = classificationsToDelete.Select(x => x.ClassificationID).ToList();
                classifications.Where(x => classificationIDList.Contains(x.ClassificationID)).Delete();
            }
        }

        public static void DeleteClassification(this IQueryable<Classification> classifications, int classificationID)
        {
            DeleteClassification(classifications, new List<int> { classificationID });
        }

        public static void DeleteClassification(this IQueryable<Classification> classifications, Classification classificationToDelete)
        {
            DeleteClassification(classifications, new List<Classification> { classificationToDelete });
        }
    }
}