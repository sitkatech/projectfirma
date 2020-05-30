//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[FileResourceData]
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
        public static FileResourceData GetFileResourceData(this IQueryable<FileResourceData> fileResourceDatas, int fileResourceDataID)
        {
            var fileResourceData = fileResourceDatas.SingleOrDefault(x => x.FileResourceDataID == fileResourceDataID);
            Check.RequireNotNullThrowNotFound(fileResourceData, "FileResourceData", fileResourceDataID);
            return fileResourceData;
        }

    }
}