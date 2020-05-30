//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.FirmaPageImage
using CodeFirstStoreFunctions;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public class FirmaPageImagePrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<FirmaPageImage>
    {
        public FirmaPageImagePrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public FirmaPageImagePrimaryKey(FirmaPageImage firmaPageImage) : base(firmaPageImage){}

        public static implicit operator FirmaPageImagePrimaryKey(int primaryKeyValue)
        {
            return new FirmaPageImagePrimaryKey(primaryKeyValue);
        }

        public static implicit operator FirmaPageImagePrimaryKey(FirmaPageImage firmaPageImage)
        {
            return new FirmaPageImagePrimaryKey(firmaPageImage);
        }
    }
}