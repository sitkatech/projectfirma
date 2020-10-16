//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.MatchmakerOrganizationPerformanceMeasure
using CodeFirstStoreFunctions;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public class MatchmakerOrganizationPerformanceMeasurePrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<MatchmakerOrganizationPerformanceMeasure>
    {
        public MatchmakerOrganizationPerformanceMeasurePrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public MatchmakerOrganizationPerformanceMeasurePrimaryKey(MatchmakerOrganizationPerformanceMeasure matchmakerOrganizationPerformanceMeasure) : base(matchmakerOrganizationPerformanceMeasure){}

        public static implicit operator MatchmakerOrganizationPerformanceMeasurePrimaryKey(int primaryKeyValue)
        {
            return new MatchmakerOrganizationPerformanceMeasurePrimaryKey(primaryKeyValue);
        }

        public static implicit operator MatchmakerOrganizationPerformanceMeasurePrimaryKey(MatchmakerOrganizationPerformanceMeasure matchmakerOrganizationPerformanceMeasure)
        {
            return new MatchmakerOrganizationPerformanceMeasurePrimaryKey(matchmakerOrganizationPerformanceMeasure);
        }
    }
}