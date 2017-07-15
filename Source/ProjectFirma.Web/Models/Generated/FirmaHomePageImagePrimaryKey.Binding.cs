//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.FirmaHomePageImage
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    public class FirmaHomePageImagePrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<FirmaHomePageImage>
    {
        public FirmaHomePageImagePrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public FirmaHomePageImagePrimaryKey(FirmaHomePageImage firmaHomePageImage) : base(firmaHomePageImage){}

        public static implicit operator FirmaHomePageImagePrimaryKey(int primaryKeyValue)
        {
            return new FirmaHomePageImagePrimaryKey(primaryKeyValue);
        }

        public static implicit operator FirmaHomePageImagePrimaryKey(FirmaHomePageImage firmaHomePageImage)
        {
            return new FirmaHomePageImagePrimaryKey(firmaHomePageImage);
        }
    }
}