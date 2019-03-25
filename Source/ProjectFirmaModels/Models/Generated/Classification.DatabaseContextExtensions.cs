//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[Classification]
using System.Collections.Generic;
using System.Linq;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static Classification GetClassification(this IQueryable<Classification> classifications, int classificationID)
        {
            var classification = classifications.SingleOrDefault(x => x.ClassificationID == classificationID);
            Check.RequireNotNullThrowNotFound(classification, "Classification", classificationID);
            return classification;
        }

    }
}