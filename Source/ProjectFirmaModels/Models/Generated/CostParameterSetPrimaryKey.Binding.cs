//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.CostParameterSet
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public class CostParameterSetPrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<CostParameterSet>
    {
        public CostParameterSetPrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public CostParameterSetPrimaryKey(CostParameterSet costParameterSet) : base(costParameterSet){}

        public static implicit operator CostParameterSetPrimaryKey(int primaryKeyValue)
        {
            return new CostParameterSetPrimaryKey(primaryKeyValue);
        }

        public static implicit operator CostParameterSetPrimaryKey(CostParameterSet costParameterSet)
        {
            return new CostParameterSetPrimaryKey(costParameterSet);
        }
    }
}