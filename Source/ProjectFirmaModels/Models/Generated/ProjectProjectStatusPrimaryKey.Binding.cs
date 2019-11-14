//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.ProjectProjectStatus
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public class ProjectProjectStatusPrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<ProjectProjectStatus>
    {
        public ProjectProjectStatusPrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public ProjectProjectStatusPrimaryKey(ProjectProjectStatus projectProjectStatus) : base(projectProjectStatus){}

        public static implicit operator ProjectProjectStatusPrimaryKey(int primaryKeyValue)
        {
            return new ProjectProjectStatusPrimaryKey(primaryKeyValue);
        }

        public static implicit operator ProjectProjectStatusPrimaryKey(ProjectProjectStatus projectProjectStatus)
        {
            return new ProjectProjectStatusPrimaryKey(projectProjectStatus);
        }
    }
}