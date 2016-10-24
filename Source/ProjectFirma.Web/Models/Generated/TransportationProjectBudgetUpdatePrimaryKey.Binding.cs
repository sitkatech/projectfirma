//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.TransportationProjectBudgetUpdate
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    public class TransportationProjectBudgetUpdatePrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<TransportationProjectBudgetUpdate>
    {
        public TransportationProjectBudgetUpdatePrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public TransportationProjectBudgetUpdatePrimaryKey(TransportationProjectBudgetUpdate transportationProjectBudgetUpdate) : base(transportationProjectBudgetUpdate){}

        public static implicit operator TransportationProjectBudgetUpdatePrimaryKey(int primaryKeyValue)
        {
            return new TransportationProjectBudgetUpdatePrimaryKey(primaryKeyValue);
        }

        public static implicit operator TransportationProjectBudgetUpdatePrimaryKey(TransportationProjectBudgetUpdate transportationProjectBudgetUpdate)
        {
            return new TransportationProjectBudgetUpdatePrimaryKey(transportationProjectBudgetUpdate);
        }
    }
}