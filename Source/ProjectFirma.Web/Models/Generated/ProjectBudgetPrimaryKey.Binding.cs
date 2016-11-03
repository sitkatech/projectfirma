//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.ProjectBudget
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    public class ProjectBudgetPrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<ProjectBudget>
    {
        public ProjectBudgetPrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public ProjectBudgetPrimaryKey(ProjectBudget projectBudget) : base(projectBudget){}

        public static implicit operator ProjectBudgetPrimaryKey(int primaryKeyValue)
        {
            return new ProjectBudgetPrimaryKey(primaryKeyValue);
        }

        public static implicit operator ProjectBudgetPrimaryKey(ProjectBudget projectBudget)
        {
            return new ProjectBudgetPrimaryKey(projectBudget);
        }
    }
}