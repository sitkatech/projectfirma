//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.ProjectNote
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public class ProjectNotePrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<ProjectNote>
    {
        public ProjectNotePrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public ProjectNotePrimaryKey(ProjectNote projectNote) : base(projectNote){}

        public static implicit operator ProjectNotePrimaryKey(int primaryKeyValue)
        {
            return new ProjectNotePrimaryKey(primaryKeyValue);
        }

        public static implicit operator ProjectNotePrimaryKey(ProjectNote projectNote)
        {
            return new ProjectNotePrimaryKey(projectNote);
        }
    }
}