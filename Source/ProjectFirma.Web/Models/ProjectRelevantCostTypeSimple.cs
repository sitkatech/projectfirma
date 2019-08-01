using LtInfo.Common.Models;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Models
{
    public class ProjectRelevantCostTypeSimple
    {
        /// <summary>
        /// Needed by ModelBinder
        /// </summary>
        public ProjectRelevantCostTypeSimple()
        {
        }

        public ProjectRelevantCostTypeSimple(int projectRelevantCostTypeID, int projectID, int costTypeID, string costTypeName)
            : this()
        {
            ProjectRelevantCostTypeID = projectRelevantCostTypeID;
            ProjectID = projectID;
            CostTypeID = costTypeID;
            CostTypeName = costTypeName;
            IsRelevant = false;
        }

        public ProjectRelevantCostTypeSimple(ProjectRelevantCostType projectRelevantCostType)
            : this()
        {
            ProjectRelevantCostTypeID = projectRelevantCostType.ProjectRelevantCostTypeID;
            ProjectID = projectRelevantCostType.ProjectID;
            CostTypeID = projectRelevantCostType.CostTypeID;
            IsRelevant = ModelObjectHelpers.IsRealPrimaryKeyValue(projectRelevantCostType.ProjectRelevantCostTypeID);
            CostTypeName = projectRelevantCostType.CostType.CostTypeName;
        }

        public ProjectRelevantCostTypeSimple(ProjectRelevantCostTypeUpdate projectRelevantCostTypeUpdate)
            : this()
        {
            ProjectRelevantCostTypeID = projectRelevantCostTypeUpdate.ProjectRelevantCostTypeUpdateID;
            ProjectID = projectRelevantCostTypeUpdate.ProjectUpdateBatchID;
            CostTypeID = projectRelevantCostTypeUpdate.CostTypeID;
            IsRelevant = ModelObjectHelpers.IsRealPrimaryKeyValue(projectRelevantCostTypeUpdate.ProjectRelevantCostTypeUpdateID);
            CostTypeName = projectRelevantCostTypeUpdate.CostType.CostTypeName;
        }

        public int ProjectRelevantCostTypeID { get; set; }
        public int ProjectID { get; set; }
        public int CostTypeID { get; set; }
        public bool IsRelevant { get; set; }
        public string CostTypeName { get; set; }
    }
}