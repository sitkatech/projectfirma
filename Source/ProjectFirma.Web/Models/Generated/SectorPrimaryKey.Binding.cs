//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.Sector
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    public class SectorPrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<Sector>
    {
        public SectorPrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public SectorPrimaryKey(Sector sector) : base(sector){}

        public static implicit operator SectorPrimaryKey(int primaryKeyValue)
        {
            return new SectorPrimaryKey(primaryKeyValue);
        }

        public static implicit operator SectorPrimaryKey(Sector sector)
        {
            return new SectorPrimaryKey(sector);
        }
    }
}