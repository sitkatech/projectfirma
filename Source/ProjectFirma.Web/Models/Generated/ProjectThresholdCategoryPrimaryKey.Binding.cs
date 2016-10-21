//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.ProjectThresholdCategory
using ProjectFirma.Web.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Models
{
    public class ProjectThresholdCategoryPrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<ProjectThresholdCategory>
    {
        public ProjectThresholdCategoryPrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public ProjectThresholdCategoryPrimaryKey(ProjectThresholdCategory projectThresholdCategory) : base(projectThresholdCategory){}

        public static implicit operator ProjectThresholdCategoryPrimaryKey(int primaryKeyValue)
        {
            return new ProjectThresholdCategoryPrimaryKey(primaryKeyValue);
        }

        public static implicit operator ProjectThresholdCategoryPrimaryKey(ProjectThresholdCategory projectThresholdCategory)
        {
            return new ProjectThresholdCategoryPrimaryKey(projectThresholdCategory);
        }
    }
}