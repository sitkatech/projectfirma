//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.LTInfoArea
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    public class LTInfoAreaPrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<LTInfoArea>
    {
        public LTInfoAreaPrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public LTInfoAreaPrimaryKey(LTInfoArea lTInfoArea) : base(lTInfoArea){}

        public static implicit operator LTInfoAreaPrimaryKey(int primaryKeyValue)
        {
            return new LTInfoAreaPrimaryKey(primaryKeyValue);
        }

        public static implicit operator LTInfoAreaPrimaryKey(LTInfoArea lTInfoArea)
        {
            return new LTInfoAreaPrimaryKey(lTInfoArea);
        }
    }
}