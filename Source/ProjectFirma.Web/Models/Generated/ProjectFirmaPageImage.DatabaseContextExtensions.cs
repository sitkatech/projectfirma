//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProjectFirmaPageImage]
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
        public static ProjectFirmaPageImage GetProjectFirmaPageImage(this IQueryable<ProjectFirmaPageImage> projectFirmaPageImages, int projectFirmaPageImageID)
        {
            var projectFirmaPageImage = projectFirmaPageImages.SingleOrDefault(x => x.ProjectFirmaPageImageID == projectFirmaPageImageID);
            Check.RequireNotNullThrowNotFound(projectFirmaPageImage, "ProjectFirmaPageImage", projectFirmaPageImageID);
            return projectFirmaPageImage;
        }

        public static void DeleteProjectFirmaPageImage(this IQueryable<ProjectFirmaPageImage> projectFirmaPageImages, List<int> projectFirmaPageImageIDList)
        {
            if(projectFirmaPageImageIDList.Any())
            {
                projectFirmaPageImages.Where(x => projectFirmaPageImageIDList.Contains(x.ProjectFirmaPageImageID)).Delete();
            }
        }

        public static void DeleteProjectFirmaPageImage(this IQueryable<ProjectFirmaPageImage> projectFirmaPageImages, ICollection<ProjectFirmaPageImage> projectFirmaPageImagesToDelete)
        {
            if(projectFirmaPageImagesToDelete.Any())
            {
                var projectFirmaPageImageIDList = projectFirmaPageImagesToDelete.Select(x => x.ProjectFirmaPageImageID).ToList();
                projectFirmaPageImages.Where(x => projectFirmaPageImageIDList.Contains(x.ProjectFirmaPageImageID)).Delete();
            }
        }

        public static void DeleteProjectFirmaPageImage(this IQueryable<ProjectFirmaPageImage> projectFirmaPageImages, int projectFirmaPageImageID)
        {
            DeleteProjectFirmaPageImage(projectFirmaPageImages, new List<int> { projectFirmaPageImageID });
        }

        public static void DeleteProjectFirmaPageImage(this IQueryable<ProjectFirmaPageImage> projectFirmaPageImages, ProjectFirmaPageImage projectFirmaPageImageToDelete)
        {
            DeleteProjectFirmaPageImage(projectFirmaPageImages, new List<ProjectFirmaPageImage> { projectFirmaPageImageToDelete });
        }
    }
}