//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProjectImage]
using System.Collections.Generic;
using System.Linq;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static ProjectImage GetProjectImage(this IQueryable<ProjectImage> projectImages, int projectImageID)
        {
            var projectImage = projectImages.SingleOrDefault(x => x.ProjectImageID == projectImageID);
            Check.RequireNotNullThrowNotFound(projectImage, "ProjectImage", projectImageID);
            return projectImage;
        }

        public static void DeleteProjectImage(this List<int> projectImageIDList)
        {
            if(projectImageIDList.Any())
            {
                HttpRequestStorage.DatabaseEntities.AllProjectImages.RemoveRange(HttpRequestStorage.DatabaseEntities.ProjectImages.Where(x => projectImageIDList.Contains(x.ProjectImageID)));
            }
        }

        public static void DeleteProjectImage(this ICollection<ProjectImage> projectImagesToDelete)
        {
            if(projectImagesToDelete.Any())
            {
                HttpRequestStorage.DatabaseEntities.AllProjectImages.RemoveRange(projectImagesToDelete);
            }
        }

        public static void DeleteProjectImage(this int projectImageID)
        {
            DeleteProjectImage(new List<int> { projectImageID });
        }

        public static void DeleteProjectImage(this ProjectImage projectImageToDelete)
        {
            DeleteProjectImage(new List<ProjectImage> { projectImageToDelete });
        }
    }
}