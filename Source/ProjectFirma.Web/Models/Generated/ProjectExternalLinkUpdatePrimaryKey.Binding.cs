//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.ProjectExternalLinkUpdate
using ProjectFirma.Web.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Models
{
    public class ProjectExternalLinkUpdatePrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<ProjectExternalLinkUpdate>
    {
        public ProjectExternalLinkUpdatePrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public ProjectExternalLinkUpdatePrimaryKey(ProjectExternalLinkUpdate projectExternalLinkUpdate) : base(projectExternalLinkUpdate){}

        public static implicit operator ProjectExternalLinkUpdatePrimaryKey(int primaryKeyValue)
        {
            return new ProjectExternalLinkUpdatePrimaryKey(primaryKeyValue);
        }

        public static implicit operator ProjectExternalLinkUpdatePrimaryKey(ProjectExternalLinkUpdate projectExternalLinkUpdate)
        {
            return new ProjectExternalLinkUpdatePrimaryKey(projectExternalLinkUpdate);
        }
    }
}