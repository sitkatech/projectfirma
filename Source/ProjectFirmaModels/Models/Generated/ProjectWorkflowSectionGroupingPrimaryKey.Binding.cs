//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.ProjectWorkflowSectionGrouping
using CodeFirstStoreFunctions;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public class ProjectWorkflowSectionGroupingPrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<ProjectWorkflowSectionGrouping>
    {
        public ProjectWorkflowSectionGroupingPrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public ProjectWorkflowSectionGroupingPrimaryKey(ProjectWorkflowSectionGrouping projectWorkflowSectionGrouping) : base(projectWorkflowSectionGrouping){}

        public static implicit operator ProjectWorkflowSectionGroupingPrimaryKey(int primaryKeyValue)
        {
            return new ProjectWorkflowSectionGroupingPrimaryKey(primaryKeyValue);
        }

        public static implicit operator ProjectWorkflowSectionGroupingPrimaryKey(ProjectWorkflowSectionGrouping projectWorkflowSectionGrouping)
        {
            return new ProjectWorkflowSectionGroupingPrimaryKey(projectWorkflowSectionGrouping);
        }
    }
}