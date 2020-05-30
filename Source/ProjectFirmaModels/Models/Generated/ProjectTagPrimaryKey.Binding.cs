//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.ProjectTag
using CodeFirstStoreFunctions;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public class ProjectTagPrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<ProjectTag>
    {
        public ProjectTagPrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public ProjectTagPrimaryKey(ProjectTag projectTag) : base(projectTag){}

        public static implicit operator ProjectTagPrimaryKey(int primaryKeyValue)
        {
            return new ProjectTagPrimaryKey(primaryKeyValue);
        }

        public static implicit operator ProjectTagPrimaryKey(ProjectTag projectTag)
        {
            return new ProjectTagPrimaryKey(projectTag);
        }
    }
}