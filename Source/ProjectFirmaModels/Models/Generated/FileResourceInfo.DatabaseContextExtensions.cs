//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[FileResourceInfo]
using System.Collections.Generic;
using System.Linq;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static FileResourceInfo GetFileResourceInfo(this IQueryable<FileResourceInfo> fileResourceInfos, int fileResourceInfoID)
        {
            var fileResourceInfo = fileResourceInfos.SingleOrDefault(x => x.FileResourceInfoID == fileResourceInfoID);
            Check.RequireNotNullThrowNotFound(fileResourceInfo, "FileResourceInfo", fileResourceInfoID);
            return fileResourceInfo;
        }

    }
}