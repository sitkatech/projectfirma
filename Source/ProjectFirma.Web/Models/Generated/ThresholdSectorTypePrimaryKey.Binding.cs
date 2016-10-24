//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.ThresholdSectorType
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    public class ThresholdSectorTypePrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<ThresholdSectorType>
    {
        public ThresholdSectorTypePrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public ThresholdSectorTypePrimaryKey(ThresholdSectorType thresholdSectorType) : base(thresholdSectorType){}

        public static implicit operator ThresholdSectorTypePrimaryKey(int primaryKeyValue)
        {
            return new ThresholdSectorTypePrimaryKey(primaryKeyValue);
        }

        public static implicit operator ThresholdSectorTypePrimaryKey(ThresholdSectorType thresholdSectorType)
        {
            return new ThresholdSectorTypePrimaryKey(thresholdSectorType);
        }
    }
}