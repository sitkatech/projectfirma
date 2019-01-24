//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.ProjectGeospatialAreaTypeNoteUpdate
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public class ProjectGeospatialAreaTypeNoteUpdatePrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<ProjectGeospatialAreaTypeNoteUpdate>
    {
        public ProjectGeospatialAreaTypeNoteUpdatePrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public ProjectGeospatialAreaTypeNoteUpdatePrimaryKey(ProjectGeospatialAreaTypeNoteUpdate projectGeospatialAreaTypeNoteUpdate) : base(projectGeospatialAreaTypeNoteUpdate){}

        public static implicit operator ProjectGeospatialAreaTypeNoteUpdatePrimaryKey(int primaryKeyValue)
        {
            return new ProjectGeospatialAreaTypeNoteUpdatePrimaryKey(primaryKeyValue);
        }

        public static implicit operator ProjectGeospatialAreaTypeNoteUpdatePrimaryKey(ProjectGeospatialAreaTypeNoteUpdate projectGeospatialAreaTypeNoteUpdate)
        {
            return new ProjectGeospatialAreaTypeNoteUpdatePrimaryKey(projectGeospatialAreaTypeNoteUpdate);
        }
    }
}