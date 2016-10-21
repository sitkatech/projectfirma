//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.ThresholdIndicatorImage
using ProjectFirma.Web.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Models
{
    public class ThresholdIndicatorImagePrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<ThresholdIndicatorImage>
    {
        public ThresholdIndicatorImagePrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public ThresholdIndicatorImagePrimaryKey(ThresholdIndicatorImage thresholdIndicatorImage) : base(thresholdIndicatorImage){}

        public static implicit operator ThresholdIndicatorImagePrimaryKey(int primaryKeyValue)
        {
            return new ThresholdIndicatorImagePrimaryKey(primaryKeyValue);
        }

        public static implicit operator ThresholdIndicatorImagePrimaryKey(ThresholdIndicatorImage thresholdIndicatorImage)
        {
            return new ThresholdIndicatorImagePrimaryKey(thresholdIndicatorImage);
        }
    }
}