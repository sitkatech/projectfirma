//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.ProjectLocationUpdate
using CodeFirstStoreFunctions;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public class ProjectLocationUpdatePrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<ProjectLocationUpdate>
    {
        public ProjectLocationUpdatePrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public ProjectLocationUpdatePrimaryKey(ProjectLocationUpdate projectLocationUpdate) : base(projectLocationUpdate){}

        public static implicit operator ProjectLocationUpdatePrimaryKey(int primaryKeyValue)
        {
            return new ProjectLocationUpdatePrimaryKey(primaryKeyValue);
        }

        public static implicit operator ProjectLocationUpdatePrimaryKey(ProjectLocationUpdate projectLocationUpdate)
        {
            return new ProjectLocationUpdatePrimaryKey(projectLocationUpdate);
        }
    }
}