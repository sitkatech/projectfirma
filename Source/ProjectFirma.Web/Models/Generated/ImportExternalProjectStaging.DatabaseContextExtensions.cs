//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ImportExternalProjectStaging]
using System.Collections.Generic;
using System.Linq;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static ImportExternalProjectStaging GetImportExternalProjectStaging(this IQueryable<ImportExternalProjectStaging> importExternalProjectStagings, int importExternalProjectStagingID)
        {
            var importExternalProjectStaging = importExternalProjectStagings.SingleOrDefault(x => x.ImportExternalProjectStagingID == importExternalProjectStagingID);
            Check.RequireNotNullThrowNotFound(importExternalProjectStaging, "ImportExternalProjectStaging", importExternalProjectStagingID);
            return importExternalProjectStaging;
        }

        public static void DeleteImportExternalProjectStaging(this List<int> importExternalProjectStagingIDList)
        {
            if(importExternalProjectStagingIDList.Any())
            {
                HttpRequestStorage.DatabaseEntities.AllImportExternalProjectStagings.RemoveRange(HttpRequestStorage.DatabaseEntities.ImportExternalProjectStagings.Where(x => importExternalProjectStagingIDList.Contains(x.ImportExternalProjectStagingID)));
            }
        }

        public static void DeleteImportExternalProjectStaging(this ICollection<ImportExternalProjectStaging> importExternalProjectStagingsToDelete)
        {
            if(importExternalProjectStagingsToDelete.Any())
            {
                HttpRequestStorage.DatabaseEntities.AllImportExternalProjectStagings.RemoveRange(importExternalProjectStagingsToDelete);
            }
        }

        public static void DeleteImportExternalProjectStaging(this int importExternalProjectStagingID)
        {
            DeleteImportExternalProjectStaging(new List<int> { importExternalProjectStagingID });
        }

        public static void DeleteImportExternalProjectStaging(this ImportExternalProjectStaging importExternalProjectStagingToDelete)
        {
            DeleteImportExternalProjectStaging(new List<ImportExternalProjectStaging> { importExternalProjectStagingToDelete });
        }
    }
}