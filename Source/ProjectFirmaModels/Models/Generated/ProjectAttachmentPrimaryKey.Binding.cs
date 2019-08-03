//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.ProjectAttachment
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public class ProjectAttachmentPrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<ProjectAttachment>
    {
        public ProjectAttachmentPrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public ProjectAttachmentPrimaryKey(ProjectAttachment projectAttachment) : base(projectAttachment){}

        public static implicit operator ProjectAttachmentPrimaryKey(int primaryKeyValue)
        {
            return new ProjectAttachmentPrimaryKey(primaryKeyValue);
        }

        public static implicit operator ProjectAttachmentPrimaryKey(ProjectAttachment projectAttachment)
        {
            return new ProjectAttachmentPrimaryKey(projectAttachment);
        }
    }
}