//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.TransportationProjectBudget
using ProjectFirma.Web.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Models
{
    public class TransportationProjectBudgetPrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<TransportationProjectBudget>
    {
        public TransportationProjectBudgetPrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public TransportationProjectBudgetPrimaryKey(TransportationProjectBudget transportationProjectBudget) : base(transportationProjectBudget){}

        public static implicit operator TransportationProjectBudgetPrimaryKey(int primaryKeyValue)
        {
            return new TransportationProjectBudgetPrimaryKey(primaryKeyValue);
        }

        public static implicit operator TransportationProjectBudgetPrimaryKey(TransportationProjectBudget transportationProjectBudget)
        {
            return new TransportationProjectBudgetPrimaryKey(transportationProjectBudget);
        }
    }
}