//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.CustomPageRole
using CodeFirstStoreFunctions;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public class CustomPageRolePrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<CustomPageRole>
    {
        public CustomPageRolePrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public CustomPageRolePrimaryKey(CustomPageRole customPageRole) : base(customPageRole){}

        public static implicit operator CustomPageRolePrimaryKey(int primaryKeyValue)
        {
            return new CustomPageRolePrimaryKey(primaryKeyValue);
        }

        public static implicit operator CustomPageRolePrimaryKey(CustomPageRole customPageRole)
        {
            return new CustomPageRolePrimaryKey(customPageRole);
        }
    }
}