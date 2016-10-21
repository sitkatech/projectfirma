//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.AccelaCAPRecordStatus
using ProjectFirma.Web.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Models
{
    public class AccelaCAPRecordStatusPrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<AccelaCAPRecordStatus>
    {
        public AccelaCAPRecordStatusPrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public AccelaCAPRecordStatusPrimaryKey(AccelaCAPRecordStatus accelaCAPRecordStatus) : base(accelaCAPRecordStatus){}

        public static implicit operator AccelaCAPRecordStatusPrimaryKey(int primaryKeyValue)
        {
            return new AccelaCAPRecordStatusPrimaryKey(primaryKeyValue);
        }

        public static implicit operator AccelaCAPRecordStatusPrimaryKey(AccelaCAPRecordStatus accelaCAPRecordStatus)
        {
            return new AccelaCAPRecordStatusPrimaryKey(accelaCAPRecordStatus);
        }
    }
}