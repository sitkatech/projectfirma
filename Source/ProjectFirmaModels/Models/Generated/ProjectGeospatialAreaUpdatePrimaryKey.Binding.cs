//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.ProjectGeospatialAreaUpdate
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public class ProjectGeospatialAreaUpdatePrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<ProjectGeospatialAreaUpdate>
    {
        public ProjectGeospatialAreaUpdatePrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public ProjectGeospatialAreaUpdatePrimaryKey(ProjectGeospatialAreaUpdate projectGeospatialAreaUpdate) : base(projectGeospatialAreaUpdate){}

        public static implicit operator ProjectGeospatialAreaUpdatePrimaryKey(int primaryKeyValue)
        {
            return new ProjectGeospatialAreaUpdatePrimaryKey(primaryKeyValue);
        }

        public static implicit operator ProjectGeospatialAreaUpdatePrimaryKey(ProjectGeospatialAreaUpdate projectGeospatialAreaUpdate)
        {
            return new ProjectGeospatialAreaUpdatePrimaryKey(projectGeospatialAreaUpdate);
        }
    }
}