//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.AttachmentTypeRole
using CodeFirstStoreFunctions;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public class AttachmentTypeRolePrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<AttachmentTypeRole>
    {
        public AttachmentTypeRolePrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public AttachmentTypeRolePrimaryKey(AttachmentTypeRole attachmentTypeRole) : base(attachmentTypeRole){}

        public static implicit operator AttachmentTypeRolePrimaryKey(int primaryKeyValue)
        {
            return new AttachmentTypeRolePrimaryKey(primaryKeyValue);
        }

        public static implicit operator AttachmentTypeRolePrimaryKey(AttachmentTypeRole attachmentTypeRole)
        {
            return new AttachmentTypeRolePrimaryKey(attachmentTypeRole);
        }
    }
}