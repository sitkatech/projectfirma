//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.Role
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    public class RolePrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<Role>
    {
        public RolePrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public RolePrimaryKey(Role role) : base(role){}

        public static implicit operator RolePrimaryKey(int primaryKeyValue)
        {
            return new RolePrimaryKey(primaryKeyValue);
        }

        public static implicit operator RolePrimaryKey(Role role)
        {
            return new RolePrimaryKey(role);
        }
    }
}