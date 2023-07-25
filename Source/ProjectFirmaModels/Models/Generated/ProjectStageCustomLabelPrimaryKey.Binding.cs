//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.ProjectStageCustomLabel
using CodeFirstStoreFunctions;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public class ProjectStageCustomLabelPrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<ProjectStageCustomLabel>
    {
        public ProjectStageCustomLabelPrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public ProjectStageCustomLabelPrimaryKey(ProjectStageCustomLabel projectStageCustomLabel) : base(projectStageCustomLabel){}

        public static implicit operator ProjectStageCustomLabelPrimaryKey(int primaryKeyValue)
        {
            return new ProjectStageCustomLabelPrimaryKey(primaryKeyValue);
        }

        public static implicit operator ProjectStageCustomLabelPrimaryKey(ProjectStageCustomLabel projectStageCustomLabel)
        {
            return new ProjectStageCustomLabelPrimaryKey(projectStageCustomLabel);
        }
    }
}