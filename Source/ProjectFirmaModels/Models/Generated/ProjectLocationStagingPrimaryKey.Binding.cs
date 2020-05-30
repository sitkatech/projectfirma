//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.ProjectLocationStaging
using CodeFirstStoreFunctions;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public class ProjectLocationStagingPrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<ProjectLocationStaging>
    {
        public ProjectLocationStagingPrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public ProjectLocationStagingPrimaryKey(ProjectLocationStaging projectLocationStaging) : base(projectLocationStaging){}

        public static implicit operator ProjectLocationStagingPrimaryKey(int primaryKeyValue)
        {
            return new ProjectLocationStagingPrimaryKey(primaryKeyValue);
        }

        public static implicit operator ProjectLocationStagingPrimaryKey(ProjectLocationStaging projectLocationStaging)
        {
            return new ProjectLocationStagingPrimaryKey(projectLocationStaging);
        }
    }
}