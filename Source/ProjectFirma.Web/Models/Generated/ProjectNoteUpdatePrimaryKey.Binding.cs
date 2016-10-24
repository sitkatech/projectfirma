//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.ProjectNoteUpdate
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    public class ProjectNoteUpdatePrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<ProjectNoteUpdate>
    {
        public ProjectNoteUpdatePrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public ProjectNoteUpdatePrimaryKey(ProjectNoteUpdate projectNoteUpdate) : base(projectNoteUpdate){}

        public static implicit operator ProjectNoteUpdatePrimaryKey(int primaryKeyValue)
        {
            return new ProjectNoteUpdatePrimaryKey(primaryKeyValue);
        }

        public static implicit operator ProjectNoteUpdatePrimaryKey(ProjectNoteUpdate projectNoteUpdate)
        {
            return new ProjectNoteUpdatePrimaryKey(projectNoteUpdate);
        }
    }
}