//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[FileResource]
using System.Collections.Generic;
using System.Linq;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static FileResource GetFileResource(this IQueryable<FileResource> fileResources, int fileResourceID)
        {
            var fileResource = fileResources.SingleOrDefault(x => x.FileResourceID == fileResourceID);
            Check.RequireNotNullThrowNotFound(fileResource, "FileResource", fileResourceID);
            return fileResource;
        }

    }
}