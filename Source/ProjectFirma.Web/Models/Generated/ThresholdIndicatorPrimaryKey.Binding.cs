//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.ThresholdIndicator
using ProjectFirma.Web.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Models
{
    public class ThresholdIndicatorPrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<ThresholdIndicator>
    {
        public ThresholdIndicatorPrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public ThresholdIndicatorPrimaryKey(ThresholdIndicator thresholdIndicator) : base(thresholdIndicator){}

        public static implicit operator ThresholdIndicatorPrimaryKey(int primaryKeyValue)
        {
            return new ThresholdIndicatorPrimaryKey(primaryKeyValue);
        }

        public static implicit operator ThresholdIndicatorPrimaryKey(ThresholdIndicator thresholdIndicator)
        {
            return new ThresholdIndicatorPrimaryKey(thresholdIndicator);
        }
    }
}