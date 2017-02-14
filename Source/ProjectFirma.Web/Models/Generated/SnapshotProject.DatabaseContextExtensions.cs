//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[SnapshotProject]
using System.Collections.Generic;
using System.Linq;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static SnapshotProject GetSnapshotProject(this IQueryable<SnapshotProject> snapshotProjects, int snapshotProjectID)
        {
            var snapshotProject = snapshotProjects.SingleOrDefault(x => x.SnapshotProjectID == snapshotProjectID);
            Check.RequireNotNullThrowNotFound(snapshotProject, "SnapshotProject", snapshotProjectID);
            return snapshotProject;
        }

        public static void DeleteSnapshotProject(this List<int> snapshotProjectIDList)
        {
            if(snapshotProjectIDList.Any())
            {
                HttpRequestStorage.DatabaseEntities.AllSnapshotProjects.RemoveRange(HttpRequestStorage.DatabaseEntities.SnapshotProjects.Where(x => snapshotProjectIDList.Contains(x.SnapshotProjectID)));
            }
        }

        public static void DeleteSnapshotProject(this ICollection<SnapshotProject> snapshotProjectsToDelete)
        {
            if(snapshotProjectsToDelete.Any())
            {
                HttpRequestStorage.DatabaseEntities.AllSnapshotProjects.RemoveRange(snapshotProjectsToDelete);
            }
        }

        public static void DeleteSnapshotProject(this int snapshotProjectID)
        {
            DeleteSnapshotProject(new List<int> { snapshotProjectID });
        }

        public static void DeleteSnapshotProject(this SnapshotProject snapshotProjectToDelete)
        {
            DeleteSnapshotProject(new List<SnapshotProject> { snapshotProjectToDelete });
        }
    }
}