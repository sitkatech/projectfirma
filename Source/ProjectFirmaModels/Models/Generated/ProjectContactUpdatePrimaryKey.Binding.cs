//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.ProjectContactUpdate
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public class ProjectContactUpdatePrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<ProjectContactUpdate>
    {
        public ProjectContactUpdatePrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public ProjectContactUpdatePrimaryKey(ProjectContactUpdate projectContactUpdate) : base(projectContactUpdate){}

        public static implicit operator ProjectContactUpdatePrimaryKey(int primaryKeyValue)
        {
            return new ProjectContactUpdatePrimaryKey(primaryKeyValue);
        }

        public static implicit operator ProjectContactUpdatePrimaryKey(ProjectContactUpdate projectContactUpdate)
        {
            return new ProjectContactUpdatePrimaryKey(projectContactUpdate);
        }
    }
}