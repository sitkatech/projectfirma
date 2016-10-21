//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.Watershed
using ProjectFirma.Web.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Models
{
    public class WatershedPrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<Watershed>
    {
        public WatershedPrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public WatershedPrimaryKey(Watershed watershed) : base(watershed){}

        public static implicit operator WatershedPrimaryKey(int primaryKeyValue)
        {
            return new WatershedPrimaryKey(primaryKeyValue);
        }

        public static implicit operator WatershedPrimaryKey(Watershed watershed)
        {
            return new WatershedPrimaryKey(watershed);
        }
    }
}