//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.FirmaPageRenderType
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public class FirmaPageRenderTypePrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<FirmaPageRenderType>
    {
        public FirmaPageRenderTypePrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public FirmaPageRenderTypePrimaryKey(FirmaPageRenderType firmaPageRenderType) : base(firmaPageRenderType){}

        public static implicit operator FirmaPageRenderTypePrimaryKey(int primaryKeyValue)
        {
            return new FirmaPageRenderTypePrimaryKey(primaryKeyValue);
        }

        public static implicit operator FirmaPageRenderTypePrimaryKey(FirmaPageRenderType firmaPageRenderType)
        {
            return new FirmaPageRenderTypePrimaryKey(firmaPageRenderType);
        }
    }
}