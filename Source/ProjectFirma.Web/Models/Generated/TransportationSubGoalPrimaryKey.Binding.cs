//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.TransportationSubGoal
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    public class TransportationSubGoalPrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<TransportationSubGoal>
    {
        public TransportationSubGoalPrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public TransportationSubGoalPrimaryKey(TransportationSubGoal transportationSubGoal) : base(transportationSubGoal){}

        public static implicit operator TransportationSubGoalPrimaryKey(int primaryKeyValue)
        {
            return new TransportationSubGoalPrimaryKey(primaryKeyValue);
        }

        public static implicit operator TransportationSubGoalPrimaryKey(TransportationSubGoal transportationSubGoal)
        {
            return new TransportationSubGoalPrimaryKey(transportationSubGoal);
        }
    }
}