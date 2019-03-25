//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.ProjectOrganization
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public class ProjectOrganizationPrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<ProjectOrganization>
    {
        public ProjectOrganizationPrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public ProjectOrganizationPrimaryKey(ProjectOrganization projectOrganization) : base(projectOrganization){}

        public static implicit operator ProjectOrganizationPrimaryKey(int primaryKeyValue)
        {
            return new ProjectOrganizationPrimaryKey(primaryKeyValue);
        }

        public static implicit operator ProjectOrganizationPrimaryKey(ProjectOrganization projectOrganization)
        {
            return new ProjectOrganizationPrimaryKey(projectOrganization);
        }
    }
}