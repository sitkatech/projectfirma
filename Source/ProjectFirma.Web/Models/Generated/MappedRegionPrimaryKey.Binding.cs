//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.MappedRegion
using ProjectFirma.Web.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Models
{
    public class MappedRegionPrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<MappedRegion>
    {
        public MappedRegionPrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public MappedRegionPrimaryKey(MappedRegion mappedRegion) : base(mappedRegion){}

        public static implicit operator MappedRegionPrimaryKey(int primaryKeyValue)
        {
            return new MappedRegionPrimaryKey(primaryKeyValue);
        }

        public static implicit operator MappedRegionPrimaryKey(MappedRegion mappedRegion)
        {
            return new MappedRegionPrimaryKey(mappedRegion);
        }
    }
}