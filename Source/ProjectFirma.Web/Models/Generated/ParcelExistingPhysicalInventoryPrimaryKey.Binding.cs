//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.ParcelExistingPhysicalInventory
using ProjectFirma.Web.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Models
{
    public class ParcelExistingPhysicalInventoryPrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<ParcelExistingPhysicalInventory>
    {
        public ParcelExistingPhysicalInventoryPrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public ParcelExistingPhysicalInventoryPrimaryKey(ParcelExistingPhysicalInventory parcelExistingPhysicalInventory) : base(parcelExistingPhysicalInventory){}

        public static implicit operator ParcelExistingPhysicalInventoryPrimaryKey(int primaryKeyValue)
        {
            return new ParcelExistingPhysicalInventoryPrimaryKey(primaryKeyValue);
        }

        public static implicit operator ParcelExistingPhysicalInventoryPrimaryKey(ParcelExistingPhysicalInventory parcelExistingPhysicalInventory)
        {
            return new ParcelExistingPhysicalInventoryPrimaryKey(parcelExistingPhysicalInventory);
        }
    }
}