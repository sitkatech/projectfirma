using System.Collections.Generic;
using System.Linq;
using ProjectFirma.Web.Common;
using ProjectFirmaModels;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Models
{
    public static class ProjectRelevantCostTypeUpdateModelExtensions
    {
        public static void CreateExpendituresRelevantCostTypesFromProject(ProjectUpdateBatch projectUpdateBatch)
        {
            var project = projectUpdateBatch.Project;
            foreach (var projectRelevantCostTypeUpdate in project.GetExpendituresRelevantCostTypes()
                .Select(projectRelevantCostType => new ProjectRelevantCostTypeUpdate(projectUpdateBatch,
                    projectRelevantCostType.CostType, projectRelevantCostType.ProjectRelevantCostTypeGroup))
                .ToList())
            {
                projectUpdateBatch.ProjectRelevantCostTypeUpdates.Add(projectRelevantCostTypeUpdate);
            }
        }

        public static void CreateBudgetsRelevantCostTypesFromProject(ProjectUpdateBatch projectUpdateBatch)
        {
            var project = projectUpdateBatch.Project;
            foreach (var projectRelevantCostTypeUpdate in project.GetBudgetsRelevantCostTypes()
                .Select(projectRelevantCostType => new ProjectRelevantCostTypeUpdate(projectUpdateBatch,
                    projectRelevantCostType.CostType, projectRelevantCostType.ProjectRelevantCostTypeGroup))
                .ToList())
            {
                projectUpdateBatch.ProjectRelevantCostTypeUpdates.Add(projectRelevantCostTypeUpdate);
            }
        }

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