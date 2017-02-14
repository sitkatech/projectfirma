//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[FileResource]
using System.Collections.Generic;
using System.Linq;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static FileResource GetFileResource(this IQueryable<FileResource> fileResources, int fileResourceID)
        {
            var fileResource = fileResources.SingleOrDefault(x => x.FileResourceID == fileResourceID);
            Check.RequireNotNullThrowNotFound(fileResource, "FileResource", fileResourceID);
            return fileResource;
        }

        public static void DeleteFileResource(this List<int> fileResourceIDList)
        {
            if(fileResourceIDList.Any())
            {
                HttpRequestStorage.DatabaseEntities.AllFileResources.RemoveRange(HttpRequestStorage.DatabaseEntities.FileResources.Where(x => fileResourceIDList.Contains(x.FileResourceID)));
            }
        }

        public static void DeleteFileResource(this ICollection<FileResource> fileResourcesToDelete)
        {
            if(fileResourcesToDelete.Any())
            {
                HttpRequestStorage.DatabaseEntities.AllFileResources.RemoveRange(fileResourcesToDelete);
            }
        }

        public static void DeleteFileResource(this int fileResourceID)
        {
            DeleteFileResource(new List<int> { fileResourceID });
        }

        public static void DeleteFileResource(this FileResource fileResourceToDelete)
        {
            DeleteFileResource(new List<FileResource> { fileResourceToDelete });
        }
    }
}