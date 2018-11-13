//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.ProjectInternalNote
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    public class ProjectInternalNotePrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<ProjectInternalNote>
    {
        public ProjectInternalNotePrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public ProjectInternalNotePrimaryKey(ProjectInternalNote projectInternalNote) : base(projectInternalNote){}

        public static implicit operator ProjectInternalNotePrimaryKey(int primaryKeyValue)
        {
            return new ProjectInternalNotePrimaryKey(primaryKeyValue);
        }

        public static implicit operator ProjectInternalNotePrimaryKey(ProjectInternalNote projectInternalNote)
        {
            return new ProjectInternalNotePrimaryKey(projectInternalNote);
        }
    }
}