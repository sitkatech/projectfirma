//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.AttachmentTypeFileResourceMimeType
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public class AttachmentTypeFileResourceMimeTypePrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<AttachmentTypeFileResourceMimeType>
    {
        public AttachmentTypeFileResourceMimeTypePrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public AttachmentTypeFileResourceMimeTypePrimaryKey(AttachmentTypeFileResourceMimeType attachmentTypeFileResourceMimeType) : base(attachmentTypeFileResourceMimeType){}

        public static implicit operator AttachmentTypeFileResourceMimeTypePrimaryKey(int primaryKeyValue)
        {
            return new AttachmentTypeFileResourceMimeTypePrimaryKey(primaryKeyValue);
        }

        public static implicit operator AttachmentTypeFileResourceMimeTypePrimaryKey(AttachmentTypeFileResourceMimeType attachmentTypeFileResourceMimeType)
        {
            return new AttachmentTypeFileResourceMimeTypePrimaryKey(attachmentTypeFileResourceMimeType);
        }
    }
}