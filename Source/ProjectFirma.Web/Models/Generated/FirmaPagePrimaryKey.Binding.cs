//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.FirmaPage
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    public class FirmaPagePrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<FirmaPage>
    {
        public FirmaPagePrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public FirmaPagePrimaryKey(FirmaPage firmaPage) : base(firmaPage){}

        public static implicit operator FirmaPagePrimaryKey(int primaryKeyValue)
        {
            return new FirmaPagePrimaryKey(primaryKeyValue);
        }

        public static implicit operator FirmaPagePrimaryKey(FirmaPage firmaPage)
        {
            return new FirmaPagePrimaryKey(firmaPage);
        }
    }
}