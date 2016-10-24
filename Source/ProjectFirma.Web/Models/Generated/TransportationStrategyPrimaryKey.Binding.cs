//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.TransportationStrategy
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    public class TransportationStrategyPrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<TransportationStrategy>
    {
        public TransportationStrategyPrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public TransportationStrategyPrimaryKey(TransportationStrategy transportationStrategy) : base(transportationStrategy){}

        public static implicit operator TransportationStrategyPrimaryKey(int primaryKeyValue)
        {
            return new TransportationStrategyPrimaryKey(primaryKeyValue);
        }

        public static implicit operator TransportationStrategyPrimaryKey(TransportationStrategy transportationStrategy)
        {
            return new TransportationStrategyPrimaryKey(transportationStrategy);
        }
    }
}