//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[Classification]
using System.Collections.Generic;
using System.Linq;
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

        public static void DeleteClassification(this List<int> classificationIDList)
        {
            if(classificationIDList.Any())
            {
                HttpRequestStorage.DatabaseEntities.AllClassifications.RemoveRange(HttpRequestStorage.DatabaseEntities.Classifications.Where(x => classificationIDList.Contains(x.ClassificationID)));
            }
        }

        public static void DeleteClassification(this ICollection<Classification> classificationsToDelete)
        {
            if(classificationsToDelete.Any())
            {
                HttpRequestStorage.DatabaseEntities.AllClassifications.RemoveRange(classificationsToDelete);
            }
        }

        public static void DeleteClassification(this int classificationID)
        {
            DeleteClassification(new List<int> { classificationID });
        }

        public static void DeleteClassification(this Classification classificationToDelete)
        {
            DeleteClassification(new List<Classification> { classificationToDelete });
        }
    }
}