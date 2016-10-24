//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.TransportationCostParameterSet
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    public class TransportationCostParameterSetPrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<TransportationCostParameterSet>
    {
        public TransportationCostParameterSetPrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public TransportationCostParameterSetPrimaryKey(TransportationCostParameterSet transportationCostParameterSet) : base(transportationCostParameterSet){}

        public static implicit operator TransportationCostParameterSetPrimaryKey(int primaryKeyValue)
        {
            return new TransportationCostParameterSetPrimaryKey(primaryKeyValue);
        }

        public static implicit operator TransportationCostParameterSetPrimaryKey(TransportationCostParameterSet transportationCostParameterSet)
        {
            return new TransportationCostParameterSetPrimaryKey(transportationCostParameterSet);
        }
    }
}