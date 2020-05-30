//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ClassificationSystem]
using System.Collections.Generic;
using System.Linq;
using CodeFirstStoreFunctions;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static ClassificationSystem GetClassificationSystem(this IQueryable<ClassificationSystem> classificationSystems, int classificationSystemID)
        {
            var classificationSystem = classificationSystems.SingleOrDefault(x => x.ClassificationSystemID == classificationSystemID);
            Check.RequireNotNullThrowNotFound(classificationSystem, "ClassificationSystem", classificationSystemID);
            return classificationSystem;
        }

    }
}