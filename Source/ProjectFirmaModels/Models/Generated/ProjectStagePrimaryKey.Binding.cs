//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.ProjectStage
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public class ProjectStagePrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<ProjectStage>
    {
        public ProjectStagePrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public ProjectStagePrimaryKey(ProjectStage projectStage) : base(projectStage){}

        public static implicit operator ProjectStagePrimaryKey(int primaryKeyValue)
        {
            return new ProjectStagePrimaryKey(primaryKeyValue);
        }

        public static implicit operator ProjectStagePrimaryKey(ProjectStage projectStage)
        {
            return new ProjectStagePrimaryKey(projectStage);
        }
    }
}