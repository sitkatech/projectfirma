//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.ProjectFundingOrganization
using ProjectFirma.Web.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Models
{
    public class ProjectFundingOrganizationPrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<ProjectFundingOrganization>
    {
        public ProjectFundingOrganizationPrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public ProjectFundingOrganizationPrimaryKey(ProjectFundingOrganization projectFundingOrganization) : base(projectFundingOrganization){}

        public static implicit operator ProjectFundingOrganizationPrimaryKey(int primaryKeyValue)
        {
            return new ProjectFundingOrganizationPrimaryKey(primaryKeyValue);
        }

        public static implicit operator ProjectFundingOrganizationPrimaryKey(ProjectFundingOrganization projectFundingOrganization)
        {
            return new ProjectFundingOrganizationPrimaryKey(projectFundingOrganization);
        }
    }
}