//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.ProjectCustomAttributeGroupProjectCategory
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public class ProjectCustomAttributeGroupProjectCategoryPrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<ProjectCustomAttributeGroupProjectCategory>
    {
        public ProjectCustomAttributeGroupProjectCategoryPrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public ProjectCustomAttributeGroupProjectCategoryPrimaryKey(ProjectCustomAttributeGroupProjectCategory projectCustomAttributeGroupProjectCategory) : base(projectCustomAttributeGroupProjectCategory){}

        public static implicit operator ProjectCustomAttributeGroupProjectCategoryPrimaryKey(int primaryKeyValue)
        {
            return new ProjectCustomAttributeGroupProjectCategoryPrimaryKey(primaryKeyValue);
        }

        public static implicit operator ProjectCustomAttributeGroupProjectCategoryPrimaryKey(ProjectCustomAttributeGroupProjectCategory projectCustomAttributeGroupProjectCategory)
        {
            return new ProjectCustomAttributeGroupProjectCategoryPrimaryKey(projectCustomAttributeGroupProjectCategory);
        }
    }
}