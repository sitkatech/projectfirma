//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.CustomPage
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    public class CustomPagePrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<CustomPage>
    {
        public CustomPagePrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public CustomPagePrimaryKey(CustomPage customPage) : base(customPage){}

        public static implicit operator CustomPagePrimaryKey(int primaryKeyValue)
        {
            return new CustomPagePrimaryKey(primaryKeyValue);
        }

        public static implicit operator CustomPagePrimaryKey(CustomPage customPage)
        {
            return new CustomPagePrimaryKey(customPage);
        }
    }
}