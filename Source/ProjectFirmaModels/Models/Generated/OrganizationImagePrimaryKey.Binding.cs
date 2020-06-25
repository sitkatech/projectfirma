//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.OrganizationImage
using CodeFirstStoreFunctions;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public class OrganizationImagePrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<OrganizationImage>
    {
        public OrganizationImagePrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public OrganizationImagePrimaryKey(OrganizationImage organizationImage) : base(organizationImage){}

        public static implicit operator OrganizationImagePrimaryKey(int primaryKeyValue)
        {
            return new OrganizationImagePrimaryKey(primaryKeyValue);
        }

        public static implicit operator OrganizationImagePrimaryKey(OrganizationImage organizationImage)
        {
            return new OrganizationImagePrimaryKey(organizationImage);
        }
    }
}