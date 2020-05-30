//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.ProjectExternalLink
using CodeFirstStoreFunctions;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public class ProjectExternalLinkPrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<ProjectExternalLink>
    {
        public ProjectExternalLinkPrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public ProjectExternalLinkPrimaryKey(ProjectExternalLink projectExternalLink) : base(projectExternalLink){}

        public static implicit operator ProjectExternalLinkPrimaryKey(int primaryKeyValue)
        {
            return new ProjectExternalLinkPrimaryKey(primaryKeyValue);
        }

        public static implicit operator ProjectExternalLinkPrimaryKey(ProjectExternalLink projectExternalLink)
        {
            return new ProjectExternalLinkPrimaryKey(projectExternalLink);
        }
    }
}