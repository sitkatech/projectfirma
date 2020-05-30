//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.ProjectUpdateHistory
using CodeFirstStoreFunctions;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public class ProjectUpdateHistoryPrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<ProjectUpdateHistory>
    {
        public ProjectUpdateHistoryPrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public ProjectUpdateHistoryPrimaryKey(ProjectUpdateHistory projectUpdateHistory) : base(projectUpdateHistory){}

        public static implicit operator ProjectUpdateHistoryPrimaryKey(int primaryKeyValue)
        {
            return new ProjectUpdateHistoryPrimaryKey(primaryKeyValue);
        }

        public static implicit operator ProjectUpdateHistoryPrimaryKey(ProjectUpdateHistory projectUpdateHistory)
        {
            return new ProjectUpdateHistoryPrimaryKey(projectUpdateHistory);
        }
    }
}