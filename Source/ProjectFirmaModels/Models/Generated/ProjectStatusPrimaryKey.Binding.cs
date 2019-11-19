//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.ProjectStatus
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public class ProjectStatusPrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<ProjectStatus>
    {
        public ProjectStatusPrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public ProjectStatusPrimaryKey(ProjectStatus projectStatus) : base(projectStatus){}

        public static implicit operator ProjectStatusPrimaryKey(int primaryKeyValue)
        {
            return new ProjectStatusPrimaryKey(primaryKeyValue);
        }

        public static implicit operator ProjectStatusPrimaryKey(ProjectStatus projectStatus)
        {
            return new ProjectStatusPrimaryKey(projectStatus);
        }
    }
}