//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.LocalAndRegionalPlan
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    public class LocalAndRegionalPlanPrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<LocalAndRegionalPlan>
    {
        public LocalAndRegionalPlanPrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public LocalAndRegionalPlanPrimaryKey(LocalAndRegionalPlan localAndRegionalPlan) : base(localAndRegionalPlan){}

        public static implicit operator LocalAndRegionalPlanPrimaryKey(int primaryKeyValue)
        {
            return new LocalAndRegionalPlanPrimaryKey(primaryKeyValue);
        }

        public static implicit operator LocalAndRegionalPlanPrimaryKey(LocalAndRegionalPlan localAndRegionalPlan)
        {
            return new LocalAndRegionalPlanPrimaryKey(localAndRegionalPlan);
        }
    }
}