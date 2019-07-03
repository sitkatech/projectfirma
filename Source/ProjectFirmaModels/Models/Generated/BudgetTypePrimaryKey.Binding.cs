//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.BudgetType
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public class BudgetTypePrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<BudgetType>
    {
        public BudgetTypePrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public BudgetTypePrimaryKey(BudgetType budgetType) : base(budgetType){}

        public static implicit operator BudgetTypePrimaryKey(int primaryKeyValue)
        {
            return new BudgetTypePrimaryKey(primaryKeyValue);
        }

        public static implicit operator BudgetTypePrimaryKey(BudgetType budgetType)
        {
            return new BudgetTypePrimaryKey(budgetType);
        }
    }
}