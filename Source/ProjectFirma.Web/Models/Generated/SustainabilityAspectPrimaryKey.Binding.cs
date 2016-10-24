//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.SustainabilityAspect
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    public class SustainabilityAspectPrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<SustainabilityAspect>
    {
        public SustainabilityAspectPrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public SustainabilityAspectPrimaryKey(SustainabilityAspect sustainabilityAspect) : base(sustainabilityAspect){}

        public static implicit operator SustainabilityAspectPrimaryKey(int primaryKeyValue)
        {
            return new SustainabilityAspectPrimaryKey(primaryKeyValue);
        }

        public static implicit operator SustainabilityAspectPrimaryKey(SustainabilityAspect sustainabilityAspect)
        {
            return new SustainabilityAspectPrimaryKey(sustainabilityAspect);
        }
    }
}