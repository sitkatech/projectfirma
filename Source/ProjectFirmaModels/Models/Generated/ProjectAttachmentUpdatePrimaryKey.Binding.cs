//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.ProjectAttachmentUpdate
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public class ProjectAttachmentUpdatePrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<ProjectAttachmentUpdate>
    {
        public ProjectAttachmentUpdatePrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public ProjectAttachmentUpdatePrimaryKey(ProjectAttachmentUpdate projectAttachmentUpdate) : base(projectAttachmentUpdate){}

        public static implicit operator ProjectAttachmentUpdatePrimaryKey(int primaryKeyValue)
        {
            return new ProjectAttachmentUpdatePrimaryKey(primaryKeyValue);
        }

        public static implicit operator ProjectAttachmentUpdatePrimaryKey(ProjectAttachmentUpdate projectAttachmentUpdate)
        {
            return new ProjectAttachmentUpdatePrimaryKey(projectAttachmentUpdate);
        }
    }
}