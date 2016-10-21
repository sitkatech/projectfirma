//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.ParcelAccelaCAPRecord
using ProjectFirma.Web.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Models
{
    public class ParcelAccelaCAPRecordPrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<ParcelAccelaCAPRecord>
    {
        public ParcelAccelaCAPRecordPrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public ParcelAccelaCAPRecordPrimaryKey(ParcelAccelaCAPRecord parcelAccelaCAPRecord) : base(parcelAccelaCAPRecord){}

        public static implicit operator ParcelAccelaCAPRecordPrimaryKey(int primaryKeyValue)
        {
            return new ParcelAccelaCAPRecordPrimaryKey(primaryKeyValue);
        }

        public static implicit operator ParcelAccelaCAPRecordPrimaryKey(ParcelAccelaCAPRecord parcelAccelaCAPRecord)
        {
            return new ParcelAccelaCAPRecordPrimaryKey(parcelAccelaCAPRecord);
        }
    }
}