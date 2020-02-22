//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.ProjectCategory
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public class ProjectCategoryPrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<ProjectCategory>
    {
        public ProjectCategoryPrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public ProjectCategoryPrimaryKey(ProjectCategory projectCategory) : base(projectCategory){}

        public static implicit operator ProjectCategoryPrimaryKey(int primaryKeyValue)
        {
            return new ProjectCategoryPrimaryKey(primaryKeyValue);
        }

        public static implicit operator ProjectCategoryPrimaryKey(ProjectCategory projectCategory)
        {
            return new ProjectCategoryPrimaryKey(projectCategory);
        }
    }
}