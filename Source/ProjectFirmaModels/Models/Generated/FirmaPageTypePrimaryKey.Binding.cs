//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.FirmaPageType
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public class FirmaPageTypePrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<FirmaPageType>
    {
        public FirmaPageTypePrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public FirmaPageTypePrimaryKey(FirmaPageType firmaPageType) : base(firmaPageType){}

        public static implicit operator FirmaPageTypePrimaryKey(int primaryKeyValue)
        {
            return new FirmaPageTypePrimaryKey(primaryKeyValue);
        }

        public static implicit operator FirmaPageTypePrimaryKey(FirmaPageType firmaPageType)
        {
            return new FirmaPageTypePrimaryKey(firmaPageType);
        }
    }
}