//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.AttachmentRelationshipTypeFileResourceMimeType
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public class AttachmentRelationshipTypeFileResourceMimeTypePrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<AttachmentRelationshipTypeFileResourceMimeType>
    {
        public AttachmentRelationshipTypeFileResourceMimeTypePrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public AttachmentRelationshipTypeFileResourceMimeTypePrimaryKey(AttachmentRelationshipTypeFileResourceMimeType attachmentRelationshipTypeFileResourceMimeType) : base(attachmentRelationshipTypeFileResourceMimeType){}

        public static implicit operator AttachmentRelationshipTypeFileResourceMimeTypePrimaryKey(int primaryKeyValue)
        {
            return new AttachmentRelationshipTypeFileResourceMimeTypePrimaryKey(primaryKeyValue);
        }

        public static implicit operator AttachmentRelationshipTypeFileResourceMimeTypePrimaryKey(AttachmentRelationshipTypeFileResourceMimeType attachmentRelationshipTypeFileResourceMimeType)
        {
            return new AttachmentRelationshipTypeFileResourceMimeTypePrimaryKey(attachmentRelationshipTypeFileResourceMimeType);
        }
    }
}