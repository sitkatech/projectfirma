//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[SnapshotProject]
using System.Collections.Generic;
using System.Linq;
using Z.EntityFramework.Plus;
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

        public static void DeleteSnapshotProject(this IQueryable<SnapshotProject> snapshotProjects, List<int> snapshotProjectIDList)
        {
            if(snapshotProjectIDList.Any())
            {
                snapshotProjects.Where(x => snapshotProjectIDList.Contains(x.SnapshotProjectID)).Delete();
            }
        }

        public static void DeleteSnapshotProject(this IQueryable<SnapshotProject> snapshotProjects, ICollection<SnapshotProject> snapshotProjectsToDelete)
        {
            if(snapshotProjectsToDelete.Any())
            {
                var snapshotProjectIDList = snapshotProjectsToDelete.Select(x => x.SnapshotProjectID).ToList();
                snapshotProjects.Where(x => snapshotProjectIDList.Contains(x.SnapshotProjectID)).Delete();
            }
        }

        public static void DeleteSnapshotProject(this IQueryable<SnapshotProject> snapshotProjects, int snapshotProjectID)
        {
            DeleteSnapshotProject(snapshotProjects, new List<int> { snapshotProjectID });
        }

        public static void DeleteSnapshotProject(this IQueryable<SnapshotProject> snapshotProjects, SnapshotProject snapshotProjectToDelete)
        {
            DeleteSnapshotProject(snapshotProjects, new List<SnapshotProject> { snapshotProjectToDelete });
        }
    }
}