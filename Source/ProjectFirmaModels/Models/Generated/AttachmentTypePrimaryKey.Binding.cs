//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.AttachmentType
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public class AttachmentTypePrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<AttachmentType>
    {
        public AttachmentTypePrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public AttachmentTypePrimaryKey(AttachmentType attachmentType) : base(attachmentType){}

        public static implicit operator AttachmentTypePrimaryKey(int primaryKeyValue)
        {
            return new AttachmentTypePrimaryKey(primaryKeyValue);
        }

        public static implicit operator AttachmentTypePrimaryKey(AttachmentType attachmentType)
        {
            return new AttachmentTypePrimaryKey(attachmentType);
        }
    }
}