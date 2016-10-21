//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.ProjectImplementingOrganization
using ProjectFirma.Web.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Models
{
    public class ProjectImplementingOrganizationPrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<ProjectImplementingOrganization>
    {
        public ProjectImplementingOrganizationPrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public ProjectImplementingOrganizationPrimaryKey(ProjectImplementingOrganization projectImplementingOrganization) : base(projectImplementingOrganization){}

        public static implicit operator ProjectImplementingOrganizationPrimaryKey(int primaryKeyValue)
        {
            return new ProjectImplementingOrganizationPrimaryKey(primaryKeyValue);
        }

        public static implicit operator ProjectImplementingOrganizationPrimaryKey(ProjectImplementingOrganization projectImplementingOrganization)
        {
            return new ProjectImplementingOrganizationPrimaryKey(projectImplementingOrganization);
        }
    }
}