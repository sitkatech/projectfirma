//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.SupportRequestType
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public class SupportRequestTypePrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<SupportRequestType>
    {
        public SupportRequestTypePrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public SupportRequestTypePrimaryKey(SupportRequestType supportRequestType) : base(supportRequestType){}

        public static implicit operator SupportRequestTypePrimaryKey(int primaryKeyValue)
        {
            return new SupportRequestTypePrimaryKey(primaryKeyValue);
        }

        public static implicit operator SupportRequestTypePrimaryKey(SupportRequestType supportRequestType)
        {
            return new SupportRequestTypePrimaryKey(supportRequestType);
        }
    }
}