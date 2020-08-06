//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.FirmaMenuItem
using CodeFirstStoreFunctions;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public class FirmaMenuItemPrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<FirmaMenuItem>
    {
        public FirmaMenuItemPrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public FirmaMenuItemPrimaryKey(FirmaMenuItem firmaMenuItem) : base(firmaMenuItem){}

        public static implicit operator FirmaMenuItemPrimaryKey(int primaryKeyValue)
        {
            return new FirmaMenuItemPrimaryKey(primaryKeyValue);
        }

        public static implicit operator FirmaMenuItemPrimaryKey(FirmaMenuItem firmaMenuItem)
        {
            return new FirmaMenuItemPrimaryKey(firmaMenuItem);
        }
    }
}