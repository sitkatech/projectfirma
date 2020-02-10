using System.Linq;
using ProjectFirmaModels;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Models
{
    public static class ProjectGeospatialAreaUpdateModelExtensions
    {
        public static void CreateFromProject(ProjectUpdateBatch projectUpdateBatch)
        {
            var project = projectUpdateBatch.Project;
            var projectGeospatialAreaUpdates = project.ProjectGeospatialAreas.Select(
                projectGeospatialAreaToClone => new ProjectGeospatialAreaUpdate(projectUpdateBatch, projectGeospatialAreaToClone.GeospatialArea)).ToList();
            projectUpdateBatch.ProjectGeospatialAreaUpdates = projectGeospatialAreaUpdates;
        }

        public static void CommitChangesToProject(ProjectUpdateBatch projectUpdateBatch, DatabaseEntities databaseEntities)
        {
            var project = projectUpdateBatch.Project;
            var projectGeospatialAreasFromProjectUpdate =
                projectUpdateBatch.ProjectGeospatialAreaUpdates.Select(
                    x => new ProjectGeospatialArea(project.ProjectID, x.GeospatialAreaID)).ToList();
            project.ProjectGeospatialAreas.Merge(projectGeospatialAreasFromProjectUpdate, (x, y) => x.ProjectID == y.ProjectID && x.GeospatialAreaID == y.GeospatialAreaID, databaseEntities);
        }
    }
}