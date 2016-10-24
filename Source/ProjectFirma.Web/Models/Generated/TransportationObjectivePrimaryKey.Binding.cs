//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.TransportationObjective
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    public class TransportationObjectivePrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<TransportationObjective>
    {
        public TransportationObjectivePrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public TransportationObjectivePrimaryKey(TransportationObjective transportationObjective) : base(transportationObjective){}

        public static implicit operator TransportationObjectivePrimaryKey(int primaryKeyValue)
        {
            return new TransportationObjectivePrimaryKey(primaryKeyValue);
        }

        public static implicit operator TransportationObjectivePrimaryKey(TransportationObjective transportationObjective)
        {
            return new TransportationObjectivePrimaryKey(transportationObjective);
        }
    }
}