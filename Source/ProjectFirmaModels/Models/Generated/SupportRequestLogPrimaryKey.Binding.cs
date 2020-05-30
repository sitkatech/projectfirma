//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.SupportRequestLog
using CodeFirstStoreFunctions;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public class SupportRequestLogPrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<SupportRequestLog>
    {
        public SupportRequestLogPrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public SupportRequestLogPrimaryKey(SupportRequestLog supportRequestLog) : base(supportRequestLog){}

        public static implicit operator SupportRequestLogPrimaryKey(int primaryKeyValue)
        {
            return new SupportRequestLogPrimaryKey(primaryKeyValue);
        }

        public static implicit operator SupportRequestLogPrimaryKey(SupportRequestLog supportRequestLog)
        {
            return new SupportRequestLogPrimaryKey(supportRequestLog);
        }
    }
}