//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.FirmaSystemAuthenticationType
using CodeFirstStoreFunctions;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public class FirmaSystemAuthenticationTypePrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<FirmaSystemAuthenticationType>
    {
        public FirmaSystemAuthenticationTypePrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public FirmaSystemAuthenticationTypePrimaryKey(FirmaSystemAuthenticationType firmaSystemAuthenticationType) : base(firmaSystemAuthenticationType){}

        public static implicit operator FirmaSystemAuthenticationTypePrimaryKey(int primaryKeyValue)
        {
            return new FirmaSystemAuthenticationTypePrimaryKey(primaryKeyValue);
        }

        public static implicit operator FirmaSystemAuthenticationTypePrimaryKey(FirmaSystemAuthenticationType firmaSystemAuthenticationType)
        {
            return new FirmaSystemAuthenticationTypePrimaryKey(firmaSystemAuthenticationType);
        }
    }
}