//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.ProjectGeospatialArea
using CodeFirstStoreFunctions;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public class ProjectGeospatialAreaPrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<ProjectGeospatialArea>
    {
        public ProjectGeospatialAreaPrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public ProjectGeospatialAreaPrimaryKey(ProjectGeospatialArea projectGeospatialArea) : base(projectGeospatialArea){}

        public static implicit operator ProjectGeospatialAreaPrimaryKey(int primaryKeyValue)
        {
            return new ProjectGeospatialAreaPrimaryKey(primaryKeyValue);
        }

        public static implicit operator ProjectGeospatialAreaPrimaryKey(ProjectGeospatialArea projectGeospatialArea)
        {
            return new ProjectGeospatialAreaPrimaryKey(projectGeospatialArea);
        }
    }
}