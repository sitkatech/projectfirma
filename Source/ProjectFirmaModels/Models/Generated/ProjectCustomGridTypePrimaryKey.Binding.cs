//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.ProjectCustomGridType
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public class ProjectCustomGridTypePrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<ProjectCustomGridType>
    {
        public ProjectCustomGridTypePrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public ProjectCustomGridTypePrimaryKey(ProjectCustomGridType projectCustomGridType) : base(projectCustomGridType){}

        public static implicit operator ProjectCustomGridTypePrimaryKey(int primaryKeyValue)
        {
            return new ProjectCustomGridTypePrimaryKey(primaryKeyValue);
        }

        public static implicit operator ProjectCustomGridTypePrimaryKey(ProjectCustomGridType projectCustomGridType)
        {
            return new ProjectCustomGridTypePrimaryKey(projectCustomGridType);
        }
    }
}