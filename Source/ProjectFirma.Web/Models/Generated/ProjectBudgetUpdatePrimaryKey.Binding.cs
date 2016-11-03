//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.ProjectBudgetUpdate
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    public class ProjectBudgetUpdatePrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<ProjectBudgetUpdate>
    {
        public ProjectBudgetUpdatePrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public ProjectBudgetUpdatePrimaryKey(ProjectBudgetUpdate projectBudgetUpdate) : base(projectBudgetUpdate){}

        public static implicit operator ProjectBudgetUpdatePrimaryKey(int primaryKeyValue)
        {
            return new ProjectBudgetUpdatePrimaryKey(primaryKeyValue);
        }

        public static implicit operator ProjectBudgetUpdatePrimaryKey(ProjectBudgetUpdate projectBudgetUpdate)
        {
            return new ProjectBudgetUpdatePrimaryKey(projectBudgetUpdate);
        }
    }
}