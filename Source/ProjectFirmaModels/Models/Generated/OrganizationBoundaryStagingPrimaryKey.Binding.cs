//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.OrganizationBoundaryStaging
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public class OrganizationBoundaryStagingPrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<OrganizationBoundaryStaging>
    {
        public OrganizationBoundaryStagingPrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public OrganizationBoundaryStagingPrimaryKey(OrganizationBoundaryStaging organizationBoundaryStaging) : base(organizationBoundaryStaging){}

        public static implicit operator OrganizationBoundaryStagingPrimaryKey(int primaryKeyValue)
        {
            return new OrganizationBoundaryStagingPrimaryKey(primaryKeyValue);
        }

        public static implicit operator OrganizationBoundaryStagingPrimaryKey(OrganizationBoundaryStaging organizationBoundaryStaging)
        {
            return new OrganizationBoundaryStagingPrimaryKey(organizationBoundaryStaging);
        }
    }
}