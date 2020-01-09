//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.AttachmentRelationshipType
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public class AttachmentRelationshipTypePrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<AttachmentRelationshipType>
    {
        public AttachmentRelationshipTypePrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public AttachmentRelationshipTypePrimaryKey(AttachmentRelationshipType attachmentRelationshipType) : base(attachmentRelationshipType){}

        public static implicit operator AttachmentRelationshipTypePrimaryKey(int primaryKeyValue)
        {
            return new AttachmentRelationshipTypePrimaryKey(primaryKeyValue);
        }

        public static implicit operator AttachmentRelationshipTypePrimaryKey(AttachmentRelationshipType attachmentRelationshipType)
        {
            return new AttachmentRelationshipTypePrimaryKey(attachmentRelationshipType);
        }
    }
}