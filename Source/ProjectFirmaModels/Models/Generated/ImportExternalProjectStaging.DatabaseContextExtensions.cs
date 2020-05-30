//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ImportExternalProjectStaging]
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
        public static ImportExternalProjectStaging GetImportExternalProjectStaging(this IQueryable<ImportExternalProjectStaging> importExternalProjectStagings, int importExternalProjectStagingID)
        {
            var importExternalProjectStaging = importExternalProjectStagings.SingleOrDefault(x => x.ImportExternalProjectStagingID == importExternalProjectStagingID);
            Check.RequireNotNullThrowNotFound(importExternalProjectStaging, "ImportExternalProjectStaging", importExternalProjectStagingID);
            return importExternalProjectStaging;
        }

    }
}