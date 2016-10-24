//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.TransportationProjectCostType
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    public class TransportationProjectCostTypePrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<TransportationProjectCostType>
    {
        public TransportationProjectCostTypePrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public TransportationProjectCostTypePrimaryKey(TransportationProjectCostType transportationProjectCostType) : base(transportationProjectCostType){}

        public static implicit operator TransportationProjectCostTypePrimaryKey(int primaryKeyValue)
        {
            return new TransportationProjectCostTypePrimaryKey(primaryKeyValue);
        }

        public static implicit operator TransportationProjectCostTypePrimaryKey(TransportationProjectCostType transportationProjectCostType)
        {
            return new TransportationProjectCostTypePrimaryKey(transportationProjectCostType);
        }
    }
}