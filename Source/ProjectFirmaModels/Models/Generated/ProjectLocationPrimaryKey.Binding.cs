//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.ProjectLocation
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public class ProjectLocationPrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<ProjectLocation>
    {
        public ProjectLocationPrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public ProjectLocationPrimaryKey(ProjectLocation projectLocation) : base(projectLocation){}

        public static implicit operator ProjectLocationPrimaryKey(int primaryKeyValue)
        {
            return new ProjectLocationPrimaryKey(primaryKeyValue);
        }

        public static implicit operator ProjectLocationPrimaryKey(ProjectLocation projectLocation)
        {
            return new ProjectLocationPrimaryKey(projectLocation);
        }
    }
}