using System.Collections.Generic;
using System.Linq;
using ProjectFirma.Web.Common;

namespace ProjectFirmaModels.Models
{
    public static class ProjectRelevantCostTypeUpdateModelExtensions
    {

        public static void CommitChangesToProject(ProjectUpdateBatch projectUpdateBatch, IList<ProjectRelevantCostType> projectRelevantCostTypes)
        {
            var project = projectUpdateBatch.Project;
            var projectRelevantCostTypesFromProjectUpdate =
                projectUpdateBatch.ProjectRelevantCostTypeUpdates.Select(x => new ProjectRelevantCostType(project.ProjectID, x.CostTypeID, x.ProjectRelevantCostTypeGroupID)).ToList();
            project.ProjectRelevantCostTypes.Merge(projectRelevantCostTypesFromProjectUpdate,
                projectRelevantCostTypes,
                (x, y) => x.ProjectID == y.ProjectID && x.CostTypeID == y.CostTypeID && x.ProjectRelevantCostTypeGroupID == y.ProjectRelevantCostTypeGroupID, HttpRequestStorage.DatabaseEntities);
        }
    }
}