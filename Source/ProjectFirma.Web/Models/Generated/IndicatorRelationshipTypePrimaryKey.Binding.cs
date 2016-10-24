//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.IndicatorRelationshipType
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    public class IndicatorRelationshipTypePrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<IndicatorRelationshipType>
    {
        public IndicatorRelationshipTypePrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public IndicatorRelationshipTypePrimaryKey(IndicatorRelationshipType indicatorRelationshipType) : base(indicatorRelationshipType){}

        public static implicit operator IndicatorRelationshipTypePrimaryKey(int primaryKeyValue)
        {
            return new IndicatorRelationshipTypePrimaryKey(primaryKeyValue);
        }

        public static implicit operator IndicatorRelationshipTypePrimaryKey(IndicatorRelationshipType indicatorRelationshipType)
        {
            return new IndicatorRelationshipTypePrimaryKey(indicatorRelationshipType);
        }
    }
}