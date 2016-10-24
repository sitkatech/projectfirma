//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.SustainabilityPillar
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    public class SustainabilityPillarPrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<SustainabilityPillar>
    {
        public SustainabilityPillarPrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public SustainabilityPillarPrimaryKey(SustainabilityPillar sustainabilityPillar) : base(sustainabilityPillar){}

        public static implicit operator SustainabilityPillarPrimaryKey(int primaryKeyValue)
        {
            return new SustainabilityPillarPrimaryKey(primaryKeyValue);
        }

        public static implicit operator SustainabilityPillarPrimaryKey(SustainabilityPillar sustainabilityPillar)
        {
            return new SustainabilityPillarPrimaryKey(sustainabilityPillar);
        }
    }
}