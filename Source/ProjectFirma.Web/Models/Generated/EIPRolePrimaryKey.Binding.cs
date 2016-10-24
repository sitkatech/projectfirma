//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.EIPRole
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    public class EIPRolePrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<EIPRole>
    {
        public EIPRolePrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public EIPRolePrimaryKey(EIPRole eIPRole) : base(eIPRole){}

        public static implicit operator EIPRolePrimaryKey(int primaryKeyValue)
        {
            return new EIPRolePrimaryKey(primaryKeyValue);
        }

        public static implicit operator EIPRolePrimaryKey(EIPRole eIPRole)
        {
            return new EIPRolePrimaryKey(eIPRole);
        }
    }
}