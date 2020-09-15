//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.OrganizationMatchmakerKeyword
using CodeFirstStoreFunctions;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public class OrganizationMatchmakerKeywordPrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<OrganizationMatchmakerKeyword>
    {
        public OrganizationMatchmakerKeywordPrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public OrganizationMatchmakerKeywordPrimaryKey(OrganizationMatchmakerKeyword organizationMatchmakerKeyword) : base(organizationMatchmakerKeyword){}

        public static implicit operator OrganizationMatchmakerKeywordPrimaryKey(int primaryKeyValue)
        {
            return new OrganizationMatchmakerKeywordPrimaryKey(primaryKeyValue);
        }

        public static implicit operator OrganizationMatchmakerKeywordPrimaryKey(OrganizationMatchmakerKeyword organizationMatchmakerKeyword)
        {
            return new OrganizationMatchmakerKeywordPrimaryKey(organizationMatchmakerKeyword);
        }
    }
}