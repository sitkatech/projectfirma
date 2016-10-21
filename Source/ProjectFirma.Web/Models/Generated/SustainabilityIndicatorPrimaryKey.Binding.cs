//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.SustainabilityIndicator
using ProjectFirma.Web.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Models
{
    public class SustainabilityIndicatorPrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<SustainabilityIndicator>
    {
        public SustainabilityIndicatorPrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public SustainabilityIndicatorPrimaryKey(SustainabilityIndicator sustainabilityIndicator) : base(sustainabilityIndicator){}

        public static implicit operator SustainabilityIndicatorPrimaryKey(int primaryKeyValue)
        {
            return new SustainabilityIndicatorPrimaryKey(primaryKeyValue);
        }

        public static implicit operator SustainabilityIndicatorPrimaryKey(SustainabilityIndicator sustainabilityIndicator)
        {
            return new SustainabilityIndicatorPrimaryKey(sustainabilityIndicator);
        }
    }
}