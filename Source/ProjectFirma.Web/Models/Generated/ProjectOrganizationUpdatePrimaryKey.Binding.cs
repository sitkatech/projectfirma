//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.ProjectOrganizationUpdate
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    public class ProjectOrganizationUpdatePrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<ProjectOrganizationUpdate>
    {
        public ProjectOrganizationUpdatePrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public ProjectOrganizationUpdatePrimaryKey(ProjectOrganizationUpdate projectOrganizationUpdate) : base(projectOrganizationUpdate){}

        public static implicit operator ProjectOrganizationUpdatePrimaryKey(int primaryKeyValue)
        {
            return new ProjectOrganizationUpdatePrimaryKey(primaryKeyValue);
        }

        public static implicit operator ProjectOrganizationUpdatePrimaryKey(ProjectOrganizationUpdate projectOrganizationUpdate)
        {
            return new ProjectOrganizationUpdatePrimaryKey(projectOrganizationUpdate);
        }
    }
}