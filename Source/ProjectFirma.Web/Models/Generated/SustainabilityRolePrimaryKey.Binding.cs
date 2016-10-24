//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.SustainabilityRole
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    public class SustainabilityRolePrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<SustainabilityRole>
    {
        public SustainabilityRolePrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public SustainabilityRolePrimaryKey(SustainabilityRole sustainabilityRole) : base(sustainabilityRole){}

        public static implicit operator SustainabilityRolePrimaryKey(int primaryKeyValue)
        {
            return new SustainabilityRolePrimaryKey(primaryKeyValue);
        }

        public static implicit operator SustainabilityRolePrimaryKey(SustainabilityRole sustainabilityRole)
        {
            return new SustainabilityRolePrimaryKey(sustainabilityRole);
        }
    }
}