//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.TransportationGoal
using ProjectFirma.Web.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Models
{
    public class TransportationGoalPrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<TransportationGoal>
    {
        public TransportationGoalPrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public TransportationGoalPrimaryKey(TransportationGoal transportationGoal) : base(transportationGoal){}

        public static implicit operator TransportationGoalPrimaryKey(int primaryKeyValue)
        {
            return new TransportationGoalPrimaryKey(primaryKeyValue);
        }

        public static implicit operator TransportationGoalPrimaryKey(TransportationGoal transportationGoal)
        {
            return new TransportationGoalPrimaryKey(transportationGoal);
        }
    }
}