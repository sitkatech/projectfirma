//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.ProjectLocalAndRegionalPlan
using ProjectFirma.Web.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Models
{
    public class ProjectLocalAndRegionalPlanPrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<ProjectLocalAndRegionalPlan>
    {
        public ProjectLocalAndRegionalPlanPrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public ProjectLocalAndRegionalPlanPrimaryKey(ProjectLocalAndRegionalPlan projectLocalAndRegionalPlan) : base(projectLocalAndRegionalPlan){}

        public static implicit operator ProjectLocalAndRegionalPlanPrimaryKey(int primaryKeyValue)
        {
            return new ProjectLocalAndRegionalPlanPrimaryKey(primaryKeyValue);
        }

        public static implicit operator ProjectLocalAndRegionalPlanPrimaryKey(ProjectLocalAndRegionalPlan projectLocalAndRegionalPlan)
        {
            return new ProjectLocalAndRegionalPlanPrimaryKey(projectLocalAndRegionalPlan);
        }
    }
}