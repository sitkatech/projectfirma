//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.DistanceFromTownCenterSummaryType
using ProjectFirma.Web.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Models
{
    public class DistanceFromTownCenterSummaryTypePrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<DistanceFromTownCenterSummaryType>
    {
        public DistanceFromTownCenterSummaryTypePrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public DistanceFromTownCenterSummaryTypePrimaryKey(DistanceFromTownCenterSummaryType distanceFromTownCenterSummaryType) : base(distanceFromTownCenterSummaryType){}

        public static implicit operator DistanceFromTownCenterSummaryTypePrimaryKey(int primaryKeyValue)
        {
            return new DistanceFromTownCenterSummaryTypePrimaryKey(primaryKeyValue);
        }

        public static implicit operator DistanceFromTownCenterSummaryTypePrimaryKey(DistanceFromTownCenterSummaryType distanceFromTownCenterSummaryType)
        {
            return new DistanceFromTownCenterSummaryTypePrimaryKey(distanceFromTownCenterSummaryType);
        }
    }
}