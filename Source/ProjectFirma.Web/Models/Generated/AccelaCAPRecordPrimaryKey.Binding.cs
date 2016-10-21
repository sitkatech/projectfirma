//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.AccelaCAPRecord
using ProjectFirma.Web.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Models
{
    public class AccelaCAPRecordPrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<AccelaCAPRecord>
    {
        public AccelaCAPRecordPrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public AccelaCAPRecordPrimaryKey(AccelaCAPRecord accelaCAPRecord) : base(accelaCAPRecord){}

        public static implicit operator AccelaCAPRecordPrimaryKey(int primaryKeyValue)
        {
            return new AccelaCAPRecordPrimaryKey(primaryKeyValue);
        }

        public static implicit operator AccelaCAPRecordPrimaryKey(AccelaCAPRecord accelaCAPRecord)
        {
            return new AccelaCAPRecordPrimaryKey(accelaCAPRecord);
        }
    }
}