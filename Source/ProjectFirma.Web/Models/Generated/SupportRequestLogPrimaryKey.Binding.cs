//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.SupportRequestLog
using ProjectFirma.Web.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Models
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