//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.ProjectGeospatialAreaTypeNote
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public class ProjectGeospatialAreaTypeNotePrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<ProjectGeospatialAreaTypeNote>
    {
        public ProjectGeospatialAreaTypeNotePrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public ProjectGeospatialAreaTypeNotePrimaryKey(ProjectGeospatialAreaTypeNote projectGeospatialAreaTypeNote) : base(projectGeospatialAreaTypeNote){}

        public static implicit operator ProjectGeospatialAreaTypeNotePrimaryKey(int primaryKeyValue)
        {
            return new ProjectGeospatialAreaTypeNotePrimaryKey(primaryKeyValue);
        }

        public static implicit operator ProjectGeospatialAreaTypeNotePrimaryKey(ProjectGeospatialAreaTypeNote projectGeospatialAreaTypeNote)
        {
            return new ProjectGeospatialAreaTypeNotePrimaryKey(projectGeospatialAreaTypeNote);
        }
    }
}