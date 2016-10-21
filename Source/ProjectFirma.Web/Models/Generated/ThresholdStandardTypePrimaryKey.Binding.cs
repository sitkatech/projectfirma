//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.ThresholdStandardType
using ProjectFirma.Web.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Models
{
    public class ThresholdStandardTypePrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<ThresholdStandardType>
    {
        public ThresholdStandardTypePrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public ThresholdStandardTypePrimaryKey(ThresholdStandardType thresholdStandardType) : base(thresholdStandardType){}

        public static implicit operator ThresholdStandardTypePrimaryKey(int primaryKeyValue)
        {
            return new ThresholdStandardTypePrimaryKey(primaryKeyValue);
        }

        public static implicit operator ThresholdStandardTypePrimaryKey(ThresholdStandardType thresholdStandardType)
        {
            return new ThresholdStandardTypePrimaryKey(thresholdStandardType);
        }
    }
}