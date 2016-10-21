//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.IndicatorRelationship
using ProjectFirma.Web.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Models
{
    public class IndicatorRelationshipPrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<IndicatorRelationship>
    {
        public IndicatorRelationshipPrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public IndicatorRelationshipPrimaryKey(IndicatorRelationship indicatorRelationship) : base(indicatorRelationship){}

        public static implicit operator IndicatorRelationshipPrimaryKey(int primaryKeyValue)
        {
            return new IndicatorRelationshipPrimaryKey(primaryKeyValue);
        }

        public static implicit operator IndicatorRelationshipPrimaryKey(IndicatorRelationship indicatorRelationship)
        {
            return new IndicatorRelationshipPrimaryKey(indicatorRelationship);
        }
    }
}