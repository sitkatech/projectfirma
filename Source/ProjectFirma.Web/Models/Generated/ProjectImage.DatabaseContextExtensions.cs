//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProjectImage]
using System.Collections.Generic;
using System.Linq;
using EntityFramework.Extensions;
using ProjectFirma.Web.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

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

        public static void DeleteProjectImage(this IQueryable<ProjectImage> projectImages, List<int> projectImageIDList)
        {
            if(projectImageIDList.Any())
            {
                projectImages.Where(x => projectImageIDList.Contains(x.ProjectImageID)).Delete();
            }
        }

        public static void DeleteProjectImage(this IQueryable<ProjectImage> projectImages, ICollection<ProjectImage> projectImagesToDelete)
        {
            if(projectImagesToDelete.Any())
            {
                var projectImageIDList = projectImagesToDelete.Select(x => x.ProjectImageID).ToList();
                projectImages.Where(x => projectImageIDList.Contains(x.ProjectImageID)).Delete();
            }
        }

        public static void DeleteProjectImage(this IQueryable<ProjectImage> projectImages, int projectImageID)
        {
            DeleteProjectImage(projectImages, new List<int> { projectImageID });
        }

        public static void DeleteProjectImage(this IQueryable<ProjectImage> projectImages, ProjectImage projectImageToDelete)
        {
            DeleteProjectImage(projectImages, new List<ProjectImage> { projectImageToDelete });
        }
    }
}