//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.County
using ProjectFirma.Web.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Models
{
    public class CountyPrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<County>
    {
        public CountyPrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public CountyPrimaryKey(County county) : base(county){}

        public static implicit operator CountyPrimaryKey(int primaryKeyValue)
        {
            return new CountyPrimaryKey(primaryKeyValue);
        }

        public static implicit operator CountyPrimaryKey(County county)
        {
            return new CountyPrimaryKey(county);
        }
    }
}